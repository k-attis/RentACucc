﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RentACucc.View
{
    public partial class KikolcsonzottCuccokLap : ContentPage
    {
        public KikolcsonzottCuccokLap()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            cuccokLista.ItemsSource = Model.ViewModel.getEgykePeldany().getKolcsonzottek();
        }
    }
}
