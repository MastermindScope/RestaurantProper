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

namespace RestaurantWeb
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        DataStore Data = new DataStore();
        DemoData Dummy = new DemoData();
        RestaurantModelContainer DB = new RestaurantModelContainer();


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Print_Click(object sender, EventArgs e)
        {

        }

        private void PommesButton_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Data = new DataStore();
            Dummy = new DemoData();


            foreach (var k in Dummy.Kunden)
            {
                DB.Kunden.Add(k);
            }
            DB.SaveChanges();
            foreach (var g in Dummy.Gerichte)
            {
                DB.Gerichte.Add(g);
            }
            foreach (var f in Dummy.Filialen)
            {
                DB.Filialen.Add(f);
            }
            foreach (var b in Dummy.Buchungen)
            {
                DB.Bestellungen.Add(b);
            }
            DB.SaveChanges();
            
            

            
        }

        private void InitButton_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
