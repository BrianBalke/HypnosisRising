using HypnosisRising.CaseWork.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.CaseWork
{
    /// <summary>
    /// A case is a complete record of work done with a client.
    /// </summary>
    /// <remarks>
    /// A hypnotist is assigned per session. Clinicians often have an existing
    /// relationship with the client upon application, but may be introdeced
    /// should clinical issues be revealed in therpy.
    /// </remarks>
    /// <seealso cref="Client"/>
    /// <seealso cref="Therapist"/>
    /// <seealso cref="Clinician"/>
    [Serializable]
    public class Case
    {
        private Therapist hypnotist;
        private Client client;
        private DateTime firstContact;
        private bool isActive;
        private List<Clinician> clinicians = new List<Clinician>();

        /// <summary>
        /// Default constructor. Sets the case to open.
        /// </summary>
        public Case()
        {
            isActive = false;
        }

        /// <summary>
        /// Assigned hypnotherapist.
        /// </summary>
        public Therapist Hypnotist
        {
            get { return hypnotist; }
            set { hypnotist = value; }
        }

        /// <summary>
        /// Therapeutic subject.
        /// </summary>
        public Client Client
        {
            get { return client; }
            set { client = value; }
        }

        /// <summary>
        /// Date case record was created.
        /// </summary>
        public DateTime FirstContact
        {
            get { return firstContact; }
            set { firstContact = value; }
        }

        /// <summary>
        /// Is case active?
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        /// <summary>
        /// Consenting clinicians.
        /// </summary>
        public List<Clinician> Clinicians
        {
            get { return clinicians = new List<Clinician>(); }
        }
    }
}
