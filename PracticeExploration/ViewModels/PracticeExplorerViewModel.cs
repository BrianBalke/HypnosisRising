using HypnosisRising.CaseWork;
using HypnosisRising.CaseWork.Roles;
using HypnosisRising.MVVMExtensions.Navigation;
using HypnosisRising.MVVMExtensions.ViewModels;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HypnosisRising.PracticeExploration.ViewModels
{
    public class PracticeExplorerViewModel : 
            BindableBase, 
            IModelExplorer<Practice>,
            INavigationAware
    {
        IContainerProvider _provider;

        public PracticeExplorerViewModel()
        {
            AddHypnotistCommand = new DelegateCommand(AddHypnotist);
        }

        public PracticeExplorerViewModel(IContainerProvider p_provider)
        {
            _provider = p_provider;

            AddHypnotistCommand = new DelegateCommand(AddHypnotist);
        }

        private Practice _practice;
        public Practice Practice
        {
            get { return _practice; }
            set {
                if (_practice != value)
                {
                    _practice = value;
                    Name = _practice.Name;

                    foreach (var th in _practice.Hypnotists)
                    {
                        TherapistSelectionViewModel node = _provider.Resolve<TherapistSelectionViewModel>();
                        node.Therapist = th;
                        _therapists.Add(node);
                    }
                    HasTherapists = _therapists.Count != 0;
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private ObservableCollection<TherapistSelectionViewModel> _therapists
            = new ObservableCollection<TherapistSelectionViewModel>();

        public ObservableCollection<TherapistSelectionViewModel> Therapists
        {
            get => _therapists;
        }

        private bool _hasTherapists;
        public bool HasTherapists
        {
            get { return _hasTherapists; }
            set { SetProperty(ref _hasTherapists, value); }
        }

        public DelegateCommand AddHypnotistCommand { get; private set; }

        private void AddHypnotist()
        {
            Therapist add = new Therapist()
            {
                FirstName = "New",
                LastName = "Therapist",
                Certificate="Unknown"
            };

            _practice.Hypnotists.Add(add);
            TherapistSelectionViewModel node = _provider.Resolve<TherapistSelectionViewModel>();
            node.Therapist = add;
            (node as IModelExplorer<Therapist>).Organizer = Organizer;
            Therapists.Add(node);
            HasTherapists = true;
        }


        private string _configurationTarget;

        public string ConfigurationTarget { 
                            get => _configurationTarget; 
                            set => _configurationTarget = value; }
        public IModelSubscriber<Practice>.Subscription Updater { get => OnPracticeChanged; }
        public Practice Instance { get => _practice; }
        public IModelOrganizer Organizer { get; set; }

        private void OnPracticeChanged()
        {
            Name = _practice.Name;
        }

        IModelExplorer<Practice>.Subscription _updater;

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            IModelExplorer<Practice> explorer = RetrieveExplorer(navigationContext);
            if (explorer is null) return false;
            Practice therapist = explorer.Instance; 
            if (_practice is null) return false;
            return _practice != therapist;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            IModelExplorer<Practice> explorer = RetrieveExplorer(navigationContext);
            if (!(explorer is null))
            {
                Practice = explorer.Instance;
                _updater = explorer.Updater;
                (this as IModelExplorer<Practice>).Organizer = explorer.Organizer;
            }
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

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
