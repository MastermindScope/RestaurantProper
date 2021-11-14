using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace RestaurantLibDB.Extension
{
    class GerichtBuilder
    {
        private string Beschreibung;
        private string Name;
        private double Preis;
        private List<Buchung> EnthaltenIn = new List<Buchung>();

        public GerichtBuilder setBeschreibung(string beschreibung)
        {
            if (IsNullOrWhiteSpace(beschreibung))
            {
                throw new Exception("Enter a valid description please!");
            } else { Beschreibung = beschreibung; return this; }
        }

        public GerichtBuilder setName(string name)
        {
            if (IsNullOrWhiteSpace(name))
            {
                throw new Exception("Enter a valid name please!");
            } else { Name = name; return this; }
        }

        public GerichtBuilder setPreis(double preis)
        {
            if (preis <= 0)
            {
                throw new Exception("Are you giving handouts?.... Commie!");
            } else { Preis = preis; return this; }
        }

        public GerichtBuilder addBuchung(Buchung buchung)
        {
            if(buchung == null)
            {
                throw new Exception("Didn't you want to eat?");
            } else { EnthaltenIn.Add(buchung); return this; }
        }

        public Gericht build()
        {
            Gericht val = new Gericht(Name, Beschreibung, Preis);
            EnthaltenIn.ForEach(buch => val.AddBuchungen(buch));
            return val;
        }

    }
}
