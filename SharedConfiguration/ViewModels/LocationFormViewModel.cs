using HypnosisRising.CaseWork.Common;
using HypnosisRising.MVVMExtensions.Navigation;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HypnosisRising.SharedConfiguration.ViewModels
{
    /// <summary>
    /// Supports configuration of a <see cref="Location"/>
    /// </summary>
    /// <remarks>
    /// Uses the US mapping for District (City), Region (State), and 
    /// MailCode (Zip)
    /// </remarks>
    public class LocationFormViewModel :
            BindableBase,
            INavigationAware
    {
        private DelegateCommand _updateCmd;

        /// <summary>
        /// Command initialization.
        /// </summary>
        public LocationFormViewModel()
        {
            _updateCmd = new DelegateCommand(OnUpdate);
        }

        private Location _location;

        /// <summary>
        /// Wrapped instance. Setter is invoked in navigation, and caches
        /// properties.
        /// </summary>
        public Location Location
        {
            get { return _location; }
            set { 
                _location = value;

                Street1 = _location.Street1;
                Street2 = _location.Street2;
                City = _location.District;
                State = _location.Region;
                Zip = _location.MailCode;
                Country = _location.Country;
            }
        }

        /// <summary>
        /// Command to trigger update of instance with cached properties.
        /// </summary>
        public DelegateCommand UpdateCommand => _updateCmd;

        /// <summary>
        /// Updates instance with cached properties.
        /// </summary>
        void OnUpdate()
        {
            _location.Street1 = Street1;
            _location.Street2 = Street2;
            _location.District = City;
            _location.Region = State;
            _location.MailCode = Zip;
            _location.Country = Country;
        }

        private string _street1;
        /// <summary>
        /// Two-way binding for Street1.
        /// </summary>
        public string Street1
        {
            get { return _street1; }
            set { SetProperty(ref _street1, value); }
        }
        private string _street2;
        /// <summary>
        /// Two-way binding for Street2.
        /// </summary>
        public string Street2
        {
            get { return _street2; }
            set { SetProperty(ref _street2, value); }
        }
        private string _city;
        /// <summary>
        /// Two-way binding for City.
        /// </summary>
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }
        private string _state;
        /// <summary>
        /// Two-way binding for State.
        /// </summary>
        public string State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }
        private string _zip;
        /// <summary>
        /// Two-way binding for Zip.
        /// </summary>
        public string Zip
        {
            get { return _zip; }
            set { SetProperty(ref _zip, value); }
        }
        private string _country;
        /// <summary>
        /// Two-way binding for Country.
        /// </summary>
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }


        /*=====================================================================
         ===== INavigationAware implementation.
         ====================================================================*/

        /// <summary>
        /// Captures configuration context from invoker, providing an updater
        /// for use when data capture is requested by the host.
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            ModelSubForm<Location> sub = RetrieveSubForm(navigationContext);
            if (null != sub)
            {
                Location = sub.Instance;
                sub.Updater = _updateCmd;
            }
        }

        /// <summary>
        /// Signals to re-use existing form. Assumes the invoker is unchanged.
        /// </summary>
        /// <param name="navigationContext"></param>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            ModelSubForm<Location> sub = RetrieveSubForm(navigationContext);
            // Is this a Location request?
            if (null == sub) return false;
            // First entry to form?
            if (null == _location) return false;
            
            Location = sub.Instance;
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
        public ModelSubForm<Location> RetrieveSubForm(
                NavigationContext context)
        {
            if (context.Parameters.ContainsKey(ModelSubForm<Location>.Key))
            {
                return context.Parameters.
                        GetValue<ModelSubForm<Location>>(
                            ModelSubForm<Location>.Key);
            }

            return null;
        }
    }
}
