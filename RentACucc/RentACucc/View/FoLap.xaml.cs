using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

            /*
             * Egyelőre kiütöm a az emailküldést
            pbar.ProgressTo(.8, 5000, Easing.Linear);
            //pbar.BackgroundColor = Color.Pink;
            
            pbar.Opacity = 0.5;            

            sendMail.Clicked += SendMail_Clicked;
            callB.Clicked += CallB_Clicked;
            mapB.Clicked += MapB_Clicked;*/
        }

        private void MapB_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode("1096 Budapest, Lenhossék u. 24."))));
        }

        private void CallB_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("tel:1230"));
        }

        private void SendMail_Clicked(object sender, EventArgs e)
        {
            String nagyapámemailje = "kristofmarko97@gmail.com";
            String targysor = "Rendelendok";

            List<String> rendelendok = new List<string>()
            {
                "paprika",
                "kolbasz",
                "kenyer"
            };

            String rendelendokszoveg = "";

            foreach (String s in rendelendok)
                rendelendokszoveg += s + "%0D%0A";

            Device.OpenUri(
                new Uri(
                    "mailto:" + nagyapámemailje +
                    "?subject=" + targysor +
                    "&body=" + rendelendokszoveg));

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

            Navigation.PushAsync(new KolcsonzesekLap());
        }

        private void Juserek_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JuzerekLap(false));
        }

        private void Cuccok_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CuccokLap());
        }
    }
}
