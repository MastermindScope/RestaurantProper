using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLib
{
    public class Zeitslot
    {
        //private attributes
        private DateTime _start;
        private DateTime _ende;
        private Filiale _essensplatz;
        private List<Buchung> _buchungen = new List<Buchung>();

        //public attributes
        public DateTime Start
        {
            get { return _start; }
            set { if(value == null)
                { throw new Exception("Please enter a valid date"); }
                else { _start = value; }
            }
        }
        public DateTime Ende
        {
            get { return _ende; }
            set { if (value == null)
                { throw new Exception("Please enter a valid date"); }
                else { _ende = value; }
            }
        }

        public Filiale Essensplatz
        {
            get { return _essensplatz; }
            set { if (_essensplatz != null) //if the place is already set, the user is not allowed to change it
                {
                    throw new Exception ("You are not allowed to change that once you havve decided on a place");
                } else { _essensplatz = value; }
            }
        }
        

        //constructor

        public Zeitslot(DateTime start, DateTime ende, Filiale essensplatz) : this()
        {
            Start = start;
            Ende = ende;
            Essensplatz = essensplatz;
            essensplatz.AddTimes(this);
        }

        //private methods

        //public methods
        public void AddBuchungen(Buchung buchungToAdd)  //add a buchung to the list, prevent removal
        {
            _buchungen.Add(buchungToAdd);
        }

        public IEnumerable<Buchung> GetBuchungen() //spit out all bookings at this time
        {
            return _buchungen;
        }
    }
}
