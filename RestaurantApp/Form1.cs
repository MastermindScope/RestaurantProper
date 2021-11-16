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
        
        public Form1()
        {
            InitializeComponent();
        }
        DataStore Data = new DataStore();
        DemoData Dummy = new DemoData();


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
        }

        private void InitButton_Click(object sender, EventArgs e)
        {
            foreach(var k in Dummy.Kunden)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(k.Vorname);
                sb.Append(" ");
                sb.Append(k.Name);
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
