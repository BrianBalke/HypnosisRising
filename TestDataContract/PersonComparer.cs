using HypnosisRising.CaseWork.Roles;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TestDataContract
{
    class PersonComparer : IEqualityComparer<Person>
    {
        StringComparer stringCompare = new StringComparer();

        public bool Equals([AllowNull] Person x, [AllowNull] Person y)
        {
            if (x == y) return true;
            if (x is null || y is null) return false;

            return stringCompare.Equals(x.FirstName, y.FirstName) &&
                stringCompare.Equals(x.LastName, y.LastName) &&
                stringCompare.Equals(x.Nickname, y.Nickname) &&
                x.Context == y.Context &&
                stringCompare.Equals(x.Role, y.Role);
        }

        public int GetHashCode([DisallowNull] Person inst)
        {
            StringBuilder hashContent = new StringBuilder();
            BuildHashContent(inst, hashContent);
            return hashContent.ToString().GetHashCode();
        }

        public static void BuildHashContent(
            Person p_inst,
            StringBuilder p_content )
        {
            p_content.Append(p_inst.FirstName);
            p_content.Append(p_inst.LastName);
            p_content.Append(p_inst.Nickname);
            p_content.Append(p_inst.Context.ToString());
            p_content.Append(p_inst.Role);
        }
    }
}
