using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACucc
{
    class Kolcsonzes : NotifyBase
    {
        private int _JuzerID = 0;
        public int JuzerID
        {
            get { return _JuzerID; }
            set { _JuzerID = value; propChanged("JuzerID"); }
        }

        private int _CuccID = 0;
        public int CuccID
        {
            get { return _CuccID; }
            set { _CuccID = value; propChanged("CuccID"); }
        }

        private DateTime _Mettol;
        public DateTime Mettol
        {
            get { return _Mettol; }
            set { _Mettol = value; propChanged("Mettol"); }
        }

        private DateTime _Meddig;
        public DateTime Meddig
        {
            get { return _Meddig; }
            set { _Meddig = value; propChanged("Meddig"); }
        }

        private DateTime _Visszahozta;
        public DateTime Visszahozta
        {
            get { return _Visszahozta; }
            set { _Visszahozta = value; propChanged("Visszahozta"); }
        }
    }
}
