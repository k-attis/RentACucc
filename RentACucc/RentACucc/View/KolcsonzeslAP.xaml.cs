﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RentACucc.View
{
    public partial class KolcsonzesLap : ContentPage
    {
        Model.KolcsonzesViewModel kvm = new Model.KolcsonzesViewModel();

        public KolcsonzesLap()
        {
            InitializeComponent();
            BindingContext = kvm;
            cuccokLista.ItemsSource = kvm.Cuccok;           
        }
    }
}
