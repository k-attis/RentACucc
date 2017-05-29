using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RentACucc.View
{
    public partial class CuccokLap : ContentPage
    {
        bool valasztoMod;

        public int valasztottCuccId { get; private set; }

        public CuccokLap(bool valasztoMod)
        {
            InitializeComponent();

            this.valasztoMod = valasztoMod;

            cuccokLista.ItemsSource =
                Model.ViewModel.getEgykePeldany().CuccLista;

            cuccokLista.ItemTapped += CuccokLista_ItemTapped;

            newCucc.Clicked += NewCucc_Clicked;
        }

        private void CuccokLista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            cuccokLista.SelectedItem = null;

            if (valasztoMod)
            {
                valasztottCuccId = ((Cucc)e.Item).ID;
                Navigation.PopAsync();
            }
            else
                Navigation.PushAsync(new CuccLap((Cucc)e.Item));
        }

        private void NewCucc_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CuccLap(new Cucc()));
        }
    }
}
