using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantLibDB;

namespace RestaurantApp
{
    public partial class Form1 : Form
    {
        public Filiale nbg;
        public Zeitslot nachmittags;
        public Kunde peter;
        public Buchung buchung1;
        public Gericht pommes;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nbg = new Filiale("Filiale Nürnberg-HBF", "Nürnberg", "Filiale am Hauptbahnhof Nürnberg");
            nachmittags = new Zeitslot(new DateTime(2021, 11, 10, 16, 00, 00), new DateTime(2021, 11, 10, 16, 30, 00), nbg);
            peter = new Kunde("Müller", "Peter", "PM69", "XXXX1234");
            buchung1 = new Buchung(nachmittags, peter, "ABC456", 1);
            pommes = new Gericht("Pommes", "Normale, normalerweise labberige, Pommes", 1.95);

        }

        private void Print_Click(object sender, EventArgs e)
        {
            DateTime helper = buchung1.Essenszeit.Start;
            Console.WriteLine(helper.ToString("HH:mm:ss dd.MM.yy"));
        }

        private void PommesButton_Click(object sender, EventArgs e)
        {
            buchung1.AddGericht(pommes);
        }
    }
}
