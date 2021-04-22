using HypnosisRising.CaseWork.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.CaseWork.Roles
{
    /// <summary>
    /// Contact information for a clinician involved in concurrent treatment
    /// of the <see cref="Client"/>.
    /// </summary>
    /// <remarks>
    /// For therapy involving issues beyond the scope of "vocational and
    /// avocational self-improvement," consent must be obtained from an
    /// appropriate clinician. The categories of clinician are enumerated
    /// in <see cref="License"/>. Under HIPAA constraints, communications
    /// must be conducted in writing or via FAX.
    /// </remarks>
    /// <seealso cref="Contact"/>
    public class Clinician : Contact
    {
        /// <summary>
        /// Clinical categories licensed under California law.
        /// </summary>
        public enum License
        {
            MedicalDoctor,
            Dentist,
            Psychiatrist,
            Psychotherapist,
            LCSW,
            MFT
        }

        private License practice;
        private Location mailingAddress;
        private string fax;

        /// <summary>
        /// Type of clinical practice.
        /// </summary>
        public License Practice
        {
            get { return practice; }
            set { practice = value; }
        }

        /// <summary>
        /// Mailing address.
        /// </summary>
        public Location MailingAddress
        {
            get { return mailingAddress; }
            set { mailingAddress = value; }
        }

        /// <summary>
        /// Fax number.
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

    }
}
