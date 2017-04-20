using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACucc.Model
{
    public class JuzerViewModel : NotifyBase
    {
        public Juzer Juzer { get; private set;}

        public int KolcsonzesekSzama { get; private set; }
        public int Tartozas { get; private set; }

        public JuzerViewModel(Juzer Juzer, int KolcsonzesekSzama, int Tartozas)
        {
            this.Juzer = Juzer;
            this.KolcsonzesekSzama = KolcsonzesekSzama;
            this.Tartozas = Tartozas;
        }
    }
}
