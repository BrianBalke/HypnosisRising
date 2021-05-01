using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.MVVMExtensions.Navigation
{
    public class ModelSubForm<T>
    {
        public T Instance { get; set; }
        public event EventHandler Updating;
        public virtual void OnUpdating(EventArgs e)
        {
            EventHandler handler = Updating;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
