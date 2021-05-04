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
    /// Exposes a <see cref="Therapist"/> for editing from an explorer. Implements
    /// <see cref="IModelExplorer{Therapist}"/> to receive notifications from the
    /// configuration view.
    /// </summary>
    public class TherapistSelectionViewModel : BindableBase, IModelExplorer<Therapist>
    {
        private IRegionManager _regions;
        private IModelConfiguration<Therapist> _configuration;

        /// <summary>
        /// Captures region navigation resources and configures commands.
        /// </summary>
        /// <param name="p_regions">For region navigation.</param>
        /// <param name="p_configuration">Identifying the configuration view.</param>
        TherapistSelectionViewModel(
            IRegionManager p_regions,
            IModelConfiguration<Therapist> p_configuration )
        {
            _regions = p_regions;
            _configuration = p_configuration;
            ConfigureCommand = new DelegateCommand(Configure);
            (this as IModelSubscriber<Therapist>).Updater = 
                            new DelegateCommand(OnTherapistChanged);
        }

        private Therapist therapist;

        /// <summary>
        /// Target instance. Defines ID in setter.
        /// </summary>
        public Therapist Therapist
        {
            get { return therapist; }
            set { 
                therapist = value;
                SetID();
            }
        }

        /// <summary>
        /// Synthesizes properties to create a unique string for the
        /// instance.
        /// </summary>
        private void SetID()
        {
            TherapistID = 
                therapist.FirstName + " " +
                therapist.LastName + 
                " - " + 
                therapist.Certificate;
        }

        private string _therapistID;
        /// <summary>
        /// Text representing the instance in the explorer.
        /// </summary>
        public string TherapistID
        {
            get { return _therapistID; }
            set { SetProperty(ref _therapistID, value); }
        }

        public DelegateCommand ConfigureCommand { get; private set; }

        /*=====================================================================
         ===== IModeExplorer implementation.
         ====================================================================*/

        ICommand IModelSubscriber<Therapist>.Updater { get; set; }
        IModelOrganizer IModelExplorer<Therapist>.Organizer { get; set; }
        Therapist IModelSubscriber<Therapist>.Instance => therapist;

        /// <summary>
        /// Delegate to update <see cref="TherapistID"/> when configuration
        /// view updates.
        /// </summary>
        public void OnTherapistChanged()
        {
            SetID();
        }

        /// <summary>
        /// Delegate to initiate configuration.
        /// </summary>
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
