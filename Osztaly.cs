using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDuszaGyak
{
    internal class Osztaly
    {
        string szuloID;
        string szerzoNev;
        string datum;
        string commitLeiras;
        DateTime utolsoValtozas;

        public Osztaly(string szuloID, string szerzoNev,string datum,string commitLeiras, DateTime utolsoValtozas)
        {
            this.szuloID = szuloID;
            this.szerzoNev = szerzoNev;
            this.datum = datum;
            this.commitLeiras = commitLeiras;
            this.utolsoValtozas = utolsoValtozas;
        }

        public string SzuloID { get => szuloID;}
        public string SzerzoNev {get => szerzoNev;}
        public string Datum {get => datum;}
        public string CommitLeiras { get => commitLeiras;}
        public DateTime UtolsoValtozas {get => utolsoValtozas;}
        
        public static string datumVisszaad(DateTime datum)
        {

            return $"{datum.Year}:{datum.Month}:{datum.Day} {datum.Hour}:{datum.Minute}:{datum.Second}";
        }
        

       //public override string ToString() => $"Szulo:{SzuloID}\nSzerzo:{SzerzoNev}\nDatum:{Datum}\nCommit leiras:{CommitLeiras}\nValtozott: \n{datumVisszaad(UtolsoValtozas)}\n{datumVisszaad(UtolsoValtozas)}\n{datumVisszaad(UtolsoValtozas)}";
    }
}
