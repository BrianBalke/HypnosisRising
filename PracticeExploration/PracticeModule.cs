using HypnosisRising.CaseWork;
using HypnosisRising.MVVMExtensions.Navigation;
using HypnosisRising.PracticeExploration.ViewModels;
using HypnosisRising.PracticeExploration.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace HypnosisRising.PracticeExploration
{
    /// <summary>
    /// Module that registers the ability to explore and configure
    /// <see cref="Practice"/> records.
    /// </summary>
    public class PracticeModule : 
        IModule, 
        IModelExploration<Practice>,
        IModelConfiguration<Practice>
    {
        string IModelExploration<Practice>.Uri =>
                        "HypnosisRising.PracticeExploration.Views.PracticeExplorer";
        string IModelConfiguration<Practice>.Uri =>
                        "HypnosisRising.PracticeExploration.Views.PracticeForm";

        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry p_container)
        {
            p_container.RegisterInstance<IModelExploration<Practice>>(this);
            p_container.RegisterInstance<IModelConfiguration<Practice>>(this);

            p_container.RegisterForNavigation<PracticeExplorer, PracticeExplorerViewModel>(
                            (this as IModelExploration<Practice>).Uri);
            p_container.RegisterForNavigation<PracticeForm, PracticeFormViewModel>(
                            (this as IModelConfiguration<Practice>).Uri);
        }
    }
}