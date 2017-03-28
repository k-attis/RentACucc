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
                dbkapcsi = new SQLiteConnection(System.IO.Path.Combine(DBPath, "rentacucc.sqlite3"));
            }
            catch (Exception ex)
            {
            }

            dbkapcsi.CreateTable<Cucc>();
            dbkapcsi.CreateTable<Juzer>();
            dbkapcsi.CreateTable<Kolcsonzes>();
        }
    }
}
