using HypnosisRising.CaseWork.Common;
using HypnosisRising.CaseWork.Roles;
using HypnosisRising.MVVMExtensions.Navigation;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HypnosisRising.RoleAssigner.ViewModels
{
    public class TherapistFormViewModel : 
                    BindableBase, 
                    INavigationAware
    {
        private IRegionManager _regions;
        private IModelConfiguration<Location> _locForm;

        public TherapistFormViewModel(
            IRegionManager p_regions,
            IModelConfiguration<Location> p_configuration)
        {
            _regions = p_regions;
            _locForm = p_configuration;
        }

        private Therapist _therapist;

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
                    ShowOfficeAddress(_therapist.OfficeAddress);
                    ShowMailingAddress(_therapist.MailingAddress);
                }
            }
        }

        ContactFormViewModel contactVM = new ContactFormViewModel();
        public ContactFormViewModel ContactVM { get => contactVM; }

        private bool _officeIsMailing;
        public bool OfficeIsMailing
        {
            get { return _officeIsMailing; }
            set { 
                SetProperty(ref _officeIsMailing, value);
                ShowMailing = !_officeIsMailing;
            }
        }
        private bool _showMailing;
        public bool ShowMailing
        {
            get { return _showMailing; }
            set { SetProperty(ref _showMailing, value); }
        }
        private string _certifier;
        public string Certifier
        {
            get { return _certifier; }
            set { SetProperty(ref _certifier, value); }
        }
        private string _certificate;
        public string Certificate
        {
            get { return _certificate; }
            set { SetProperty(ref _certificate, value); }
        }
        private string _insurer;
        public string Insurer
        {
            get { return _insurer; }
            set { SetProperty(ref _insurer, value); }
        }
        private string _policyNumber;
        public string PolicyNumber
        {
            get { return _policyNumber; }
            set { SetProperty(ref _policyNumber, value); }
        }


        private DelegateCommand _updateCmd;
        public DelegateCommand UpdateCommand =>
                    _updateCmd ??= new DelegateCommand(OnUpdate);

        public Location Instance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void OnUpdate()
        {
            _therapist.OfficeIsMailing = OfficeIsMailing;
            _therapist.Certifier = Certifier;
            _therapist.Certificate = Certificate;
            _therapist.Insurer = Insurer;
            _therapist.PolicyNumber = PolicyNumber;

            if (!(_regions is null))
            {
                _officeConfig.OnUpdating(EventArgs.Empty);
                _mailConfig.OnUpdating(EventArgs.Empty);
            }

            contactVM.OnUpdate();
        }



        IModelExplorer<Therapist>.Subscription _updater;

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            IModelExplorer<Therapist> explorer = RetrieveExplorer(navigationContext);
            if (explorer is null) return false;
                Therapist therapist = explorer.Instance;
            if (_therapist is null) return false;
            return _therapist != therapist;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            IModelExplorer<Therapist> explorer = RetrieveExplorer(navigationContext);
            if (!(explorer is null))
            {
                Therapist = explorer.Instance;
                _updater = explorer.Updater;
            }

        }

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

        const string OfficeRegion = "TherapistOffice";
        private ModelSubForm<Location> _officeConfig = new ModelSubForm<Location>();

        private void ShowOfficeAddress(
            Location    p_Office )
        {
            _officeConfig.Instance = _therapist.OfficeAddress;
            var p = new NavigationParameters();
            p.Add(
                IModelConfigurer<Location>.Key,
                _officeConfig);
            _regions.RequestNavigate(
                OfficeRegion,
                _locForm.Uri, p);
        }

        const string MailRegion = "TherapistMail";
        private ModelSubForm<Location> _mailConfig = new ModelSubForm<Location>();

        private void ShowMailingAddress(
            Location p_Mail)
        {
            _officeConfig.Instance = _therapist.OfficeAddress;
            var p = new NavigationParameters();
            p.Add(
                IModelConfigurer<Location>.Key,
                this as IModelExplorer<Therapist>);
            _regions.RequestNavigate(
                MailRegion,
                _locForm.Uri, p);
        }
    }
}
