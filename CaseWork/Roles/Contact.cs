using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace HypnosisRising.CaseWork.Roles
{
    /// <summary>
    /// An <see cref="Indivual"/> that may be contacted in therapy.
    /// </summary>
    /// <remarks>
    /// This supports bi-directional exchanges between <see cref="Client"/>
    /// and <see cref="Therapist"/>, but in the case of the Client includes
    /// those trusted to offer support outside of therapy - such as a romantic
    /// partner, emergency contact, or <see cref="Clinician"/>.
    /// </remarks>
    /// 
    /// <seealso cref="Person"/>
    /// <seealso cref="Client"/>
    /// <seealso cref="Therapist"/>
    /// <seealso cref="Clinician"/>
    [Serializable]
    public class Contact : Person
    {
        private string email;
        private string phone;
        private bool hasText;

        /// <summary>
        /// E-mail address.
        /// </summary>
        public string EMail
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Primary phone.
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        /// <summary>
        /// Does phone support text messaging?
        /// </summary>
        public bool HasText
        {
            get { return hasText; }
            set { hasText = value; }
        }

    }
}
