using HypnosisRising.CaseWork.Common;
using System;

namespace HypnosisRising.CaseWork.Roles
{
    /// <summary>
    /// An individual in personal history.
    /// <remarks>
    /// Referenced most frequently in an <see cref="Event"/> captured in client 
    /// <see cref="History"/>. The properties capture the client's natural 
    /// association, including the relationship context and role.
    /// </remarks>
    /// 
    /// <seealso cref="Contact"/>
    /// <seealso cref="Client"/>
    /// <seealso cref="Therapist"/>
    /// </summary>
    [Serializable]
    public class Individual
    {
        private string firstName;
        private string lastName;
        private string nickname;
        private Common.Environment context;
        private string role;

        /// <summary>
        /// Individual's first name.
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// Individual's last name.
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// Familiar identifier. May include suffixes such as "Jr."
        /// </summary>
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        /// <summary>
        /// Context of the relationship. <see cref="Environment"/>
        /// </summary>
        public Common.Environment Context
        {
            get { return context; }
            set { context = value; }
        }

        /// <summary>
        /// Role within the context (i.e. 'Mother', 'Father' with <see cref="Individual.Context"/>
        /// <see cref="Environment.Family"/>.
        /// </summary>
        public string Role
        {
            get { return role; }
            set { role = value; }
        }

    }
}
