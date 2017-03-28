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
        public CuccokLap()
        {
            InitializeComponent();

            cuccokLista.ItemsSource = 
                Model.ViewModel.getEgykePeldany().CuccLista;

            cuccokLista.ItemTapped += CuccokLista_ItemTapped;

            newCucc.Clicked += NewCucc_Clicked;
        }

        private void CuccokLista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           Navigation.PushAsync(new CuccLap((Cucc)e.Item));
        }

        private void NewCucc_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CuccLap(new Cucc()));
        }
    }
}
