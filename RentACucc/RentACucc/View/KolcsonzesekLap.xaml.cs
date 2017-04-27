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
            newkolcsonzes.Clicked += Newkolcsonzes_Clicked;
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
