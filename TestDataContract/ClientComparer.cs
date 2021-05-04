using HypnosisRising.CaseWork.Roles;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TestDataContract
{
    class ClientComparer : IEqualityComparer<Client>
    {
        ContactComparer contactCompare = new ContactComparer();
        LocationComparer locationCompare = new LocationComparer();

        public bool Equals([AllowNull] Client x, [AllowNull] Client y)
        {
            if (x == y) return true;
            if (x is null || y is null) return false;

            return contactCompare.Equals(x, y) &&
                x.DateOfBirth.Equals(y.DateOfBirth) &&
                locationCompare.Equals(x.HomeAddress, y.HomeAddress) &&
                contactCompare.Equals(x.Partner, y.Partner) &&
                contactCompare.Equals(x.EmergencyContact, y.EmergencyContact) &&
                x.BillingRate == y.BillingRate;
        }

        public int GetHashCode([DisallowNull] Client inst)
        {
            StringBuilder hashContent = new StringBuilder();
            BuildHashContent(inst, hashContent);
            return hashContent.ToString().GetHashCode();
        }

        public static void BuildHashContent(
            Client p_inst,
            StringBuilder p_content)
        {
            ContactComparer.BuildHashContent(p_inst, p_content);
            p_content.Append(p_inst.DateOfBirth);
            LocationComparer.BuildHashContent(p_inst.HomeAddress, p_content);
            ContactComparer.BuildHashContent(p_inst.Partner, p_content);
            ContactComparer.BuildHashContent(p_inst.EmergencyContact, p_content);
            p_content.Append(p_inst.BillingRate);
        }
    }
}
