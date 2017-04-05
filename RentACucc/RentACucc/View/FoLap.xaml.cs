using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using static Xamarin.Forms.Button;

namespace RentACucc.View
{
    public partial class FoLap : ContentPage
    {
        public FoLap()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            this.BackgroundImage = "bg.jpg";

            Cuccok.Clicked += Cuccok_Clicked;
            Juserek.Clicked += Juserek_Clicked;
            Kolcsik.Clicked += Kolcsik_Clicked;
            LejartKolcsik.Clicked += LejartKolcsik_Clicked;
            ujKolcsi.Clicked += UjKolcsi_Clicked;

            egysegesKinezet(Cuccok);
            egysegesKinezet(Juserek);
            egysegesKinezet(Kolcsik);
            egysegesKinezet(LejartKolcsik);
            egysegesKinezet(ujKolcsi);

            pbar.ProgressTo(.8, 5000, Easing.Linear);
            //pbar.BackgroundColor = Color.Pink;
            pbar.Opacity = 0.5;            
            
        }

        private void egysegesKinezet(Button b)
        {   
            b.BorderWidth = 5;
            b.BorderColor = Color.White;
            b.BorderRadius = 10; 
        }

        private void UjKolcsi_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new KolcsonzesLap());
        }

        private void LejartKolcsik_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Kolcsik_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Juserek_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JuzerekLap());
        }

        private void Cuccok_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CuccokLap());
        }
    }
}
