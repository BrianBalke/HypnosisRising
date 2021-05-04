using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HypnosisRising.MVVMExtensions.Navigation
{
    /// <summary>
    /// Negotiates the interaction between a form and subform embedded
    /// in a region.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ModelSubForm<T> : IModelSubscriber<T>
    {
        public const string KeyRoot = "MVVMSubForm";
        /// <summary>
        /// Key used in <see cref="Prism.Regions.NavigationParameters"/>
        /// transmission to subform.
        /// </summary>
        public static string Key { get => KeyRoot + "." + typeof(T).ToString(); }

        /// <summary>
        /// Content to be presented in subform.
        /// </summary>
        public T Instance { get; set; }

        /// <summary>
        /// Command to be defined by subform when data capture is commanded.
        /// </summary>
        public ICommand Updater { get; set; }
    }
}
