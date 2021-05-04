using HypnosisRising.CaseWork;
using HypnosisRising.MVVMExtensions.Navigation;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Input;

namespace HypnosisRising.CaseRecorder.ViewModels
{
    /// <summary>
    /// Establishes initial data context and comands for storage. Controls 
    /// assignment of views to the regions in <see cref="Views.MainWindow"/>.
    /// </summary>
    /// <remarks>
    /// Provides <see cref="PopulateContent"/> to initialize the model.
    /// Projects the content into the explorer region, propagating <see 
    /// cref="SelectRegion"/> to control allocation of additional views 
    /// to regions in the main window, currently:
    /// <list type="bullet">
    /// <item>Exlporer region</item>
    /// <item>Configure region</item>
    /// </list>.
    /// 
    /// Publishes the Window title.
    /// </remarks>
    /// <seealso cref="IModelOrganizer"/>
    /// <seealso cref="IModelExplorer{T}"/>
    public class MainWindowViewModel : 
            BindableBase,  
            IModelOrganizer,
            IModelExplorer<Practice>
    {
        private IContainerProvider _provider;
        private IRegionManager _regions;
        public DelegateCommand StorePracticeCommand { get; private set; }

        /// <summary>
        /// Establishes context for propagation of region allocation to embedded
        /// views, and commands defined on the menu bar:
        /// <list type="bullet">
        /// <item>Practice Store</item>
        /// <item>Case Store</item>
        /// </list>
        /// </summary>
        /// <param name="p_provider">To access model explorer views.</param>
        /// <param name="p_regions">For PRISM navigation.</param>
        public MainWindowViewModel(
            IContainerProvider p_provider,
            IRegionManager p_regions )
        {
            _provider = p_provider;
            _regions = p_regions;

            (this as IModelExplorer<Practice>).Updater = new DelegateCommand(OnPracticeUpdated);
            (this as IModelExplorer<Practice>).Organizer = this as IModelOrganizer;

            StorePracticeCommand = new DelegateCommand(StorePractice);
        }

        private string _title = "Hypnosis Rising Case Recorder";
        /// <summary>
        /// Window title.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// Establishes intiial data context.
        /// </summary>
        /// <remarks>
        /// Attempts first to the practice file; otherwise prompts for a case file
        /// to load and switches to read-only mode.
        /// </remarks>
        public void PopulateContent()
        {
            if (_practice is null)
            {
                _practice = LoadPractice();

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
                     _regions.RequestNavigate(
                                SelectRegion(IModelOrganizer.Purpose.Explore,
                                    typeof(Practice)),
                                exploration.Uri,
                                new NavigationParameters
                                {
                                    { 
                                        IModelExplorer<Practice>.Key, 
                                        this as IModelExplorer<Practice> }
                                }
                            );
                }
            }
        }

        /*=====================================================================
         *===== Practice serialization.
         *===================================================================*/

        /// <summary>
        /// Attempts to load a Practice using DataContractSerialization.
        /// </summary>
        /// <returns><code>null</code> if practice file is not found.</returns>
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

        /// <summary>
        /// Saves the current <see cref="Practice"/> to disk.
        /// </summary>
        private void StorePractice()
        {
            var fileName = GetPracticeFile();

            try
            {
                using FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                DataContractSerializer dcs =
                    new DataContractSerializer(
                            typeof(Practice),
                            new DataContractSerializerSettings()
                            {
                                PreserveObjectReferences = true
                            });
                dcs.WriteObject(fs,_practice);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Provides the path to the project file.
        /// </summary>
        /// <returns>Stored in user's AppData folder, under HypnosisRising.</returns>
        private string GetPracticeFile()
        {
            return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    @"HypnosisRising\Practice.xml");
        }

        /*=====================================================================
         *===== IModelExplorer<Practie>
         *===================================================================*/

        Practice _practice = null;
        Practice IModelSubscriber<Practice>.Instance => _practice;
        ICommand IModelSubscriber<Practice>.Updater { get; set; }
        IModelOrganizer IModelExplorer<Practice>.Organizer { get; set; }

        /// <summary>
        /// To satisfy <see cref="IModelExplorer"/> requirements.
        /// </summary>
        private void OnPracticeUpdated()
        { }

        /// <summary>
        /// Allocates model objects to regions in <see cref="MainWindow"/>
        /// according to the view purpose.
        /// </summary>
        /// <param name="p_ePurpose"></param>
        /// <param name="p_modelType"></param>
        /// <returns></returns>
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
