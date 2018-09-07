using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrefixionSystem.DataModule
{
    public class TEventArgs<T> : EventArgs
    {
        public TEventArgs(T t)
        {
            Data = t;
        }

        public T Data { get; set; }
    }
}
