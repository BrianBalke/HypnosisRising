using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.CaseWork.Process
{
    /// <summary>
    /// Statement of desired therapeutic outcome.
    /// </summary>
    /// <remarks>
    /// The client's statement will often include a complex rationalization to
    /// be decomposed in discovery. 
    /// </remarks>
    [Serializable]
    public class Goal
    {
        private string description;
        private string trigger;
        private string cause;
        private State actualState;
        private State desiredState;

        /// <summary>
        /// Unfiltered description of goal.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Condition that triggers undesirable behavior.
        /// </summary>
        public string Trigger
        {
            get { return trigger; }
            set { trigger = value; }
        }

        /// <summary>
        /// Cause of undesirable behavior. May be acute or chronic.
        /// </summary>
        public string Cause
        {
            get { return cause; }
            set { cause = value; }
        }

        /// <summary>
        /// Resulting <see cref="State"/> that frustrates an ineffective 
        /// reaction to the trigger.
        /// </summary>
        public State ActualState
        {
            get { return actualState; }
            set { actualState = value; }
        }

        /// <summary>
        /// <see cref="State"/> that client believes will support an organized
        /// response to the trigger.
        /// </summary>
        public State DesiredState
        {
            get { return desiredState; }
            set { desiredState = value; }
        }

    }
}
