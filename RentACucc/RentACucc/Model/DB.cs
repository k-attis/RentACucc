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

            dbkapcsi.DropTable<Cucc>();
            dbkapcsi.DropTable<Juzer>();
            dbkapcsi.DropTable<Kolcsonzes>();

            dbkapcsi.CreateTable<Cucc>();
            dbkapcsi.CreateTable<Juzer>();
            dbkapcsi.CreateTable<Kolcsonzes>();

            mintaadatok();
        }

        void mintaadatok()
        {
            if (dbkapcsi.Table<Cucc>().Count() > 0)
                return;

            List<Cucc> mintacuccok = new List<Cucc>
            {
                new Cucc()
                {
                    Nev="Hangfal",
                    SN="H001",
                    Napidij = 1000
                },
                new Cucc()
                {
                    Nev="Rúter",
                    SN="R001",
                    Napidij = 100
                },
                new Cucc()
                {
                    Nev="Pöttyös Labda",
                    SN="L123",
                    Napidij = 1
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
                    Mettol = DateTime.Parse("2017.03.23"),
                    Meddig = DateTime.Parse("2017.04.06")
                },
                new Kolcsonzes
                {
                    CuccID = 1,
                    JuzerID =2,
                    Mettol = DateTime.Parse("2017.03.23"),
                    Meddig = DateTime.Parse("2017.04.05"),
                    Visszahozta = DateTime.Parse("2017.03.26")
                },
                new Kolcsonzes
                {
                    CuccID = 1,
                    JuzerID =1,
                    Mettol = DateTime.Parse("2017.03.17"),
                    Meddig = DateTime.Parse("2017.03.27")
                }
            };

            dbkapcsi.InsertAll(mintakolcsonzesek);
        }

        public List<T> getList<T>() where T : new() // bármit írhatsz a T helyére 
        {
            return dbkapcsi.Table<T>().ToList();
        }

        public void saveItem<T>(T item) where T : new()
        {
            int tmp;
            try
            {
                tmp = dbkapcsi.Insert(item);
            }
            catch
            {
                tmp = -1;
            }

            if (tmp == -1)
                updateItem(item);
        }

        public void updateItem<T>(T item) where T : new()
        {
            dbkapcsi.Update(item);
        }

        public void deleteItem<T>(T item) where T : new()
        {
            dbkapcsi.Delete(item);
        }

        public int getTartozas(Juzer juzer)
        {
            List<int> tmp= dbkapcsi.Query<int>(@"
                SELECT
                    sum(Cucc.Napidij)
                FROM
                    Kolcsonzes
                    INNER JOIN
                    Cucc
                    ON
                    Kolcsonzes.CuccID = Cucc.ID
                WHERE
                    Kolcsonzes.JuzerID = ?", juzer.ID);

            return tmp[0];
        }
    }
}
