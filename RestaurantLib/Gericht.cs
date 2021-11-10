using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace RestaurantLib
{
    public class Gericht
    {
        //private attributes
        private string _beschreibung;
        private string _name;
        private double _preis;
        private List<Buchung> _enthaltenIn = new List<Buchung>();

        //public attributes
        public string Beschreibung
        {
            get { return _beschreibung; }
            set { if (IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Please enter a valid description");
                } else { _beschreibung = value; }
            }
        }

        public string Name
        {
            get { return _name; }
            set { if (IsNullOrWhiteSpace(value)) 
                {
                    throw new Exception("Please enter a valid name");
                } else { _name = value; }
            }
        }

        public double Preis
        {
            get { return _preis; }
            set { if ((value*100)%1 != 0)
                {
                    throw new Exception ("Can you pay with fractions of a cent? What are you going to do? Cut it in half? Do the customers have to work for a teeny tiny fraction of an hour? Think about it");
                } else { _preis = value; }
            }
        }


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

        public List<Buchung> GetBuchungen() //spit out all bookings at this time
        {
            return _enthaltenIn;
        }

    }
}
