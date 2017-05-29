using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RentACucc.View
{
    public partial class KolcsonzesLap : ContentPage
    {
        Model.KolcsonzesViewModel kvm;

        public KolcsonzesLap(int valasztottJuzerID)
        {
            kvm = new Model.KolcsonzesViewModel(valasztottJuzerID);

            InitializeComponent();
            BindingContext = kvm;
            cuccokLista.ItemsSource = kvm.Cuccok;

            addCuccTBI.Clicked += addCuccTBI_Clicked;
            saveTBI.Clicked += saveTBI_Clicked;
            cancelTBI.Clicked += cancelTBI_Clicked;
        }

        CuccokLap cl;

        private void addCuccTBI_Clicked(object sender, EventArgs e)
        {
            cl = new CuccokLap(true);
            cl.Disappearing += Cl_Disappearing;
        }

        private void Cl_Disappearing(object sender, EventArgs e)
        {
            kvm.addCucc(cl.valasztottCuccId);                
        }

        private void saveTBI_Clicked(object sender, EventArgs e)
        {
        }


        private void cancelTBI_Clicked(object sender, EventArgs e)
        {
        }
    }
}
