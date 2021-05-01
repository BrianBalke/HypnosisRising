using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.MVVMExtensions.Navigation
{
    public interface IModelConfigurer<T>
    {
        const string Key = "MVVMconfigurer";
        event EventHandler Updating;
        T Instance { get; set; }
    }
}
