using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.MVVMExtensions.Navigation
{
    /// <summary>
    /// Publishes the type name for a View that presents instance data for
    /// editing.
    /// </summary>
    /// <remarks>
    /// In the usual case, the <see cref="IModule"/> class will explicitly
    /// define this value.
    /// </remarks>
    /// <typeparam name="T">The model class.</typeparam>
    public interface IModelConfiguration<T>
    {
        /// <summary>
        /// The PRISM "Uri" that is interpreted by the container provider to 
        /// resolve the View.
        /// </summary>
        public string Uri { get; }
    }
}
