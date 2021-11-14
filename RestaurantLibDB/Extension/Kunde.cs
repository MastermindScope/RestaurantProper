using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace RestaurantLibDB
{
    public partial class Kunde
    {
        //private attributes

        //public attributes
       


        //constructor

        public Kunde(string name, string vorname, string kundennummer)
        {
            Name = name;
            Vorname = vorname;
            Kundennummer = kundennummer;
        }

        //private methods

        //public methods
        public void AddBuchung(Buchung buchungToAdd)
        {
            HatGebucht.Add(buchungToAdd);
        }

        public IEnumerable<Buchung> GetBuchungen()
        {
            return HatGebucht;
        }
    }
}
