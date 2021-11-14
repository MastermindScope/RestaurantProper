using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibDB
{
    public partial class Zeitslot
    {
        //private attributes
        

        //public attributes
        
        

        //constructor

        public Zeitslot(DateTime start, DateTime ende, Filiale essensplatz)
        {
            Start = start;
            Ende = ende;
            Filiale = essensplatz;
        }

        //private methods

        //public methods
        public void AddBuchungen(Buchung buchungToAdd)  //add a buchung to the list, prevent removal
        {
            HatBuchungen.Add(buchungToAdd);
        }

        public IEnumerable<Buchung> GetBuchungen() //spit out all bookings at this time
        {
            return HatBuchungen;
        }
    }
}
