using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace RestaurantLib
{
    public class Kunde
    {
        //private attributes
        private string _name;
        private string _vorname;
        private string _username;
        private string _kundennummer;
        private List<Buchung> _buchungen = new List<Buchung>();

        //public attributes
        public string Name
        {
            get { return _name; }
            set { if (value == null | IsNullOrWhiteSpace(value))
                { throw new Exception("Please enter a valid name"); } 
                else { _name = value; }
                }
        }

        public string Vorname
        {
            get { return _vorname; }
            set
            {
                if (value == null | IsNullOrWhiteSpace(value))
                { throw new Exception("Please enter a valid name"); }
                else { _vorname = value; }
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                if (value == null | IsNullOrWhiteSpace(value))
                { throw new Exception("Please enter a valid name"); }
                else { _username = value; }
            }
        }

        public string Kundennummer
        {
            get { return _kundennummer; }
            set
            {
                if (value == null | IsNullOrWhiteSpace(value))
                { throw new Exception("Please enter a valid customer number"); }
                else { _kundennummer = value; }
            }
        }



        //constructor

        public Kunde(string name, string vorname, string username, string kundennummer)
        {
            Name = name;
            Vorname = vorname;
            Username = username;
            Kundennummer = kundennummer;
        }

        //private methods

        //public methods
        public void AddBuchung(Buchung buchungToAdd)
        {
            _buchungen.Add(buchungToAdd);
        }

        public IEnumerable<Buchung> GetBuchungen()
        {
            return _buchungen;
        }
    }
}
