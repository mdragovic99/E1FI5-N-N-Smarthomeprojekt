using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalClient.ViewModelBase
{
    public interface IViewModel : INotifyPropertyChanged
    {
    }

    public interface IViewModel<TModel> : INotifyPropertyChanged
    {
        [Browsable(false)]
        [Bindable(false)]
        TModel Model { get; set; }
    }
}