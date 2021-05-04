using HypnosisRising.CaseWork.Roles;
using HypnosisRising.MVVMExtensions.Navigation;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HypnosisRising.PracticeExploration.ViewModels
{
    /// <summary>
    /// Exposes a <see cref="Client"/> for editing from an explorer. Implements
    /// <see cref="IModelExplorer{Client}"/> to receive notifications from the
    /// configuration view.
    /// </summary>
    public class ClientSelectionViewModel : BindableBase, IModelExplorer<Client>
    {
        private IRegionManager _regions;
        private IModelConfiguration<Client> _configuration;
        public DelegateCommand ConfigureCommand { get; private set; }

        /// <summary>
        /// Captures region navigation resources and configures commands.
        /// </summary>
        /// <param name="p_regions">For region navigation.</param>
        /// <param name="p_configuration">Identifying the configuration view.</param>
        ClientSelectionViewModel(
            IRegionManager p_regions,
            IModelConfiguration<Client> p_configuration )
        {
            _regions = p_regions;
            _configuration = p_configuration;
            ConfigureCommand = new DelegateCommand(Configure);
            (this as IModelSubscriber<Client>).Updater = 
                            new DelegateCommand(OnClientChanged);
        }

        private Client _client;

        /// <summary>
        /// Target instance. Defines ID in setter.
        /// </summary>
        public Client Client
        {
            get { return _client; }
            set {
                _client = value;
                SetID();
            }
        }

        /// <summary>
        /// Synthesizes properties to create a unique string for the
        /// instance.
        /// </summary>
        private void SetID()
        {
            ClientID = 
                Client.FirstName + " " +
                Client.LastName + 
                " - " + 
                Client.DateOfBirth.ToString("yyyy-MM-dd");
        }

        private string _ClientID;
        /// <summary>
        /// Text representing the instance in the explorer.
        /// </summary>
        public string ClientID
        {
            get { return _ClientID; }
            set { SetProperty(ref _ClientID, value); }
        }

        /*=====================================================================
         ===== IModeExplorer implementation.
         ====================================================================*/

        ICommand IModelSubscriber<Client>.Updater { get; set; }
        IModelOrganizer IModelExplorer<Client>.Organizer { get; set; }
        Client IModelSubscriber<Client>.Instance => _client;

        /// <summary>
        /// Delegate to update <see cref="ClientID"/> when configuration
        /// view updates.
        /// </summary>
        public void OnClientChanged()
        {
            SetID();
        }

        /// <summary>
        /// Delegate to initiate configuration.
        /// </summary>
        public void Configure()
        {
            _regions.RequestNavigate(
                (this as IModelExplorer<Client>).Organizer.SelectRegion(
                                    IModelOrganizer.Purpose.Configure,
                                    typeof(Client)),
                _configuration.Uri, 
                new NavigationParameters()
                {
                    {   IModelExplorer<Client>.Key,
                        this as IModelExplorer<Client> }
                } );
        }
    }
}
