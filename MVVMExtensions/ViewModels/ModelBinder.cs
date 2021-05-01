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
