using HypnosisRising.CaseRecorder.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace HypnosisRising.CaseRecorder
{
    /// <summary>
    /// Marshalls PRISM resources necessary for content definition.
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// Default implementation.
        /// </summary>
        /// <returns><see cref="MainWindow"/> instance.</returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// Void.
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        /// <summary>
        /// Configures loading from the Modules subfolder.
        /// </summary>
        /// <returns><see cref="DirectoryModuleCatalog"/></returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        }
    }
}