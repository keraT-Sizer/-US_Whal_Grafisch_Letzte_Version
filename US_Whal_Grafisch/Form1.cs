using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using US_Whal_Grafisch.model;

namespace US_Whal_Grafisch
{
    public partial class Form1 : Form
    {

        static List<Wähler> wl2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Wähler> wl = new List<Wähler>();
            List<Wähler> wl2 = Model.ZeigeWahlvolk(wl);

            

            
        }


        public class Parameter
        {
            public Geschlecht Geschlecht { get; set; } 
            public PolitischeHeimat PolitischeHeimat { get; set; }
          
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string geschlecht = comboBox1.Text;
            string ph = comboBox2.Text;



            Parameter p = new Parameter();

            switch (geschlecht)
            {
                case "Maenlich":
                    p.Geschlecht = Geschlecht.Maenlich;
                    break;

                case "Weiblich":
                    p.Geschlecht = Geschlecht.Weiblich;
                    break;
            }

            switch (ph)
            {
                case "Demokraten":
                    p.PolitischeHeimat = PolitischeHeimat.Demokraten;
                    break;

                case "Republikaner":
                    p.PolitischeHeimat = PolitischeHeimat.Republikaner;
                    break;
            }

            List<Wähler> wl_link = Program.Filtern(wl2, p);



            textBox1.Text = "";
            foreach (var item in wl_link)
            {
                textBox1.AppendText("Vorname: " + item.Vorname + " ," +
                                     "Nachname: " + item.Nachname + " ," +
                                     "PLZ: " + item.PLZ + " ," +
                                     "Politische Heimat: " + item.PolitischeHeimat + " ," +
                                     "Alter: " + item.Alter + " ," +
                                     "Geschlecht: " + item.Geschlecht + " ," +
                                     "Beeinflussbarkeit: " + item.Beeinflussbarkeit + " ," +
                                     "Schicht: " + item.Schicht + "\n"
                                     );
            }
        }
    }
}















