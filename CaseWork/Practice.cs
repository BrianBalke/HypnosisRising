using HypnosisRising.CaseWork.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.CaseWork
{
    [Serializable]
    public class Practice
    {
        private string name;
        private List<Therapist> hypnotists = new List<Therapist>();
        private List<Client> clients = new List<Client>();

        /// <summary>
        /// Practice name.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Therapists in the practice.
        /// </summary>
        public List<Therapist> Hypnotists
        {
            get { return hypnotists; }
        }

        /// <summary>
        /// Clients served by the practice.
        /// </summary>
        public List<Client> Clients
        {
            get { return clients; }
        }
    }
}
