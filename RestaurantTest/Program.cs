using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLib;

namespace RestaurantTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Filiale nbg = new Filiale("Filiale Nürnberg-HBF", "Nürnberg", "Filiale am Hauptnahnhof Nürnberg");
            Filiale KA = new Filiale("Filiala Karlsruhe-Kronenplatz", "Karlsruhe", "Filiale am Kronenplatz in Karlsruhe");

            Zeitslot vormittagsnbg = new Zeitslot(new DateTime(2021, 11, 11, 10, 00, 00), new DateTime(2021, 11, 11, 11, 00, 00), nbg);
            Zeitslot vormittagsKA = new Zeitslot(new DateTime(2021, 11, 11, 10, 00, 00), new DateTime(2021, 11, 11, 11, 00, 00), KA);

            Kunde peter = new Kunde("Müller", "Peter", "PM69", "XXXX1234");

            Gericht pommes = new Gericht("Pommes", "Eine Portion Pommes", 1.96);
            Gericht hamberder = new Gericht("Hamberder", "Trumps favourite food", 2.50);

            Buchung peterKauftEin = new Buchung(vormittagsnbg, peter, "ABC123", 1);

            peterKauftEin.AddGericht(pommes);
            peterKauftEin.AddGericht(pommes);
            peterKauftEin.AddGericht(hamberder);

            
        }
    }
}
