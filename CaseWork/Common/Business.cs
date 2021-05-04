using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.CaseWork.Common
{
    /// <summary>
    /// Business formation choices.
    /// </summary>
    public enum Business
    {
        /// <summary>
        /// Business is registered as a personal activity.
        /// </summary>
        SoleProprietor,
        /// <summary>
        /// Multiple persons involved in activity.
        /// </summary>
        Partnership,
        /// <summary>
        /// Business organized to allow capital investment.
        /// </summary>
        Corporation,
        /// <summary>
        /// Partnership protecting personal assets.
        /// </summary>
        LimitedLiability,
        /// <summary>
        /// Assets accrue to the registrar when business is closed.
        /// </summary>
        NonProfit
    }
}
