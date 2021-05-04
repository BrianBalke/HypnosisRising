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
using System.Windows.Input;

namespace HypnosisRising.PracticeExploration.ViewModels
{
    /// <summary>
    /// For the <see cref="PracticeExplorer"/>, wraps a <see cref="Practice"/> 
    /// and its collections to allow:
    /// <list type="bullet">
    /// <item>Creating new instances.</item>
    /// <item>Selection for configuration.</item>
    /// </list>
    /// 
    /// Implements <see cref="INavigationAware"/> to receive the target
    /// instance from the invoker.
    /// Implements <see cref="IModelExplorer{Practice}"/> to coordinate
    /// configuration.
    /// </summary>
    public class PracticeExplorerViewModel : 
            BindableBase, 
            IModelExplorer<Practice>,
            INavigationAware
    {
        private IContainerProvider _provider;
        private IRegionManager _regions;
        private IModelConfiguration<Practice> _configuration;

        /// <summary>
        /// Obtains resources for view navigation and command processing.
        /// </summary>
        /// <param name="p_provider">For view model wrappers.</param>
        /// <param name="p_regions">For navigation</param>
        /// <param name="p_configuration">For access to <see cref="Practice"/> 
        /// configuration.</param>
        public PracticeExplorerViewModel(
                IContainerProvider p_provider,
                IRegionManager p_regions,
                IModelConfiguration<Practice> p_configuration)
        {
            _provider = p_provider;
            _regions = p_regions;
            _configuration = p_configuration;

            EditPracticeCommand = new DelegateCommand(EditPractice);
            AddHypnotistCommand = new DelegateCommand(AddHypnotist);
            AddClientCommand = new DelegateCommand(AddClient);
            (this as IModelSubscriber<Practice>).Updater = new DelegateCommand(UpdatePractice);
        }

        private Practice _practice;
        /// <summary>
        /// Target instance. Setter should only be invoked on initialization,
        /// and wraps collections.
        /// </summary>
        public Practice Practice
        {
            get { return _practice; }
            set {
                if (_practice != value)
                {
                    _practice = value;
                    Name = _practice.Name;

                    PopulateHypnotists();
                    PopulateClients();
                }
            }
        }

        private string _name;
        /// <summary>
        /// Proxy text in <see cref="PracticeExplorer"/>
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        /// <summary>
        /// To trigger definition of <see cref="Practice"/> properties.
        /// </summary>
        public DelegateCommand EditPracticeCommand { get; private set; }

        /// <summary>
        /// Delegate to invoke <see cref="Practice"/> configuration.
        /// </summary>
        private void EditPractice()
        {
           _regions.RequestNavigate(
                (this as IModelExplorer<Practice>).Organizer.SelectRegion(
                                    IModelOrganizer.Purpose.Configure,
                                    typeof(Practice)),
                _configuration.Uri,
                new NavigationParameters()
                {
                    {   IModelExplorer<Practice>.Key,
                        this as IModelExplorer<Practice> }
                } );
        }

        /*=====================================================================
         ===== Hypnotists enumeration.
         ====================================================================*/

        private ObservableCollection<TherapistSelectionViewModel> _hypnotists
            = new ObservableCollection<TherapistSelectionViewModel>();

        /// <summary>
        /// Wrapping hypnotists for presentation.
        /// </summary>
        public ObservableCollection<TherapistSelectionViewModel> Hypnotists
        {
            get => _hypnotists;
        }

        /// <summary>
        /// Wraps each <see cref="Therapist"/> in the <see 
        /// cref="Practice.Hypnotists"/> collection for selection from the 
        /// <see cref="PracticeExplorer"/>.
        /// </summary>
        private void PopulateHypnotists()
        {
            _hypnotists.Clear();
            foreach (var th in _practice.Hypnotists)
            {
                TherapistSelectionViewModel node =
                        _provider.Resolve<TherapistSelectionViewModel>();
                (node as IModelExplorer<Therapist>).Organizer = Organizer;
                node.Therapist = th;
                _hypnotists.Add(node);
            }
        }

        /// <summary>
        /// Command to add a new therapist record to the practice.
        /// </summary>
        public DelegateCommand AddHypnotistCommand { get; private set; }

        /// <summary>
        /// Adds a new therapist to the practice, and wraps for selection.
        /// </summary>
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
            Hypnotists.Add(node);
        }

        /*=====================================================================
         ===== Client enumeration.
         ====================================================================*/

        private ObservableCollection<ClientSelectionViewModel> _clients
            = new ObservableCollection<ClientSelectionViewModel>();

        /// <summary>
        /// Wrapping clients for presentation.
        /// </summary>
        public ObservableCollection<ClientSelectionViewModel> Clients
        {
            get => _clients;
        }

        /// <summary>
        /// Wraps each <see cref="Client"/> in the 
        /// <see cref="Practice.Clients"/> collection for selection from the 
        /// <see cref="PracticeExplorer"/>.
        /// </summary>
        private void PopulateClients()
        {
            _clients.Clear();
            foreach (var th in _practice.Clients)
            {
                ClientSelectionViewModel node =
                        _provider.Resolve<ClientSelectionViewModel>();
                (node as IModelExplorer<Client>).Organizer = Organizer;
                node.Client = th;
                _clients.Add(node);
            }
        }

        /// <summary>
        /// Command to add a new client record to the practice.
        /// </summary>
        public DelegateCommand AddClientCommand { get; private set; }

        /// <summary>
        /// Adds a new client to the practice, and wraps for selection.
        /// </summary>
        private void AddClient()
        {
            Client add = new Client()
            {
                FirstName = "New",
                LastName = "Client",
                DateOfBirth = DateTime.Now
            };

            _practice.Clients.Add(add);
            ClientSelectionViewModel node = _provider.Resolve<ClientSelectionViewModel>();
            node.Client = add;
            (node as IModelExplorer<Client>).Organizer = Organizer;
            Clients.Add(node);
        }


        /*=====================================================================
         ===== IModeExplorer implementation.
         ====================================================================*/

        ICommand IModelSubscriber<Practice>.Updater { get; set; }
        public Practice Instance { get => _practice; }
        public IModelOrganizer Organizer { get; set; }

        /// <summary>
        /// Delegate to update the proxy text following configuration.
        /// </summary>
        private void UpdatePractice()
        {
            Name = _practice.Name;
        }
        
        /// <summary>
        /// Signals to re-use existing explorer when navigation requests display.
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns><code>false</code> if target instance is undefined.</returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            IModelExplorer<Practice> explorer = RetrieveExplorer(navigationContext);
            if (explorer is null) return false;
            if (_practice is null) return false;
            _practice = explorer.Instance; 
            return true;
        }

        /// <summary>
        /// Captures context from the invoker.
        /// </summary>
        /// <param name="navigationContext">Expected to contain an
        /// <see cref="IModelExplorer{Practice}"/>.</param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            IModelExplorer<Practice> explorer = RetrieveExplorer(navigationContext);
            if (!(explorer is null))
            {
                (this as IModelExplorer<Practice>).Organizer = explorer.Organizer;
                Practice = explorer.Instance;
            }
        }

        /// <summary>
        /// Void.
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
