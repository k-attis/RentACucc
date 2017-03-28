using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACucc
{
    public class DB
    {
        public static String DBPath; // Platform specifikus elérési út az alkalmazás privát fájljaihoz

        SQLiteConnection dbkapcsi;

        public DB() // constructor
        {
            try
            {
                // adatbázis fájl megnyitása vagy létrehozása ha nem létezik
                String dbpath = System.IO.Path.Combine(DBPath, "xyz");
                dbkapcsi = new SQLiteConnection(dbpath);
            }
            catch (Exception ex)
            {
            }

            dbkapcsi.CreateTable<Cucc>();
            dbkapcsi.CreateTable<Juzer>();
            dbkapcsi.CreateTable<Kolcsonzes>();

            mintaadatok();
        }

        void mintaadatok()
        {
            List<Cucc> mintacuccok = new List<Cucc>
            {
                new Cucc()
                {
                    Nev="Hangfal",
                    SN="H001"
                },
                new Cucc()
                {
                    Nev="Rúter",
                    SN="R001"
                },
                new Cucc()
                {
                    Nev="Pöttyös Labda",
                    SN="L123"
                }
            };

            dbkapcsi.InsertAll(mintacuccok);

            List<Juzer> mintajuzerek = new List<Juzer>
            {
                new Juzer()
                {
                    Nev = "Aladár"
                },
                new Juzer()
                {
                    Nev = "Béla"
                },
                new Juzer()
                {
                    Nev = "Cecil"
                }
            };

            dbkapcsi.InsertAll(mintajuzerek);

            List<Kolcsonzes> mintakolcsonzesek = new List<Kolcsonzes>
            {
                new Kolcsonzes
                {
                    CuccID = 2,
                    JuzerID =2,
                    Mettol = DateTime.Parse("2016.03.23"),
                    Meddig = DateTime.Parse("2016.03.30")                    
                },
                new Kolcsonzes
                {
                    CuccID = 1,
                    JuzerID =2,
                    Mettol = DateTime.Parse("2016.03.23"),
                    Meddig = DateTime.Parse("2016.04.05"),
                    Visszahozta = DateTime.Parse("2016.03.26")
                },
                new Kolcsonzes
                {
                    CuccID = 1,
                    JuzerID =1,
                    Mettol = DateTime.Parse("2016.03.27"),
                    Meddig = DateTime.Parse("2016.04.07")
                }
            };

            dbkapcsi.InsertAll(mintakolcsonzesek);
        }

        public List<T> getList<T>() where T : new() // bármit írhatsz a T helyére 
        {
            return dbkapcsi.Table<T>().ToList();
        }        
    }
}
