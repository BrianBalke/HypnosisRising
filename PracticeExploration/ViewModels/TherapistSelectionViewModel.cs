using HypnosisRising.CaseWork.Roles;
using HypnosisRising.MVVMExtensions.Navigation;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.PracticeExploration.ViewModels
{
    public class TherapistSelectionViewModel : BindableBase, IModelExplorer<Therapist>
    {
        private IRegionManager _regions;
        private IModelConfiguration<Therapist> _configuration;
        public DelegateCommand ConfigureCommand { get; private set; }

        TherapistSelectionViewModel(
            IRegionManager p_regions,
            IModelConfiguration<Therapist> p_configuration )
        {
            _regions = p_regions;
            _configuration = p_configuration;
            ConfigureCommand = new DelegateCommand(Configure);
        }

        private Therapist therapist;

        public Therapist Therapist
        {
            get { return therapist; }
            set { 
                therapist = value;
                SetID();
            }
        }

        private void SetID()
        {
            TherapistID = 
                therapist.FirstName + 
                therapist.LastName + 
                " - " + 
                therapist.Certificate;
        }

        private string _therapistID;
        public string TherapistID
        {
            get { return _therapistID; }
            set { SetProperty(ref _therapistID, value); }
        }

        public IModelSubscriber<Therapist>.Subscription Updater => OnTherapistChanged;

        IModelOrganizer IModelExplorer<Therapist>.Organizer { get; set; }

        Therapist IModelSubscriber<Therapist>.Instance => therapist;

        IModelSubscriber<Therapist>.Subscription IModelSubscriber<Therapist>.Updater => OnTherapistChanged;

        public void OnTherapistChanged()
        {
            SetID();
        }

        public void Configure()
        {
            var p = new NavigationParameters();
            p.Add(
                IModelExplorer<Therapist>.Key, 
                this as IModelExplorer<Therapist>);
            _regions.RequestNavigate(
                (this as IModelExplorer<Therapist>).Organizer.SelectRegion(
                                    IModelOrganizer.Purpose.Configure,
                                    typeof(Therapist)),
                _configuration.Uri, p); ;
        }
    }
}
