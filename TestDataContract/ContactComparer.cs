using HypnosisRising.CaseWork.Roles;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TestDataContract
{
    class ContactComparer : IEqualityComparer<Contact>
    {
        PersonComparer personCompare = new PersonComparer();
        StringComparer stringCompare = new StringComparer();

        public bool Equals([AllowNull] Contact x, [AllowNull] Contact y)
        {
            if (x == y) return true;
            if (x is null || y is null) return false;

            return personCompare.Equals(x, y) &&
                stringCompare.Equals(x.EMail, y.EMail) &&
                stringCompare.Equals(x.Phone, y.Phone) &&
                x.HasText == y.HasText;
        }

        public int GetHashCode([DisallowNull] Contact inst)
        {
            StringBuilder hashContent = new StringBuilder();
            BuildHashContent(inst, hashContent);
            return hashContent.ToString().GetHashCode();
        }

        public static void BuildHashContent(
            Contact p_inst,
            StringBuilder p_content)
        {
            PersonComparer.BuildHashContent(p_inst, p_content);
            p_content.Append(p_inst.EMail);
            p_content.Append(p_inst.Phone);
            p_content.Append(p_inst.HasText.ToString());
        }
    }
}
