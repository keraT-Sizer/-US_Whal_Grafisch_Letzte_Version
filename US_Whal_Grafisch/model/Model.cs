using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace US_Whal_Grafisch.model
{
    class Model
    {

        static public List<Wähler> ZeigeWahlvolk(List<Wähler> wl)
        {
            int ID = 1;
            List<string> jungennamen = new List<string>();
            List<string> mädchennamen = new List<string>();
            List<string> nachnamen = new List<string>();
            Random rand = new Random();

            FileStream fs = File.Open("jungennamen.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                jungennamen.Add(line);
            }
            fs.Close();

            FileStream fs2 = File.Open("maedchennamen.txt", FileMode.Open);
            StreamReader sr2 = new StreamReader(fs2);
            while ((line = sr2.ReadLine()) != null)
            {
                mädchennamen.Add(line);
            }
            fs2.Close();

            FileStream fs3 = File.Open("nachnamen.txt", FileMode.Open);
            StreamReader sr3 = new StreamReader(fs3);
            while ((line = sr3.ReadLine()) != null)
            {
                nachnamen.Add(line);
            }
            fs3.Close();


            for (int i = 1; i <= 1000; i++)
            {
                var tempGeschlecht = rand.Next(0, 2); // Gibt 0 oder 1
                var tempBeeinflussbarkeit = rand.Next(0, 3); // Gibt 0 oder 3
                var tempAlter = rand.Next(0, 6); // Gibt 0 oder 5
                var tempSchicht = rand.Next(0, 4);
                var tempPolitischeHeimat = rand.Next(0, 2);

                if (tempGeschlecht == 0)
                {
                    wl.Add(new Wähler()
                    {
                        ID = ID++,
                        Vorname = jungennamen[rand.Next(0, jungennamen.Count())],
                        Nachname = nachnamen[rand.Next(0, nachnamen.Count())],
                        PLZ = rand.Next(10000, 100000),
                        Geschlecht = Geschlecht.Maenlich,
                        Beeinflussbarkeit = (Beeinflussbarkeit)tempBeeinflussbarkeit,
                        Alter = (Alter)tempAlter,
                        Schicht = (Schicht)tempSchicht,
                        PolitischeHeimat = (PolitischeHeimat)tempPolitischeHeimat
                    }
                           );
                }
                else
                {
                    wl.Add(new Wähler()
                    {
                        ID = ID++,
                        Vorname = mädchennamen[rand.Next(0, mädchennamen.Count())],
                        Nachname = nachnamen[rand.Next(0, nachnamen.Count())],
                        PLZ = rand.Next(10000, 100000),
                        Geschlecht = Geschlecht.Weiblich,
                        Beeinflussbarkeit = (Beeinflussbarkeit)tempBeeinflussbarkeit,
                        Alter = (Alter)tempAlter,
                        Schicht = (Schicht)tempSchicht,
                        PolitischeHeimat = (PolitischeHeimat)tempPolitischeHeimat
                    }
                           );
                }

            }

            FileStream fs5 = File.Open("us_wahl_liste.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs5);

            foreach (var item in wl)
            {
                sw.WriteLine(item.ID + " " +
                             item.Vorname + " " +
                             item.Nachname + " " +
                             item.PLZ + " " +
                             item.Geschlecht + " " +
                             item.Alter + " " +
                             item.Schicht + " " +
                             item.PolitischeHeimat
                             );
            }

            sw.Flush();
            fs5.Close();

            return wl;
        }



    }
}
