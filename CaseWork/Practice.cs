using HypnosisRising.CaseWork.Common;
using HypnosisRising.CaseWork.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.CaseWork
{
    /// <summary>
    /// Describing the assets of the practice.
    /// <list type="bullet">
    /// <item><see cref="Hypnotists"/></item>
    /// <item><see cref="Clients"/></item>
    /// <item>Public <see cref="Services"/> for emergency interventions.</item>
    /// </list>
    /// 
    /// Also includes a private list of contacts with public services.
    /// </summary>
    [Serializable]
    public class Practice
    {
        private string name;
        private Business registration;
        private string registrar;
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
        /// Business type.
        /// </summary>
        public Business Registration
        {
            get { return registration; }
            set { registration = value; }
        }

        /// <summary>
        /// Entity authorizing operation.
        /// </summary>
        public string Registrar
        {
            get { return registrar; }
            set { registrar = value; }
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
