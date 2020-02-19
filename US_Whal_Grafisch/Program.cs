using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using US_Whal_Grafisch.model;

namespace US_Whal_Grafisch
{

    public enum Geschlecht { Weiblich, Maenlich }
    public enum Beeinflussbarkeit { Leicht, Mittel, Schwer }
    public enum Alter { Erstwaehler, Bis30, Bis40, Bis50, Restliche }
    public enum Schicht { Unterschicht, Unteremittelschicht, Oberemittelschicht, Oberschicht }
    public enum PolitischeHeimat { Republikaner, Demokraten }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            Console.ReadLine();
        }


        public static List<Wähler> Filtern(Form1.Parameter p)
        {
            List<Wähler> wl_link = new List<Wähler>();

            FileStream fs9 = File.Open("us_wahl_liste.txt", FileMode.Open);
            StreamReader sr9 = new StreamReader(fs9);
            string line;
            while ((line = sr9.ReadLine()) != null)
            {
              // hier muss noch aus der Datei ausgelesen werden und objekte vom typ Wähler in einer List<Wähler> gespeichert werden
            }
            fs9.Close();

            var wl_link = from wähler in wl
                          where
                              wähler.PolitischeHeimat == p.PolitischeHeimat &&
                              wähler.Geschlecht       == p.Geschlecht 

                              //wähler.Alter == Alter.Erstwaehler &&
                              //wähler.Schicht == Schicht.OBERSCHICHT &&

                              //wähler.PLZ > 47111 &&
                              //wähler.PLZ < 80000 &&
                              //&&
                              //wähler.Beeinflussbarkeit == Beeinflussbarkeit.Leicht
                              select wähler;

            return wl_link.ToList();
        }
    }
}
