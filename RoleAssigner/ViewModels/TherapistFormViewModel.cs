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
    /// Supports configuration of a <see cref="Therapist"/> as a specialization
    /// of <see cref="Contact"/>.
    /// </summary>
    /// <remarks>
    /// <see cref="Threrapist"/> aggregates <see cref="Location"/> as office and
    /// mailing addresses, which are published to regions by model nevigation.
    /// 
    /// The <see cref="UpdateCommand"/> coordinates capture from the embedded
    /// forms, and notifies the invoker to reflect changes.
    /// </remarks>
    public class TherapistFormViewModel : 
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
        public TherapistFormViewModel(
            IRegionManager p_regions,
            IModelConfiguration<Location> p_configuration)
        {
            _regions = p_regions;
            _locForm = p_configuration;
            UpdateCommand = new DelegateCommand(OnUpdate);
        }

        private Therapist _therapist;
        /// <summary>
        /// Wrapped instance. The setter should be called only during 
        /// navigation. Specific properties are cached locally; inherited
        /// properties are published via <see cref="ContactFormViewModel"/>.
        /// Aggregated locations are presented via model navigation.
        /// </summary>
        public Therapist Therapist
        {
            get { return _therapist; }
            set { 
                _therapist = value;
                OfficeIsMailing = _therapist.OfficeIsMailing;
                Certifier = _therapist.Certifier;
                Certificate = _therapist.Certificate;
                Insurer = _therapist.Insurer;
                PolicyNumber = _therapist.PolicyNumber;

                contactVM.Contact = _therapist;

                if (!(_regions is null))
                {
                    ShowOfficeAddress();
                    ShowMailingAddress();
                }
            }
        }

        ContactFormViewModel contactVM = new ContactFormViewModel();
        /// <summary>
        /// Wrapper for inherited properties.
        /// </summary>
        public ContactFormViewModel ContactVM { get => contactVM; }

        private bool _officeIsMailing;
        /// <summary>
        /// Two-way binding for OfficeIsMailing.
        /// </summary>
        public bool OfficeIsMailing
        {
            get { return _officeIsMailing; }
            set { 
                SetProperty(ref _officeIsMailing, value);
                ShowMailing = !_officeIsMailing;
            }
        }
        private bool _showMailing;
        /// <summary>
        /// Negation of <see cref="OfficeIsMailing"/> to control visibility
        /// of the mailing address content control.
        /// </summary>
        public bool ShowMailing
        {
            get { return _showMailing; }
            set { SetProperty(ref _showMailing, value); }
        }
        private string _certifier;
        /// <summary>
        /// Two-way binding for certifier.
        /// </summary>
        public string Certifier
        {
            get { return _certifier; }
            set { SetProperty(ref _certifier, value); }
        }
        private string _certificate;
        /// <summary>
        /// Two-way binding for certificate.
        /// </summary>
        public string Certificate
        {
            get { return _certificate; }
            set { SetProperty(ref _certificate, value); }
        }
        private string _insurer;
        /// <summary>
        /// Two-way binding for insurer.
        /// </summary>
        public string Insurer
        {
            get { return _insurer; }
            set { SetProperty(ref _insurer, value); }
        }
        private string _policyNumber;
        /// <summary>
        /// Two-way binding for policy number.
        /// </summary>
        public string PolicyNumber
        {
            get { return _policyNumber; }
            set { SetProperty(ref _policyNumber, value); }
        }

        /// <summary>
        /// Command to trigger trnasfer of cached values to the instance.
        /// Cascades to embedded location forms and up to the explorer
        /// </summary>
        public DelegateCommand UpdateCommand { get; private set; }

        /// <summary>
        /// Tranfsers local values to the instance, captures changes in
        /// embedded forms, and updates the invoker.
        /// </summary>
        public void OnUpdate()
        {
            _therapist.OfficeIsMailing = OfficeIsMailing;
            _therapist.Certifier = Certifier;
            _therapist.Certificate = Certificate;
            _therapist.Insurer = Insurer;
            _therapist.PolicyNumber = PolicyNumber;

            contactVM.OnUpdate();

            if (!(_regions is null))
            {
                _officeConfig.Updater.Execute(null);
                _mailConfig.Updater.Execute(null);
                _explorerUpdater.Execute(null);
            }
        }


        /*=====================================================================
         ===== INavigationAware implementation.
         ====================================================================*/

        /// <summary>
        /// Command to update the invoking explorer.
        /// </summary>
        ICommand _explorerUpdater;

        /// <summary>
        /// Captures configuration context from invoker.
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            IModelExplorer<Therapist> explorer = RetrieveExplorer(navigationContext);
            if (!(explorer is null))
            {
                Therapist = explorer.Instance;
                _explorerUpdater = explorer.Updater;
            }

        }

        /// <summary>
        /// Signals to re-use existing form. Assumes the invoker is unchanged.
        /// </summary>
        /// <param name="navigationContext"></param>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            IModelExplorer<Therapist> explorer = RetrieveExplorer(navigationContext);
            // Is this a request for a therapist?
            if (explorer is null) return false;
            // Is this first entry to this form?
            if (_therapist is null) return false;
            Therapist = explorer.Instance;
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
        public IModelExplorer<Therapist> RetrieveExplorer(
                NavigationContext context )
        {
            if (context.Parameters.ContainsKey(IModelExplorer<Therapist>.Key))
            {
                return context.Parameters.
                        GetValue<IModelExplorer<Therapist>>(
                            IModelExplorer<Therapist>.Key);
            }

            return null;
        }


        /*=====================================================================
         ===== Model navigation.
         ====================================================================*/

        /// <summary>
        /// Region for office address.
        /// </summary>
        const string OfficeRegion = "TherapistOffice";
        private ModelSubForm<Location> _officeConfig = new ModelSubForm<Location>();

        /// <summary>
        /// Presents location form for editing of the office address.
        /// </summary>
        private void ShowOfficeAddress()
        {
            _officeConfig.Instance = _therapist.OfficeAddress;
            _regions.RequestNavigate(
                OfficeRegion,
                _locForm.Uri,
                new NavigationParameters()
                {
                    {   ModelSubForm<Location>.Key,
                        _officeConfig }
                } );
        }

        /// <summary>
        /// Region for mailing address.
        /// </summary>
        const string MailRegion = "TherapistMail";
        private ModelSubForm<Location> _mailConfig = new ModelSubForm<Location>();

        /// <summary>
        /// Presents location form for editing of the mailing address.
        /// </summary>
        private void ShowMailingAddress()
        {
            _mailConfig.Instance = _therapist.OfficeAddress;
            _regions.RequestNavigate(
                MailRegion,
                _locForm.Uri, 
                new NavigationParameters()
                {
                    {  ModelSubForm<Location>.Key,
                       _mailConfig }
                } );
        }
    }
}
