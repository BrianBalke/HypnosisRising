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
    /// be decomposed in discovery. A goal should never be recast - only refined.
    /// If the client wishes to abandon a goal, mark it "fulfilled" and create
    /// another.
    /// </remarks>
    [Serializable]
    public class Goal
    {
        private string title;
        private DateTime established = DateTime.Now;
        private DateTime fulfilled = DateTime.MaxValue;
        private string description;
        private string trigger;
        private string cause;
        private State actualState = new State();
        private State desiredState = new State();
        private string observation;

        /// <summary>
        /// Evocative title for goal.
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// Date goal was established.
        /// </summary>
        public DateTime Established
        {
            get { return established; }
            set { established = value; }
        }

        /// <summary>
        /// Date goal was fulfilled
        /// </summary>
        public DateTime Fulfilled
        {
            get { return fulfilled; }
            set { established = value; }
        }

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
        /// Resulting <see cref="State"/> that frustrates an effective 
        /// reaction to the trigger.
        /// </summary>
        public State ActualState
        {
            get { return actualState; }
            set { actualState = value; }
        }

        /// <summary>
        /// <see cref="State"/> that client believes will support an effective
        /// response to the trigger.
        /// </summary>
        public State DesiredState
        {
            get { return desiredState; }
            set { desiredState = value; }
        }


        /// <summary>
        /// Therapists observations regarding goal.
        /// </summary>
        public string Observation
        {
            get { return observation; }
            set { observation = value; }
        }
    }
}
