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

        SQLiteConnection dbconn;

        public DB() // constructor
        {
            try
            {
                // adatbázis fájl megnyitása vagy létrehozása ha nem létezik
                dbconn = new SQLiteConnection(System.IO.Path.Combine(DBPath, "rentacucc.sqlite3"));
            }
            catch (Exception ex)
            {
            }
        }
    }
}
