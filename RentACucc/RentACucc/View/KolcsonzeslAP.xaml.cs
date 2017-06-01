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

        bool ujKolcsonzes;

        public KolcsonzesLap(int valasztottJuzerID, bool ujKolcsonzes)
        {
            kvm = new Model.KolcsonzesViewModel(valasztottJuzerID);

            this.ujKolcsonzes = ujKolcsonzes;

            InitializeComponent();
            BindingContext = kvm;
            cuccokLista.ItemsSource = kvm.Cuccok;

            addCuccTBI.Clicked += addCuccTBI_Clicked;
            saveTBI.Clicked += saveTBI_Clicked;
            cancelTBI.Clicked += cancelTBI_Clicked;
            deleteCuccTBI.Clicked += DeleteCuccTBI_Clicked;
        }

        private void DeleteCuccTBI_Clicked(object sender, EventArgs e)
        {
            Cucc c = (Cucc)cuccokLista.SelectedItem;

            if (c == null)
                return;

            if (ujKolcsonzes)
                kvm.deleteCucc(c);
            else
                kvm.visszahoztaCucc(c);                       
        }

        CuccokLap cl;

        private void addCuccTBI_Clicked(object sender, EventArgs e)
        {
            cl = new CuccokLap(true);
            cl.Disappearing += Cl_Disappearing;
            Navigation.PushAsync(cl);
        }

        private void Cl_Disappearing(object sender, EventArgs e)
        {
            kvm.addCucc(cl.valasztottCuccId);

        }

        private void saveTBI_Clicked(object sender, EventArgs e)
        {
            Model.ViewModel.getEgykePeldany().saveKolcsonzes(kvm);
            Navigation.PopAsync();
        }

        private void cancelTBI_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
