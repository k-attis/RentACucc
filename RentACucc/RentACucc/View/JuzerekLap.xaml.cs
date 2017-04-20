using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RentACucc.View
{
    public partial class JuzerekLap : ContentPage
    {
        public JuzerekLap()
        {
            InitializeComponent();
            juzerekLista.ItemsSource = 
                Model.ViewModel.getEgykePeldany().getJuzerViewModelList();
            juzerekLista.ItemTapped += JuzerekLista_ItemTapped;

            juzerekLista.SeparatorColor = Color.Red;

            newJuzer.Clicked += NewJuzer_Clicked;
        }

        private void NewJuzer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JuzerLap(new Juzer()));
        }

        private void JuzerekLista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            juzerekLista.SelectedItem = null;
            Navigation.PushAsync(new JuzerLap(((Model.JuzerViewModel)e.Item).Juzer));
        }
    }
}
