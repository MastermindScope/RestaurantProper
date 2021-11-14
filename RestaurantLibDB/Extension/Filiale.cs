using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace RestaurantLibDB
{
    public partial class Filiale
    {
        //private attributes

        //public attributes
        

        //constructor
        public Filiale(string name, string ort, string beschreibung)
        {
            Name = name;
            Ort = ort;
            Beschreibung = beschreibung;
        } 

        //private methods

        //public methods
        public void AddTimes(Zeitslot time)
        {
            Zeitslots.Add(time);
        }

        public IEnumerable<Zeitslot> GetZeitslots()
        {
            return Zeitslots;
        }

    }
}
