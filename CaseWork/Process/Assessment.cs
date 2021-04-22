using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.CaseWork.Process
{
    /// <summary>
    /// Categorized associations to an event, object, or experience.
    /// </summary>
    [Serializable]
    public class Assessment
    {
        /// <summary>
        /// "N/A" value for Likkert rank of "Subjective Units" indicating 
        /// <see cref="Satisfaction"/> or <see cref="Discomfort"/>.
        /// </summary>
        public static readonly int s_NA_SU = 0;
        /// <summary>
        /// Maximum value for Likkert rank of "Subjective Units" indicating 
        /// <see cref="Satisfaction"/> or <see cref="Discomfort"/>.
        /// </summary>
        public static readonly int s_MaxSU = 10;

        private string positive = string.Empty;
        private readonly Likkert satisfaction = new Likkert(s_MaxSU, true);
        private string negative = string.Empty;
        private readonly Likkert discomfort = new Likkert(s_MaxSU, true);

        /// <summary>
        /// Positive associations.
        /// </summary>
        /// <value>
        /// Resets <see cref="Satisfaction"/> when cleared.
        /// </value>
        public string Positive
        {
            get { return positive; }
            set
            {
                positive = value;
                if (string.Empty.Equals(positive)) satisfaction.Reset();
            }
        }

        /// <summary>
        /// Strength of positive association on a subjective scale from 1-10.
        /// </summary>
        /// <value>
        /// Setter requires definition of Positive.
        /// Value is constrained to [0,<see cref="s_MaxSU"]/>
        /// </value>
        public int Satisfaction
        {
            get { return satisfaction.Rank; }
            set
            {
                if (!string.Empty.Equals(positive))
                {
                    satisfaction.Rank = value;
                }
            }
        }


        /// <summary>
        /// Negative associations.
        /// </summary>
        /// <value>
        /// Resets <see cref="Distress"/> when cleared.
        /// </value>
        public string Negative
        {
            get { return negative; }
            set
            {
                negative = value;
                if (string.Empty.Equals(negative)) discomfort.Reset();
            }
        }

        /// <summary>
        /// Strength of negative association on a subjective scale from 1-10.
        /// </summary>
        /// <value>
        /// Setter requires definition of Negative.
        /// Value is constrained to [0,<see cref="s_MaxSU"]/>
        /// </value>
        public int Discomfort
        {
            get { return discomfort.Rank; }
            set
            {
                if (!string.Empty.Equals(negative))
                {
                    discomfort.Rank = value;
                }
            }
        }

    }
}
