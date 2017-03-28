using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACucc.Model
{
    class ViewModel
    {
        public ObservableCollection<Cucc> CuccLista { get; } =
            new ObservableCollection<Cucc>();
        public ObservableCollection<Juzer> JuzerLista { get; } =
            new ObservableCollection<Juzer>();
        public ObservableCollection<Kolcsonzes> KolcsonzesLista { get; } =
            new ObservableCollection<Kolcsonzes>();

        DB db = new DB();

        public ViewModel()
        {
                        
        }

    }
}
