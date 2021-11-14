using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace RestaurantLib
{
    public class Filiale
    {
        //private attributes
        private string _name;
        private string _beschreibung;
        private string _ort;
        private List<Zeitslot> _times = new List<Zeitslot>();

        //public attributes
        public string Name
        {
            get { return _name; }
            set { if (value == null | IsNullOrWhiteSpace(value)) 
                  { throw new Exception("Please enter a valid name"); } 
                  else { _name = value; }
                }
        }

        public string Beschreibung
        {
            get { return _beschreibung; }
            set
            {
                if (value == null | IsNullOrWhiteSpace(value))
                { throw new Exception("Please enter a valid description"); }
                else { _beschreibung = value; }
            }
        }

        public string Ort
        {
            get { return _ort; }
            set
            {
                if (value == null | IsNullOrWhiteSpace(value))
                { throw new Exception("Please enter a valid location"); }
                else { _ort = value; }
            }
        }


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
            _times.Add(time);
        }

        public IEnumerable<Zeitslot> GetZeitslots()
        {
            return _times;
        }

    }
}
