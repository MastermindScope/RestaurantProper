using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace RestaurantLibDB.Extension
{
    class ZeitslotBuilder
    {
        private DateTime Start;
        private DateTime Ende;
        private Filiale Essensplatz;
        private List<Buchung> HatBuchungen = new List<Buchung>();

        public ZeitslotBuilder setStart(DateTime start)
        {
            if (start == null)
            {
                throw new Exception("Do you want to start eating at BLANK hours in the morning? Go ahead!");
            } else { Start = start; return this; }
        }
        public ZeitslotBuilder setEnde(DateTime ende)
        {
            if (ende == null)
            {
                throw new Exception("Do you want to stop eating at BLANK hours in the morning? Go ahead!");
            }
            else { Ende = ende; return this; }
        }

        public ZeitslotBuilder setEssensplatz(Filiale essensplatz)
        {
            if (essensplatz == null)
            {
                throw new Exception("Want to eat on the street? Your location is null.");
            } else { Essensplatz = essensplatz; return this; }
        }

        public ZeitslotBuilder addBuchung(Buchung buchung)
        {
            if (buchung == null)
            {
                throw new Exception("Booking null. Fix!");
            } else { HatBuchungen.Add(buchung); return this; }
        }

        public Zeitslot build()
        {
            Zeitslot val = new Zeitslot(Start, Ende, Essensplatz);
            HatBuchungen.ForEach(buch => val.AddBuchungen(buch));
            return val;
        }

    }
}
