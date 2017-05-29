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
            jvml = Model.ViewModel.getEgykePeldany().getJuzerViewModelList();
            juzerekLista.ItemsSource = jvml;
            juzerekLista.ItemTapped += JuzerekLista_ItemTapped;
            newkolcsonzes.Clicked += Newkolcsonzes_Clicked;
        }

        private void JuzerekLista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.
                PushAsync(
                new KolcsonzesLap(((Model.JuzerViewModel)(e.Item)).Juzer.ID));
        }

        JuzerekLap jl = new JuzerekLap(true);

        private async void Newkolcsonzes_Clicked(object sender, EventArgs e)
        {            
            jl.Disappearing += Jl_Disappearing;
            Navigation.PushAsync(jl);
        }

        private void Jl_Disappearing(object sender, EventArgs e)
        {
            Navigation.PushAsync(new KolcsonzesLap(jl.ValasztottJuzerID));
        }

        private void onAppearing(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;

            viewCell.View.BackgroundColor =
                ((Model.JuzerViewModel)viewCell.BindingContext).HattarSzin;
        }
    }
}
