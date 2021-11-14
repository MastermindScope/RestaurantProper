using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace RestaurantLib
{
    public class Buchung
    {
        //private attributes
        private string _buchungsnummer;
        private int _personen;
        private Zeitslot _essenszeit;
        private Kunde _hungriger;
        private List<Gericht> _enthaeltGerichte = new List<Gericht>();

        //public attributes
        //mostly getters and setters
        public string Buchungsnummer
        {
            get { return _buchungsnummer; }
            set { if (IsNullOrWhiteSpace(value) | value == null)
                {
                    throw new Exception("Please enter a valid booking number");
                } else { _buchungsnummer = value; }
            }
        }

        public int Personen
        {
            get { return _personen; }
            set { if (value == 0)
                {
                    throw new Exception("Can you eat with no persons?");
                } else { _personen = value; }
            }
        }

        public Zeitslot Essenszeit
        {
            get { return _essenszeit; }
        }


        //constructor
        public Buchung(Zeitslot essenszeit, Kunde hungriger, string buchungsnummer, int personen)
        {
            _essenszeit = essenszeit;
            essenszeit.AddBuchungen(this); //add this buchung to the list of Buchungen in the timeslot
            _hungriger = hungriger;
            hungriger.AddBuchung(this); //add this buchung to the list of Buchungen for the customer
            _buchungsnummer = buchungsnummer;
            _personen = personen;
        }

        //private methods

        //public methods
        public void AddGericht(Gericht gerichtToAdd)    //if a gericht is added, the gericht automatically get an entry in the list on which Buchungen it exists
        {
            _enthaeltGerichte.Add(gerichtToAdd);
            gerichtToAdd.AddBuchungen(this);
        }

        public IEnumerable<Gericht> GetGerichte()
        {
            return _enthaeltGerichte;
        }
    }
}
