using HypnosisRising.CaseWork;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TestDataContract
{
    class PracticeComparer : IEqualityComparer<Practice>
    {
        StringComparer s_stringComp = new StringComparer();

        public bool Equals([AllowNull] Practice x, [AllowNull] Practice y)
        {
            if (x == y) return true;
            if (x is null || y is null) return false;

            return s_stringComp.Equals(x.Name, y.Name) &&
                x.Hypnotists.Count == y.Hypnotists.Count &&
                x.Clients.Count == y.Clients.Count;
        }

        public int GetHashCode([DisallowNull] Practice obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
