using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RentACucc.View
{
    public partial class JuzerLap : ContentPage
    {
        Juzer _juzer;

        public JuzerLap(Juzer juzer)
        {
            InitializeComponent();

            _juzer = juzer;

            nevEntry.Text = _juzer.Nev;

            deleteTBI.Clicked += DeleteTBI_Clicked;
            saveTBI.Clicked += SaveTBI_Clicked;
            cancelTBI.Clicked += CancelTBI_Clicked;
        }

        private void CancelTBI_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SaveTBI_Clicked(object sender, EventArgs e)
        {
            _juzer.Nev = nevEntry.Text;

            Model.ViewModel.getEgykePeldany().saveJuzer(_juzer);
            Navigation.PopAsync();
        }

        private void DeleteTBI_Clicked(object sender, EventArgs e)
        {
            if (Model.ViewModel.getEgykePeldany().vanEKolcsonzese(_juzer))
                DisplayAlert("Figyi", "Amig van kölcsönzése, addig nem törölhető", "Okés");
            else
                Model.ViewModel.getEgykePeldany().deleteJuzer(_juzer);
            Navigation.PopAsync();
        }
    }
}
