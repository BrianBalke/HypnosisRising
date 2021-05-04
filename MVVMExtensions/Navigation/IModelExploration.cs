using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.MVVMExtensions.Navigation
{
    /// <summary>
    /// Publishes the type name for a View that unwraps collections held
    /// in a model class.
    /// </summary>
    /// <typeparam name="T">The model class.</typeparam>
    public interface IModelExploration<T>
    {
        /// <summary>
        /// The PRISM "Uri" that is interpreted by the container provider to 
        /// resolve the View.
        /// </summary>
        public string Uri { get; }
    }
}
