using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace RestaurantLibDB
{
    public partial class Buchung
    {
        //private attributes

        //public attributes
        


        //constructor
        public Buchung(Zeitslot essenszeit, Kunde hungriger, string buchungsnummer, int personen)
        {
            Um = essenszeit;
            essenszeit.AddBuchungen(this); //add this buchung to the list of Buchungen in the timeslot
            GebuchtVon = hungriger;
            hungriger.AddBuchung(this); //add this buchung to the list of Buchungen for the customer
            Buchungsnummmer = buchungsnummer;
            Personen = personen;
        }

        //private methods

        //public methods
        public void AddGericht(Gericht gerichtToAdd)    //if a gericht is added, the gericht automatically get an entry in the list on which Buchungen it exists
        {
            EnthaeltGerichte.Add(gerichtToAdd);
            gerichtToAdd.AddBuchungen(this);
        }

        public IEnumerable<Gericht> GetGerichte()
        {
            return EnthaeltGerichte;
        }
    }
}
