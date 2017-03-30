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
            this.BindingContext = cucc;

            deleteTBI.Clicked += DeleteTBI_Clicked;
            saveTBI.Clicked += SaveTBI_Clicked;
            cancelTBI.Clicked += CancelTBI_Clicked;

            if (cucc.ID == 0)
                this.ToolbarItems.Remove(deleteTBI);
        }

        private void CancelTBI_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SaveTBI_Clicked(object sender, EventArgs e)
        {
          
        }

        private void DeleteTBI_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
