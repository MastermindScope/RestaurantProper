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
        private Zeitslot Essenszeit;
        private List<Gericht> EnthaeltGerichte = new List<Gericht>();
        private Kunde GebuchtVon;
        private int Personen;

        public BuchungBuilder setBuchungsNummer(string buchungsNummer)
        {
            if (IsNullOrWhiteSpace(buchungsNummer))
            {
                throw new Exception("Do enter a valid alpha-numeric booking number please!");
            } else { Buchungsnummer = buchungsNummer;  return this; }
        }

        public BuchungBuilder setEssensZeit(Zeitslot essenszeit)
        {
            if(essenszeit == null)
            {
                throw new Exception("Enter a valid date.");
            } else { Essenszeit = essenszeit;  return this; }
        }

        public BuchungBuilder gebuchtVon(Kunde )


    }
}
