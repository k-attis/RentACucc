using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RentACucc.View
{
    public partial class KolcsonzesekLap : ContentPage
    {
        ObservableCollection<Model.JuzerViewModel> jvml;

        public KolcsonzesekLap()
        {
            InitializeComponent();
            juzerekLista.ItemTapped += JuzerekLista_ItemTapped;
            newkolcsonzes.Clicked += Newkolcsonzes_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // ez a metódus akkor hívódik, ha a lap előtűnik 
            // vagy azért mert létrehozták
            // vagy azért mert le volt takarva más által
            jvml = Model.ViewModel.getEgykePeldany().getJuzerViewModelList();
            juzerekLista.ItemsSource = jvml;
        }
        
        private void JuzerekLista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            KolcsonzesLap kl = new KolcsonzesLap(((Model.JuzerViewModel)(e.Item)).Juzer.ID, false);
            Navigation.PushAsync(kl);
        }

        JuzerekLap jl = new JuzerekLap(true);

        private async void Newkolcsonzes_Clicked(object sender, EventArgs e)
        {
            jl.Disappearing += Jl_Disappearing;
            Navigation.PushAsync(jl);
        }

        private void Jl_Disappearing(object sender, EventArgs e)
        {
            Navigation.PushAsync(new KolcsonzesLap(jl.ValasztottJuzerID, true));
        }

        private void onAppearing(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;

            viewCell.View.BackgroundColor =
                ((Model.JuzerViewModel)viewCell.BindingContext).HattarSzin;
        }
    }
}
