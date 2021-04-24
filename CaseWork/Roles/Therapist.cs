using HypnosisRising.CaseWork.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.CaseWork.Roles
{
    /// <summary>
    /// Individual providing therapy in the case.
    /// </summary>
    /// <remarks>
    /// The <see cref="Client"/> should be able to communicate in writing to the
    /// therapist and verify their professional standing.
    /// </remarks>
    /// <seealso cref="Contact"/>
    [Serializable]
    public class Therapist : Contact
    {
        private Location officeAddress;
        private bool officeIsMailing;
        private Location mailingAddress;
        private string certifier;
        private string certificate;
        private string insurer;
        private string policyNumber;

        public Therapist()
        {
            base.Context = Common.Environment.Commerce;
        }

        /// <summary>
        /// As respect the <see cref="Client"/>, the therapist is always a 
        /// service provider.
        /// </summary>
        public override Common.Environment Context
        {
            get { return base.Context; }
            set { }
        }

        /// <summary>
        /// Office address, captured as a <see cref="Location"/>.
        /// </summary>
        public Location OfficeAddress
        {
            get { return officeAddress; }
            set { officeAddress = value; }
        }

        /// <summary>
        /// Use office address for mail delivery?
        /// </summary>
        public bool OfficeIsMailing
        {
            get { return officeIsMailing; }
            set { officeIsMailing = value; }
        }

        /// <summary>
        /// Mailing address (as <see cref="Location"/>), if different from office.
        /// </summary>
        public Location MailingAddress
        {
            get { return mailingAddress; }
            set { mailingAddress = value; }
        }

        /// <summary>
        /// Organization that certifies the therapist's qualifications.
        /// </summary>
        public string Certifier
        {
            get { return certifier; }
            set { certifier = value; }
        }

        /// <summary>
        /// Certificate ID.
        /// </summary>
        public string Certificate
        {
            get { return certificate; }
            set { certificate = value; }
        }

        /// <summary>
        /// Issuer of insurance for the therapist.
        /// </summary>
        public string Insurer
        {
            get { return insurer; }
            set { insurer = value; }
        }

        /// <summary>
        /// Insurance policy number.
        /// </summary>
        public string PolicyNumber
        {
            get { return policyNumber; }
            set { policyNumber = value; }
        }

    }
}
