using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.MVVMExtensions.Navigation
{
    public interface IModelOrganizer
    {
        /// <summary>
        /// Key to use in NavigationParameters.
        /// </summary>
        const string Key = "MVVMorganizer";

        enum Purpose
        {
            Explore,
            Configure
        };

        string SelectRegion(
            Purpose p_ePurpose,
            Type p_modelType);
    }
}
