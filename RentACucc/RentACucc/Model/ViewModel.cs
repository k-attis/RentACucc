using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACucc.Model
{
    class ViewModel
    {
        public ObservableCollection<Cucc> CuccLista { get; } =
            new ObservableCollection<Cucc>();
        public ObservableCollection<Juzer> JuzerLista { get; } =
            new ObservableCollection<Juzer>();
        public ObservableCollection<Kolcsonzes> KolcsonzesLista { get; private set; } =
            new ObservableCollection<Kolcsonzes>();

        DB db = new DB();

        private ViewModel()
        {
            CuccLista = new ObservableCollection<Cucc>(db.getList<Cucc>());
            JuzerLista = new ObservableCollection<Juzer>(db.getList<Juzer>());
            KolcsonzesLista = new ObservableCollection<Kolcsonzes>(db.getList<Kolcsonzes>());
        }

        //Singleton minta
        //public static ViewModel egykePeldany { get; } = new ViewModel();

        private static ViewModel _EgykePeldany = new ViewModel();
        public static ViewModel getEgykePeldany()
        {
            return _EgykePeldany;
        }

        public void saveCucc(Cucc cucc)
        {
            if (cucc.ID == 0)
            {
                db.insertItem(cucc);
                CuccLista.Add(cucc);
            }
            else
                db.updateItem(cucc);
        }

        public void deleteCucc(Cucc cucc)
        {
            db.deleteItem(cucc);
            CuccLista.Remove(cucc);
        }

        public void saveJuzer(Juzer Juzer)
        {
            if (Juzer.ID == 0)
            {
                db.insertItem(Juzer);
                JuzerLista.Add(Juzer);
            }
            else
                db.updateItem(Juzer);
        }

        public void deleteJuzer(Juzer Juzer)
        {
            db.deleteItem(Juzer);
            JuzerLista.Remove(Juzer);
        }

        public void saveKolcsonzes(KolcsonzesViewModel kvm)
        {
            foreach (Cucc c in kvm.Cuccok)
            {
                Kolcsonzes k = new Kolcsonzes();
                k.JuzerID = kvm.juzer.ID;
                k.CuccID = c.ID;
                k.Mettol = DateTime.Now;
                k.Meddig = DateTime.Now.AddDays(14);

                db.insertItem(k);
            }
        }

        public void visszahoztaCucc(Juzer juzer, Cucc cucc)
        {
            db.visszahoztaCucc(juzer, cucc);
            KolcsonzesLista = new ObservableCollection<Kolcsonzes>(db.getList<Kolcsonzes>());
        }

        public List<Cucc> getJuzerKolcsonzesek(Juzer juzer)
        {
            List<Cucc> ret = new List<Cucc>();

            foreach (Kolcsonzes k in KolcsonzesLista)
                if (k.JuzerID == juzer.ID
                    &&
                    k.Visszahozta == DateTime.MinValue)
                {
                    foreach (Cucc c in CuccLista)
                        if (c.ID == k.CuccID)
                        {
                            ret.Add(c);
                            break;
                        }
                }

            return ret;
        }

        public List<Cucc> getKolcsonzottek()
        {
            List<Cucc> ret = new List<Cucc>();

            foreach (Kolcsonzes k in KolcsonzesLista)
                if (k.Visszahozta == DateTime.MinValue && k.Meddig <DateTime.Now)
                {
                    foreach (Cucc c in CuccLista)
                        if (c.ID == k.CuccID)
                        {
                            ret.Add(c);
                            break;
                        }
                }

            return ret;
        }

        public bool vanEKolcsonzese(Juzer Juzer)
        {
            if (Juzer.ID == 0)
                return false;

            foreach (Kolcsonzes k in KolcsonzesLista)
                if (k.JuzerID == Juzer.ID &&
                    k.Visszahozta == DateTime.MinValue)
                    return true;

            return false;
        }

        public bool kiVanEKolcsonozve(Cucc cucc)
        {
            if (cucc.ID == 0)
                return false;

            foreach (Kolcsonzes k in KolcsonzesLista)
            {
                if (k.CuccID == cucc.ID
                    &&
                    k.Visszahozta == DateTime.MinValue)
                    return true;
            }

            return false;
        }

        public ObservableCollection<JuzerViewModel> getJuzerViewModelList()
        {
            ObservableCollection<JuzerViewModel> tmp =
                new ObservableCollection<JuzerViewModel>();

            List<int> tl = db.getJuzerekLejartKolcsonzessel();

            foreach (Juzer j in JuzerLista)
            {
                tmp.Add(new JuzerViewModel(
                    j,
                    db.getKolcsonzesekSzama(j),
                    getTartozas(j),
                    tl.IndexOf(j.ID) >= 0
                    )
                );
            }

            return tmp;
        }


        public int getTartozas(Juzer juzer)
        {
            decimal lq =
                (from
                    k in KolcsonzesLista
                 join
                 c in CuccLista
              on
                 k.CuccID equals c.ID
                 where
                    k.JuzerID == juzer.ID
                    &&
                    k.Visszahozta == DateTime.MinValue
                 select new { z = (DateTime.Now - k.Mettol).Days * c.Napidij })
                 .Sum(x => x.z);

            return (int)lq;
        }
    }
}
