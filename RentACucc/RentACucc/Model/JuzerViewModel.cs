using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RentACucc.Model
{
    public class JuzerViewModel : NotifyBase
    {
        public Juzer Juzer { get; private set; }

        public int KolcsonzesekSzama { get; private set; }
        public int Tartozas { get; private set; }

        public bool LejartKolcsonzesVane { get; private set; }

        public Color HattarSzin
        {
            get
            {
                if (LejartKolcsonzesVane)
                    return Color.FromRgba(255, 0, 0, 170);
                else
                    return Color.Green;
            }
        }

        public JuzerViewModel(Juzer Juzer, int KolcsonzesekSzama, 
            int Tartozas, bool LejartKolcsonzesVane)
        {
            this.Juzer = Juzer;
            this.KolcsonzesekSzama = KolcsonzesekSzama;
            this.Tartozas = Tartozas;
            this.LejartKolcsonzesVane = LejartKolcsonzesVane;
        }
    }
}
