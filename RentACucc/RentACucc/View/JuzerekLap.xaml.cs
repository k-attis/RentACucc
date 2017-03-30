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
        }
    }
}
