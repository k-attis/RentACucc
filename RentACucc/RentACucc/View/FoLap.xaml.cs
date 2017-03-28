using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RentACucc.View
{
    public partial class FoLap : ContentPage
    {
        public FoLap()
        {
            InitializeComponent();

            Cuccok.Clicked += Cuccok_Clicked;
            Juserek.Clicked += Juserek_Clicked;
            Kolcsik.Clicked += Kolcsik_Clicked;
            LejartKolcsik.Clicked += LejartKolcsik_Clicked;
        }

        private void LejartKolcsik_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Kolcsik_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Juserek_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Cuccok_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
