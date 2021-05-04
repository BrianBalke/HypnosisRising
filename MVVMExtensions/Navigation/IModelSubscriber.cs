using System.Windows.Input;
/// <summary>
/// The Navigation namespace defines mechanisms for coordination of model
/// definition across PRISM modules. The goal is to allow holders of
/// configurable instances to discover View based solely upon the instance
/// type.
/// 
/// As designed, the following strategies are supported:
/// <list type="bullet">
/// <item>Master/detail coordination.</item>
/// <item>Embedded user controls for aggregate model classes.</item>
/// </list>
/// As defined in PRISM, the item to be configured is held by a ViewModel.
/// When the Model instance contains collections of sub-items, the ViewModel
/// resolves <see cref="IModelExploration{T}"/> for the type. To configure 
/// an instance, the ViewModel resolves <see cref="IModelConfiguration{T}"/> 
/// for the type. Both are instantiated on the IModule instance for the 
/// assembly, which publishes the navigation Uri for the view.
/// 
/// The invoking ViewModel uses region navigation to populate the view. The
/// invoker is expected to understand the organization of its View. When invoking
/// from an IModelExploration context, the NavigationParameters are populated with
/// an instance of <see cref="IModelExplorer{T}"/>, which provides a call-back to 
/// the invoker ViewModel to update the item description (as necessary) when 
/// values are captured. When invoking from an IModelConfiguration context, a 
/// <see cref="ModelSubForm{T}"/> proxy is passed to coordinate value capture when 
/// a save command is activated by the user.
/// </summary>
namespace HypnosisRising.MVVMExtensions.Navigation
{
    /// <summary>
    /// Defines an interface to be populated by an invoking ViewModel to 
    /// identify the instance to be configured, along with a notification
    /// callback after values are captured.
    /// </summary>
    /// <typeparam name="T">Model type.</typeparam>
    /// <seealso cref="IModelExplorer"/>
    /// <seealso cref="ModelSubForm"/>
    public interface IModelSubscriber<T>
    {
        /// <summary>
        /// Target instance.
        /// </summary>
        public T Instance { get; }
        /// <summary>
        /// Command to coordinate data capture.
        /// </summary>
        ICommand Updater { get; set; }
    }
}
