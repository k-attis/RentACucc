using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACucc
{
    class Cucc : NotifyBase
    {
        private int _ID = 0;
        [PrimaryKey, AutoIncrement] 
        public int ID
        {
            get { return _ID; }
            set { _ID = value; propChanged("ID"); }
        }

        private String _SN = "";
        public String SN
        {
            get { return _SN; }
            set { _SN = value; propChanged("SN"); }
        }

        private String _Nev = "";
        public String Nev
        {
            get { return _Nev; }
            set { _Nev = value; propChanged("Nev"); }
        }
    }
}
