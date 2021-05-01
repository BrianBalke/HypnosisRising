using HypnosisRising.CaseWork;
using HypnosisRising.MVVMExtensions.Navigation;
using HypnosisRising.PracticeExploration.ViewModels;
using HypnosisRising.PracticeExploration.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace HypnosisRising.PracticeExploration
{
    public class PracticeModule : IModule, IModelExploration<Practice>
    {
        string IModelExploration<Practice>.Uri =>
                        "HypnosisRising.PracticeExploration.Views.PracticeExplorer";

        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry p_container)
        {
            p_container.RegisterInstance<IModelExploration<Practice>>(this);
            p_container.RegisterForNavigation<PracticeExplorer, PracticeExplorerViewModel>(
                            (this as IModelExploration<Practice>).Uri);
        }
    }
}