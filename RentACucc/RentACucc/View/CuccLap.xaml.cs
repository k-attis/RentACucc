using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RentACucc.View
{
    public partial class CuccLap : ContentPage
    {
        Cucc _cucc;

        public CuccLap(Cucc cucc)
        {
            InitializeComponent();

            _cucc = cucc;
        }
    }
}
