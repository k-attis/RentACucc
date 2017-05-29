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

        public KolcsonzesViewModel(int valsztottUserId)
        {
            foreach (Juzer j in ViewModel.getEgykePeldany().JuzerLista)
                if (j.ID == valsztottUserId)
                    juzer = j;
        }

        public void addCucc(int valasztottCuccId)
        {
            foreach (Cucc c in ViewModel.getEgykePeldany().CuccLista)
                if (c.ID == valasztottCuccId)
                    Cuccok.Add(c);
        }
    }
}
