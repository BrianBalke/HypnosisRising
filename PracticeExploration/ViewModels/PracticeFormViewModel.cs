using HypnosisRising.CaseWork;
using HypnosisRising.CaseWork.Common;
using HypnosisRising.MVVMExtensions.Navigation;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace HypnosisRising.PracticeExploration.ViewModels
{
    /// <summary>
    /// Wraps <see cref="Practice"/> properties for editing in a
    /// <see cref="Views.PracticeForm"/>. Values are held locally until
    /// the <see cref="UpdateCommand"/> is triggered.
    /// </summary>
    public class PracticeFormViewModel : BindableBase, INavigationAware
    {
        /// <summary>
        /// Prepares the update command.
        /// </summary>
        public PracticeFormViewModel()
        {
            UpdateCommand = new DelegateCommand(OnUpdate);
        }

        private Practice _practice;

        /// <summary>
        /// Target instance. Setter should be invoked only on navigation,
        /// and transfers instance properties to local storage.
        /// </summary>
        public Practice Practice
        {
            get { return _practice; }
            set { 
                _practice = value;

                Name = _practice.Name;
                Registration = _practice.Registration;
                Registrar = _practice.Registrar;
            }
        }

        private string _name;
        /// <summary>
        /// Practice name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private Business _registration;
        /// <summary>
        /// Two-way binding for registration.
        /// </summary>
        public Business Registration
        {
            get { return _registration; }
            set { SetProperty(ref _registration, value); }
        }
        private string _registrar;
        /// <summary>
        /// Two-way binding for registrar.
        /// </summary>
        public string Registrar
        {
            get { return _registrar; }
            set { SetProperty(ref _registrar, value); }
        }

        /// <summary>
        /// Command that allows user to transfer changes to the target
        /// instance.
        /// </summary>
        public DelegateCommand UpdateCommand { get; private set; }

        /// <summary>
        /// Tranfsers local values to the instance and updates the
        /// invoker.
        /// </summary>
        public void OnUpdate()
        {
            _practice.Name = Name;
            _practice.Registration = Registration;
            _practice.Registrar = Registrar;

            if (!(_explorerUpdater is null))
            {
                _explorerUpdater.Execute(null);
            }
        }


        /*=====================================================================
         ===== INavigationAware implementation.
         ====================================================================*/

        /// <summary>
        /// Command to update the invoker.
        /// </summary>
        ICommand _explorerUpdater;

        /// <summary>
        /// Captures configuration context from invoker.
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            IModelExplorer<Practice> explorer = RetrieveExplorer(navigationContext);
            if (!(explorer is null))
            {
                Practice = explorer.Instance;
                _explorerUpdater = explorer.Updater;
            }
        }

        /// <summary>
        /// Signals to re-use existing form.
        /// </summary>
        /// <param name="navigationContext"></param>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            IModelExplorer<Practice> explorer = RetrieveExplorer(navigationContext);
            if (explorer is null) return false;
            if (_practice is null) return false;
            _practice = explorer.Instance;
            return true;
        }

        /// <summary>
        /// Unused.
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <summary>
        /// Extracts coordination data from navigation.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public IModelExplorer<Practice> RetrieveExplorer(
                NavigationContext context)
        {
            if (context.Parameters.ContainsKey(IModelExplorer<Practice>.Key))
            {
                return context.Parameters.
                        GetValue<IModelExplorer<Practice>>(
                            IModelExplorer<Practice>.Key);
            }

            return null;
        }
    }
}
