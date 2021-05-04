using System;

namespace HypnosisRising.CaseWork.Process
{
    /// <summary>
    /// A subjective characterization of response between positive and
    /// negative extremes. Frequently used in questionaires, optionally 
    /// including an "N/A" selection.
    /// </summary>
    [Serializable]
    public class Likkert
    {

        private int max;
        private int min;
        private int init;
        private int rank;

        /// <summary>
        /// Null constructor for serialization.
        /// </summary>
        public Likkert() { }
        /// <summary>
        /// Programmatic constructor with scale limit. Defaults init to
        /// the middle of the range (the Likkert "typical").
        /// </summary>
        /// <param name="p_max"><see cref="Likkert(int,int)"/></param>
        public Likkert(int p_max) :
            this(p_max, true)
        { }
        /// <summary>
        /// Programmatic constructor with upper limit and initial value.
        /// </summary>
        /// <param name="p_max"><see cref="Rank"/> is allowed over [<see cref="Min"/>,p_max]</param>
        /// <param name="p_hasNA">Allows N/A (0) as a value. Implemented by adjustment of
        /// <see cref="Min"/>.</param>
        public Likkert(int p_max, bool p_hasNA)
        {
            min = p_hasNA ? 0 : 1;
            Max = p_max;
            Init = p_hasNA ? Min : (Min + Max) / 2;
            Rank = Init;
        }

        /// <summary>
        /// Lower limit of the scale for this instance.
        /// </summary>
        /// <remarks>
        /// Used in <see cref="Constrain"/> to control the lower limit of
        /// <see cref="Init"/> and <see cref="Rank"/>
        /// </remarks>
        public int Min
        {
            get => min;
        }

        /// <summary>
        /// Upper limit of the scale for this instance.
        /// </summary>
        /// <remarks>
        /// Used in <see cref="Constrain"/> to control the upper limit of
        /// <see cref="Init"/> and <see cref="Rank"/>
        /// </remarks>
        public int Max
        {
            get => max;
            private set => max = value;
        }

        /// <summary>
        /// Value assigned on construction and in <see cref="Reset"/>
        /// </summary>
        /// <remarks>
        /// Will be constrained to [<see cref="Min",<see cref="Max"]./>/>
        /// </remarks>
        public int Init
        {
            get => init;
            private set => init = Constrain(value);
        }

        /// <summary>
        /// Selected value on the scale.
        /// </summary>
        /// <remarks>
        /// Will be constrained to [<see cref="Min",<see cref="Max"]./>/>
        /// </remarks>
        public int Rank
        {
            get => rank;
            set => rank = Constrain(value);
        }

        /// <summary>
        /// Utility routine to constrain an integer to the range of the scale.
        /// </summary>
        /// <param name="p_iVal">Value to constrain.</param>
        /// <returns>p_iVal, or one of <see cref="Min"/> or
        /// <see cref="Max"/>.</returns>
        private int Constrain( int p_iVal)
        {
            if (p_iVal < Min)
            {
                return Min;
            }
            else if (p_iVal > Max)
            {
                return Max;
            }
 
            return p_iVal;
        }

        /// <summary>
        /// Sets <see cref="Rank"/> back to initial value.
        /// </summary>
        public void Reset()
        {
            rank = init;
        }
    }
}
