using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography;

namespace ConsoleAppDuszaGyak
{
    internal class Program
    {
        static string? szerzoNev = "";
        static string? commitLeiras = "";
        static void Main(string[] args)
        {
            Directory.Delete(@"C:\\Users\\barizs.marton.daniel\\Dolgok\\Pelda\\.dusza", true);

            Console.Write("Adja meg a nevét: ");
            szerzoNev = Console.ReadLine();
            int kovetkezoCommitSzama = 0;
            
            //Console.WriteLine(jelenlegiIdo.ToString("yyyy.MM.dd HH:mm:ss"));
            
            string path = "C:\\Users\\barizs.marton.daniel\\Dolgok\\Pelda\\.dusza";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                DirectoryInfo di = Directory.CreateDirectory(path);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                Console.WriteLine("Létrejött a repository!"); // inicializacio (HungárInglis)
                kovetkezoCommitSzama = Directory.GetDirectories("C:\\Users\\barizs.marton.daniel\\Dolgok\\Pelda\\.dusza").Length + 1;
            }
            Console.WriteLine("Írjon be egy parancsot! (commit / history / reset)");
            string? command = Console.ReadLine();
            while (command != "")
            {
                switch (command)
                {
                    case "commit":
                        Commit("C:\\Users\\barizs.marton.daniel\\Dolgok\\Pelda", $"C:\\Users\\barizs.marton.daniel\\Dolgok\\Pelda\\.dusza\\{kovetkezoCommitSzama}.commit", kovetkezoCommitSzama);
                        Directory.Delete(@$"C:\\Users\\barizs.marton.daniel\\Dolgok\\Pelda\\.dusza\\{kovetkezoCommitSzama}.commit\\.dusza", true);
                        kovetkezoCommitSzama++;
                        Console.WriteLine("Adjon meg valamit bruh");
                        string? commitLeiras = Console.ReadLine();
                        DateTime jelenlegiIdo = DateTime.Now;
                        FajlbaIr($"{kovetkezoCommitSzama}.commit",szerzoNev, jelenlegiIdo.ToString("yyyy.MM.dd HH:mm:ss"),commitLeiras);
                        command = Console.ReadLine();
                        break;
                    case "delete":
                        Delete();
                        command = Console.ReadLine();
                        break;
                    case "create":
                        Create();
                        command = Console.ReadLine();
                        break;
                    
                }
            }
        }

        public static void Commit(string forrasHely, string celHely, int kovetkezoCommitSzama)
        { 
            
            string commitNev = $"{kovetkezoCommitSzama}.commit";
            Directory.CreateDirectory($"C:\\Users\\barizs.marton.daniel\\Dolgok\\Pelda\\.dusza\\{commitNev}");
            ///celHely = $"C:\\Users\\barizs.marton.daniel\\Dolgok\\Pelda\\.dusza\\{commitNev}";
            string[] mappak = Directory.GetDirectories(forrasHely);
            foreach (string folder in mappak)
            {

                string nev = Path.GetFileName(folder);
                string cel = Path.Combine(celHely, nev);
                DirectoryInfo di = new DirectoryInfo(nev);
                if (di.Attributes != (FileAttributes.Directory | FileAttributes.Hidden))
                {                
                    foreach (string dirPath in Directory.GetDirectories(forrasHely, "*", SearchOption.AllDirectories))
                    {
                            Directory.CreateDirectory(dirPath.Replace(forrasHely, celHely));   
                    }
                }
                foreach (string newPath in Directory.GetFiles(forrasHely, "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(newPath, newPath.Replace(forrasHely, celHely), true);
                }
            }

            string? txtNeve = "C:\\Users\\barizs.marton.daniel\\Dolgok\\Pelda\\.dusza\\Head.txt";
            StreamWriter sw = File.CreateText(txtNeve);   
            sw.WriteLine($"A jelenlegi verziószám:{kovetkezoCommitSzama}");
            sw.Close(); 
        }

        public static void FajlbaIr(string szulo, string szerzo, string datum, string commitLeiras)
        {
            Osztaly commit = new Osztaly(szulo,szerzo,datum,commitLeiras,DateTime.Now);
            List<Osztaly> lista = new List<Osztaly>();
            string[] tomb = szulo.Split('.');
            lista.Add(commit);
            File.WriteAllLines($"C:\\Users\\barizs.marton.daniel\\Dolgok\\Pelda\\.dusza\\{int.Parse(tomb[0]) - 2}.commit\\commit.details.txt",
                lista.Select(x => $"Szulo:{x.SzuloID}\nSzerzo:{x.SzerzoNev}\nDatum:{x.Datum}\nCommit leiras:{x.CommitLeiras}\nValtozott: \n{x.UtolsoValtozas}\n{x.UtolsoValtozas}\n{x.UtolsoValtozas}"));
        }
        public static void Delete()
        {

        }
        public static void Create()
        {

        }
    }
}
