using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.CaseWork.Common
{
    /// <summary>
    /// The place of an event.
    /// </summary>
    /// <remarks>
    /// Fully specified, this resolves as a mailing address. Partially specified,
    /// it may suggest a culture or environment.
    /// </remarks>
    [Serializable]
    public class Location
    {
        private string street1;
        private string street2;
        private string district;
        private string region;
        private string mailCode;
        private string country;

        /// <summary>
        /// Most immediate means of approach.
        /// </summary>
        public string Street1
        {
            get { return street1; }
            set { street1 = value; }
        }

        /// <summary>
        /// Additional routing information, for example building or floor.
        /// </summary>
        public string Street2
        {
            get { return street2; }
            set { street2 = value; }
        }

        /// <summary>
        /// City (e.g. - Venice) in a mailing address, but otherwise may be 
        /// county (e.g. - Ventura) or development (e.g. - 'beachside').
        /// </summary>
        public string District
        {
            get { return district; }
            set { district = value; }
        }

        /// <summary>
        /// State in a US mailing address, but could also be a national park.
        /// </summary>
        public string Region
        {
            get { return region; }
            set { region = value; }
        }

        /// <summary>
        /// Zip in a US Mailing address.
        /// </summary>
        public string MailCode
        {
            get { return mailCode; }
            set { mailCode = value; }
        }

        /// <summary>
        /// As recognized in international law.
        /// </summary>
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

    }
}
