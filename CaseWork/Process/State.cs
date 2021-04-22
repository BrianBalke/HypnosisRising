using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.CaseWork.Process
{

    /// <summary>
    /// Subjective characterization of overall condition.
    /// </summary>
    /// <seealso cref="Assessment"/>
    [Serializable]
    public class State
    {
        private string description;
        private Assessment physical;
        private Assessment emotional;
        private Assessment mental;
        private Assessment spiritual;

        private string observation;

        /// <summary>
        /// Unfiltered description of state.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Phyiscal condition.
        /// </summary>
        public Assessment Physical
        {
            get { return physical; }
            set { physical = value; }
        }

        /// <summary>
        /// Emotional condition.
        /// </summary>
        public Assessment Emotional
        {
            get { return emotional; }
            set { emotional = value; }
        }

        /// <summary>
        /// Mental condition.
        /// </summary>
        public Assessment Mental
        {
            get { return mental; }
            set { mental = value; }
        }

        /// <summary>
        /// Spiritual condition.
        /// </summary>
        public Assessment Spiritual
        {
            get { return spiritual; }
            set { spiritual = value; }
        }

        /// <summary>
        /// Therapeutic observation.
        /// </summary>
        public string Observation
        {
            get { return observation; }
            set { observation = value; }
        }

    }
}
