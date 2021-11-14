using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace RestaurantLibDB.Extension
{
    class FilialeBuilder
    {
        private string Name;
        private string Ort;
        private string Beschreibung;
        private List<Zeitslot> Zeitslots = new List<Zeitslot>();


        public FilialeBuilder setName(string name)
        {
            if (IsNullOrWhiteSpace(name))
            {
                throw new Exception("Enter a valid name!");
            } else { Name = name; return this; }
        }

        public FilialeBuilder setOrt(string ort)
        {
            if (IsNullOrWhiteSpace(ort))
            {
                throw new Exception("Enter a valid location!");
            } else { Ort = ort; return this; }
        }

        public FilialeBuilder setBeschreibung(string beschreibung)
        {
            if (IsNullOrWhiteSpace(beschreibung))
            {
                throw new Exception("This is not a description you're giving me. Give me non-empty stuff!!!");
            } else { Beschreibung = beschreibung; return this; }
        }

        public Filiale build()
        {
            Filiale val = new Filiale(Name, Ort, Beschreibung);
            Zeitslots.ForEach(zs => val.AddTimes(zs));
            return val;
        }

    }
}
