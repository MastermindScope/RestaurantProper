using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace RestaurantLibDB
{
    public partial class Gericht
    {
        //private attributes
        private string _beschreibung;
        private string _name;
        private double _preis;
        private List<Buchung> _enthaltenIn = new List<Buchung>();

        //public attributes
        


        //constructor
        public Gericht (string name, string beschreibung, double preis)
        {
            Name = name;
            Beschreibung = beschreibung;
            Preis = preis;
        }

        //private methods

        //public methods
        public void AddBuchungen(Buchung buchungToAdd)  //add a buchung to the list, prevent removal
        {
            _enthaltenIn.Add(buchungToAdd);
        }

        public IEnumerable<Buchung> GetBuchungen() //spit out all bookings at this time
        {
            return _enthaltenIn;
        }

    }
}
