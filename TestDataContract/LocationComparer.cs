using HypnosisRising.CaseWork.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TestDataContract
{
    class LocationComparer : IEqualityComparer<Location>
    {
        StringComparer stringCompare = new StringComparer();

        public bool Equals([AllowNull] Location x, [AllowNull] Location y)
        {
            if (x == y) return true;
            if (x is null || y is null) return false;

            return stringCompare.Equals(x.Street1, y.Street1) &&
                stringCompare.Equals(x.Street2, y.Street2) &&
                stringCompare.Equals(x.District, y.District) &&
                stringCompare.Equals(x.Region, y.Region) &&
                stringCompare.Equals(x.Country, y.Country) &&
                stringCompare.Equals(x.MailCode, y.MailCode);
        }

        public int GetHashCode([DisallowNull] Location inst)
        {
            StringBuilder hashContent = new StringBuilder();
            BuildHashContent(inst, hashContent);
            return hashContent.ToString().GetHashCode();
        }

        public static void BuildHashContent(
            Location p_inst,
            StringBuilder p_content)
        {
            p_content.Append(p_inst.Street1);
            p_content.Append(p_inst.Street2);
            p_content.Append(p_inst.District);
            p_content.Append(p_inst.Region);
            p_content.Append(p_inst.Country);
            p_content.Append(p_inst.MailCode);
        }
    }
}
