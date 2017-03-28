using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACucc
{
    class NotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void propChanged(String PropertyName) {

            PropertyChanged?.Invoke(this, 
                new PropertyChangedEventArgs(PropertyName));
        }
    }
}
