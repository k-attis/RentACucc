using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACucc.Model
{
    class JuzerViewModel
    {
        Juzer juzer;

        public int ID
        {
            get { return juzer.ID; }
        }

        public String Nev
        {
            get { return juzer.Nev; }
            set { juzer.Nev = value; }
        }

        public int Tartozas { get; private set; }

        public JuzerViewModel(Juzer juzer, int Tartozas)
        {
            this.juzer = juzer;
            this.Tartozas = Tartozas;
        }
    }
}
