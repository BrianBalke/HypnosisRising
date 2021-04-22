using HypnosisRising.CaseWork.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.CaseWork.Roles
{
    /// <summary>
    /// Capturing contact information for the subject of therapy.
    /// </summary>
    /// <remarks>
    /// Including references to those that may be brought into crisis 
    /// management
    /// </remarks>
    /// <see cref="Contact"/>
    [Serializable]
    public class Client : Contact
    {
        private Location homeAddress;
        private Contact emergencyContact;
        private Contact spouse;
        private int billingRate;

        /// <summary>
        /// Home address, as a <see cref="Location"/>.
        /// </summary>
        public Location HomeAddress
        {
            get { return homeAddress; }
            set { homeAddress = value; }
        }

        /// <summary>
        /// Emergency contact, as a <see cref="Contact"/>
        /// </summary>
        public Contact EmergencyContact
        {
            get { return emergencyContact; }
            set { emergencyContact = value; }
        }

        /// <summary>
        /// Spouse, as a <see cref="Contact"/>
        /// </summary>
        public Contact Spouse
        {
            get { return spouse; }
            set { spouse = value; }
        }
    }
}
