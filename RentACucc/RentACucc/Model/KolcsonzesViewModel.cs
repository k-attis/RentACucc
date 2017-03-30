using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACucc.Model
{
    class KolcsonzesViewModel
    {
        public Juzer juzer { get; set; }
        public ObservableCollection<Cucc> Cuccok { get; set; } = 
            new ObservableCollection<Cucc>();

        public KolcsonzesViewModel()
        {
            juzer = ViewModel.getEgykePeldany().JuzerLista[0];
            Cuccok.Add(ViewModel.getEgykePeldany().CuccLista[1]);
            Cuccok.Add(ViewModel.getEgykePeldany().CuccLista[2]);
        }
    }
}
