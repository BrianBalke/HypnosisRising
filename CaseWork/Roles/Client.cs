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

        private DateTime dateOfBirth = DateTime.Now;
        private Location homeAddress = new Location();
        private Contact emergencyContact = new Contact();
        private Contact partner = new Contact();
        private int billingRate;

        /// <summary>
        /// Client is known as <see cref="Common.Environment.Self"/>
        /// </summary>
        public Client()
        {
            base.Context = Common.Environment.Self;
        }

        /// <summary>
        /// All relationships are defined with respect to the client.
        /// </summary>
        public override Common.Environment Context
        {
            get { return base.Context; }
            set { }
        }

        /// <summary>
        /// Birthday.
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }


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
        /// Partner, as a <see cref="Contact"/>
        /// </summary>
        public Contact Partner
        {
            get { return partner; }
            set { partner = value; }
        }

        /// <summary>
        /// Billing rate, in dollars.
        /// </summary>
        public int BillingRate
        {
            get { return billingRate; }
            set { billingRate = value; }
        }
    }
}
