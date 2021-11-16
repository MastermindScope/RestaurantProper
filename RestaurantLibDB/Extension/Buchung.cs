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
        public Buchung(Kunde hungriger, string buchungsnummer, int personen, DateTime essenszeit)
        {
            GebuchtVon = hungriger;
            hungriger.AddBuchung(this); //add this buchung to the list of Buchungen for the customer
            Buchungsnummmer = buchungsnummer;
            Personen = personen;
            Essenszeit = essenszeit;

        }

        //private methods

        //public methods
        public void AddGericht(Gericht gerichtToAdd)    //if a gericht is added, the gericht automatically get an entry in the list on which Buchungen it exists
        {
            if(EnthaeltGerichte == null)
            {
                EnthaeltGerichte = new List<Gericht>();
            }
            EnthaeltGerichte.Add(gerichtToAdd);
            gerichtToAdd.AddBuchungen(this);
        }

        public IEnumerable<Gericht> GetGerichte()
        {
            return EnthaeltGerichte;
        }
    }
}
