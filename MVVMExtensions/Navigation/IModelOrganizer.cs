using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.MVVMExtensions.Navigation
{
    /// <summary>
    /// Allows allocation of views to PRISM regions according to the model type
    /// and purpose served. Typically implemented by the view model.
    /// </summary>
    public interface IModelOrganizer
    {
        /// <summary>
        /// User experience facilitated by view.
        /// </summary>
        enum Purpose
        {
            /// <summary>
            /// View will allow the user to select instances from collections 
            /// aggregated in the target type.
            /// </summary>
            Explore,
            /// <summary>
            /// View allows definition of simple properties of the type.
            /// </summary>
            Configure
        };

        /// <summary>
        /// Prototype for the region mapping method.
        /// </summary>
        /// <param name="p_ePurpose"></param>
        /// <param name="p_modelType"></param>
        /// <returns>Naming a region defined in the view.</returns>
        string SelectRegion(
            Purpose p_ePurpose,
            Type p_modelType);
    }
}
