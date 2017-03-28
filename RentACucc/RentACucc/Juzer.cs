using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACucc
{
    class Juzer : NotifyBase
    {
        private int _ID = 0;
        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; propChanged("ID"); }
        }

        private String _Nev = "";
        public String Nev
        {
            get { return _Nev; }
            set { _Nev = value; propChanged("Nev"); }
        }

    }
}
