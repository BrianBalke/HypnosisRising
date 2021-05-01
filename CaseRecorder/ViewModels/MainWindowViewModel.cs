using HypnosisRising.CaseWork;
using HypnosisRising.MVVMExtensions.Navigation;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace HypnosisRising.CaseRecorder.ViewModels
{
    public class MainWindowViewModel : 
            BindableBase,  
            IModelOrganizer,
            IModelExplorer<Practice>
    {
        private IContainerProvider _provider;
        private IRegionManager _regions;

        public MainWindowViewModel(
            IContainerProvider p_provider,
            IRegionManager p_regions )
        {
            _provider = p_provider;
            _regions = p_regions;
        }

        private string _title = "Hypnosis Rising Case Recorder";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public void PopulateContent()
        {
            if (_practice is null)
            {
                _practice = LoadPractice();

                // ***** Hack until we have case file lookup.
                if (_practice is null)
                {
                    _practice = new Practice();
                    _practice.Name = "Cloud Nine Hypnotherapy";
                }

                if (_practice is null)
                {
                    // No practice file implies this is a client.
                    // Prompt for case file.
                }
                else
                {
                    // Allow therapist to navigate the practice.
                    IModelExploration<Practice> exploration =
                        _provider.Resolve<IModelExploration<Practice>>();
                    NavigationParameters p = new NavigationParameters();
                    (this as IModelExplorer<Practice>).Organizer = this as IModelOrganizer;
                    p.Add(IModelExplorer<Practice>.Key, this as IModelExplorer<Practice>);
                    _regions.RequestNavigate(
                                SelectRegion(IModelOrganizer.Purpose.Explore,
                                    typeof(Practice)),
                               exploration.Uri,
                                p);
                }
            }
        }

        IModelOrganizer _organizer;
        IModelOrganizer IModelExplorer<Practice>.Organizer { get => _organizer; set => _organizer = value; }

        Practice IModelSubscriber<Practice>.Instance => _practice;

        IModelSubscriber<Practice>.Subscription IModelSubscriber<Practice>.Updater { get => OnPracticeUpdated; }

        Practice _practice = null;

        private Practice LoadPractice()
        {
            var fileName = GetPracticeFile();

            if (File.Exists(fileName))
            {
                try
                {
                    using FileStream fs = new FileStream(fileName, FileMode.Open);
                    DataContractSerializer dcs =
                        new DataContractSerializer(
                                typeof(Practice),
                                new DataContractSerializerSettings()
                                {
                                    PreserveObjectReferences = true
                                });
                    return dcs.ReadObject(fs) as Practice;
                }
                catch (Exception ex) {
                    
                }
            }

            return null;
        }

        private string GetPracticeFile()
        {
            return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "Practice.xml");
        }

        private void OnPracticeUpdated()
        { }

        public string SelectRegion(IModelOrganizer.Purpose p_ePurpose, Type p_modelType)
        {
            if  (p_ePurpose == IModelOrganizer.Purpose.Explore)
            {
                if ((p_modelType == typeof(Practice)) ||
                    (p_modelType == typeof(Case)))
                {
                    return "ExploreRegion";
                }
            }

            return "ConfigureRegion";
        }
    }
}
