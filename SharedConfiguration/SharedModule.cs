using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using HypnosisRising.SharedConfiguration.ViewModels;
using HypnosisRising.SharedConfiguration.Views;
using HypnosisRising.CaseWork.Common;
using HypnosisRising.MVVMExtensions.Navigation;

namespace HypnosisRising.SharedConfiguration
{
    /// <summary>
    /// Module that registers the ability to configure records from the
    /// <see cref="HypnosisRising.CaseWork.Common"/> namespace:
    /// <list type="bullet">
    /// <item><see cref="Location"/></item>
    /// </list>
    /// </summary>
    public class SharedModule : IModule, IModelConfiguration<Location>
    {
        string IModelConfiguration<Location>.Uri => 
                    "HypnosisRising.SharedConfiguration.Views.LocationForm";

        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry p_container)
        {
            p_container.RegisterInstance<IModelConfiguration<Location>>(this);
            p_container.RegisterForNavigation<LocationForm, LocationFormViewModel>(
                            (this as IModelConfiguration<Location>).Uri);
        }
    }
}