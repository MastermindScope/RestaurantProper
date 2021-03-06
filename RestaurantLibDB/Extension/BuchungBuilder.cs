using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace RestaurantLibDB.Extension
{
    public class BuchungBuilder
    {
        private string Buchungsnummer;
        private List<Gericht> EnthaeltGerichte = new List<Gericht>();
        private Kunde GebuchtVon;
        private int Personen;
        private DateTime Essenszeit;
        private Filiale Essensplatz;


        public BuchungBuilder setBuchungsNummer(string buchungsNummer)
        {
            if (IsNullOrWhiteSpace(buchungsNummer))
            {
                throw new Exception("Do enter a valid alpha-numeric booking number please!");
            } else { Buchungsnummer = buchungsNummer;  return this; }
        }

        public BuchungBuilder gebuchtVon(Kunde buchender)
        {
            if(buchender == null)
            {
                throw new Exception("Find someone who actually wants to eat here!");
            } else { GebuchtVon = buchender; return this; }
        }

        public BuchungBuilder setPersonen(int anzahl)
        {
            if(anzahl == 0)
            {
                throw new Exception("Do you usually go to dinner or lunch with minus one of your friends?");
            } else { Personen = anzahl; return this; }
        }

        public BuchungBuilder addGericht(Gericht happahappa)
        {
            if(happahappa == null)
            {
                throw new Exception("Don't you do this because you're hungry?");
            } else { EnthaeltGerichte.Add(happahappa); return this; }
        }

        public BuchungBuilder setEssenszeit(DateTime essenszeit)
        {
            if(essenszeit == null)
            {
                throw new Exception("Essenszeit null!");
            } else { Essenszeit = essenszeit; return this; }
        }

        public BuchungBuilder setFiliale(Filiale filiale)
        {
            if (filiale == null)
            {
                throw new Exception("How dare you give null inputs?");
            } else { Essensplatz = filiale; return this; }
        }


        public Buchung build()
        {
            Buchung val = new Buchung(GebuchtVon, Buchungsnummer, Personen, Essenszeit, Essensplatz);
            EnthaeltGerichte.ForEach(ger => val.AddGericht(ger));
            return val;
        }


    }
}
