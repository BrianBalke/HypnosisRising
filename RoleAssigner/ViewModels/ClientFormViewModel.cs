using HypnosisRising.CaseWork.Common;
using HypnosisRising.CaseWork.Roles;
using HypnosisRising.MVVMExtensions.Navigation;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace HypnosisRising.RoleAssigner.ViewModels
{
    /// <summary>
    /// Supports configuration of a <see cref="Client"/> as a specialization
    /// of <see cref="Contact"/>.
    /// </summary>
    /// <remarks>
    /// <see cref="Client"/> aggregates two contacts, for spouse and emergency,
    /// which are exposed through <see cref="ContactFormViewModel"/>, along with
    /// the fields of the base class. <see cref="Client"/> also aggregates a
    /// location, which is exposed through model nevigation.
    /// 
    /// The <see cref="UpdateCommand"/> coordinates capture from the embedded
    /// forms, and notifies the invoker to reflect changes.
    /// </remarks>
    public class ClientFormViewModel :
                    BindableBase,
                    INavigationAware
    {
        private IRegionManager _regions;
        private IModelConfiguration<Location> _locForm;

        /// <summary>
        /// Captures region navigation resources and configures commands.
        /// </summary>
        /// <param name="p_regions">For region navigation.</param>
        /// <param name="p_configuration">For embedding of a 
        /// <see cref="Location"/> form.</param>
        public ClientFormViewModel(
            IRegionManager p_regions,
            IModelConfiguration<Location> p_configuration )
        {
            _regions = p_regions;
            _locForm = p_configuration;
            UpdateCommand = new DelegateCommand(OnUpdate);

        }

        ContactFormViewModel contactVM = new ContactFormViewModel();
        /// <summary>
        /// Wrapper for the base class content.
        /// </summary>
        public ContactFormViewModel ContactVM { get => contactVM; }
        ContactFormViewModel partnerVM = new ContactFormViewModel();
        /// <summary>
        /// Wrapper for spouse.
        /// </summary>
        public ContactFormViewModel PartnerVM { get => partnerVM; }
        ContactFormViewModel emergencyVM = new ContactFormViewModel();
        /// <summary>
        /// Wrapper for emergency contact.
        /// </summary>
        public ContactFormViewModel EmergencyVM { get => emergencyVM; }

        private Client client;
        /// <summary>
        /// Target instance. The setter, which should be invoked only upon
        /// entry:
        /// <list type="bullet">
        /// <item>transfers properties to local storage</item>
        /// <item>assigns instances to the aggregated view models</item>
        /// <item>uses model navigation to populate the 
        /// <code>ClientLocation</code> region with a form.</item>
        /// </list>
        /// </summary>
        public Client Client
        {
            get { return client; }
            set
            {
                client = value;
                contactVM.Contact = client;

                DateOfBirth = client.DateOfBirth;
                BillingRate = client.BillingRate;

                partnerVM.Contact = client.Partner;
                emergencyVM.Contact = client.EmergencyContact;

                if (!(_regions is null))
                {
                    ShowHomeAddress();
                }
            }
        }

        private DateTime dateOfBirth;
        /// <summary>
        /// Two-way binding for date of birth.
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { SetProperty(ref dateOfBirth, value); }
        }
        private int billingRate;
        /// <summary>
        /// Two-way binding for billing rate.
        /// </summary>
        public int BillingRate
        {
            get { return billingRate; }
            set { SetProperty(ref billingRate, value); }
        }

        /// <summary>
        /// Command that allows user to transfer changes to the target
        /// instance.
        /// </summary>
        public DelegateCommand UpdateCommand { get; private set; }

        /// <summary>
        /// Tranfsers local values to the instance, captures changes in
        /// embedded forms, and updates the invoker.
        /// </summary>
        public void OnUpdate()
        {
            client.DateOfBirth = DateOfBirth;
            client.BillingRate = BillingRate;

            contactVM.OnUpdate();
            partnerVM.OnUpdate();
            emergencyVM.OnUpdate();

            if (!(_regions is null))
            {
                _homeConfig.Updater.Execute(null);
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
            IModelExplorer<Client> explorer = RetrieveExplorer(navigationContext);
            if (!(explorer is null))
            {
                Client = explorer.Instance;
                _explorerUpdater = explorer.Updater;
            }
        }

        /// <summary>
        /// Signals to re-use existing form. Assumes the invoker is unchanged.
        /// </summary>
        /// <param name="navigationContext"></param>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            IModelExplorer<Client> explorer = RetrieveExplorer(navigationContext);
            // Is this a request for a therapist?
            if (explorer is null) return false;
            // Is this first entry to this form?
            if (client is null) return false;
            Client = explorer.Instance;
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
        public IModelExplorer<Client> RetrieveExplorer(
                NavigationContext context)
        {
            if (context.Parameters.ContainsKey(IModelExplorer<Client>.Key))
            {
                return context.Parameters.
                        GetValue<IModelExplorer<Client>>(
                            IModelExplorer<Client>.Key);
            }

            return null;
        }


        /*=====================================================================
         ===== Model navigation.
         ====================================================================*/

        /// <summary>
        /// Region in the form.
        /// </summary>
        const string HomeRegion = "ClientHome";
        /// <summary>
        /// Coordination context.
        /// </summary>
        private ModelSubForm<Location> _homeConfig = new ModelSubForm<Location>();

        /// <summary>
        /// Presents location form for editing of the home address.
        /// </summary>
        private void ShowHomeAddress()
        {
            _homeConfig.Instance = client.HomeAddress;
            _regions.RequestNavigate(
                HomeRegion,
                _locForm.Uri,
                new NavigationParameters()
                {
                    { ModelSubForm<Location>.Key,
                      _homeConfig }
                } );
        }
    }
}
