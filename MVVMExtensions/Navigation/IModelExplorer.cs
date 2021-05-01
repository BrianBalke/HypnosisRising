using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.MVVMExtensions.Navigation
{
    /// <summary>
    /// Specialization of <see cref="IModelSubscriber{T}"/> that allows an
    /// invoker to supply the PRISM region allocated for configuration views.
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    public interface IModelExplorer<T> : IModelSubscriber<T>
    {
        /// <summary>
        /// Key to use in NavigationParameters.
        /// </summary>
        const string Key = "MVVMexplorer";
        /// <summary>
        /// Region assigner.
        /// </summary>
        IModelOrganizer Organizer { get; set; }
    }
}
