using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace RestaurantLibDB.Extension
{
    class KundeBuilder
    {
        private string Name;
        private string Vorname;
        private string Kundennummer;
        private List<Buchung> HatGebucht = new List<Buchung>();

        public KundeBuilder setName(string name)
        {
            if (IsNullOrWhiteSpace(name))
            {
                throw new Exception("What exactly is your name? I didn't quite catch that.");
            } else { Name = name; return this; }
        }

        public KundeBuilder setVorname(string vorname)
        {
            if (IsNullOrWhiteSpace(vorname))
            {
                throw new Exception("Your surname is very out of the ordinary. Consider giving me another name!");
            } else { Vorname = vorname; return this; }
        }

        public KundeBuilder setKundennummer(string nummer)
        {
            if (IsNullOrWhiteSpace(nummer))
            {
                throw new Exception("Please provide a valid number.");
            } else { Kundennummer = nummer; return this; }
        }

        public KundeBuilder addBuchung(Buchung buchung)
        {
            if (buchung == null)
            {
                throw new Exception("Input is null. Fix that!");
            } else { HatGebucht.Add(buchung); return this; }
        }

        public Kunde build()
        {
            Kunde val = new Kunde(Name, Vorname, Kundennummer);
            HatGebucht.ForEach(buch => val.AddBuchung(buch));
            return val;
        }

    }
}
