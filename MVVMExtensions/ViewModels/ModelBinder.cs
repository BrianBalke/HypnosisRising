using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace HypnosisRising.MVVMExtensions.ViewModels
{
    /// <summary>
    /// Placeholder for extensions that encapsulate support for:
    /// <list type="bullet">
    /// <item>the 
    /// <see cref="HypnosisRising.MVVMExtensions.Navigation"/> interfaces,
    /// many of which are exchanged through the 
    /// <see cref="Prism.Regions.NavigationParameters"/> mechanism.
    /// </item>
    /// <item>
    /// Distributed model-driven validation.
    /// </item>
    /// </list>
    /// </summary>
    public class ModelBinder : BindableBase, INotifyDataErrorInfo
    {
        protected IContainerRegistry _containerRegistry;

        public ModelBinder(IContainerRegistry containerRegistry)
        {
            _containerRegistry = containerRegistry;
        }

        public bool HasErrors => throw new NotImplementedException();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
