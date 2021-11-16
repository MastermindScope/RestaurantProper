using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibDB;
using RestaurantLibDB.Extension;

namespace RestaurantApp
{
    class DemoData
    {
        public static Kunde peter = new KundeBuilder()
            .setName("Lustig")
            .setVorname("Peter")
            .setKundennummer("XXXX1234")
            .build();

        public static Kunde hermann = new KundeBuilder()
            .setVorname("Hermann")
            .setName("Paschulke")
            .setKundennummer("XXXX4321")
            .build();

        public static Filiale nuernberg = new FilialeBuilder()
            .setName("Filiale Nürnberg-HBF")
            .setBeschreibung("Filiale am Hauptbahnhof Nürnberg")
            .setOrt("Nürnberg")
            .build();

        public static Filiale karlsruhe = new FilialeBuilder()
            .setName("Filiale Karlsruhe-HBF")
            .setBeschreibung("Filiale am Hauptbahnhof Karlsruhe")
            .setOrt("Karlsruhe")
            .build();

        public static Gericht pommesGross = new GerichtBuilder()
            .setBeschreibung("Große Portion Pommes")
            .setName("Große Pommes")
            .setPreis(4.20)
            .build();

        public static Gericht pommesKlein = new GerichtBuilder()
            .setBeschreibung("Baby Portion Pommes für Babies")
            .setName("Kleine Pommes")
            .setPreis(1.69)
            .build();

        public static DateTime vormittagStart = new DateTime(2021, 12, 13, 10, 00, 00);
        public static DateTime vormittagEnde = new DateTime(2021, 12, 13, 10, 15, 00);

        public static DateTime nachmittagStart = new DateTime(2021, 12, 13, 16, 00, 00);
        public static DateTime nachmittagEnde = new DateTime(2021, 12, 13, 16, 15, 00);

        public static Zeitslot vormittagNbg = new ZeitslotBuilder()
            .setStart(vormittagStart)
            .setEnde(vormittagEnde)
            .setEssensplatz(nuernberg)
            .build();

        public static Zeitslot nachmittagKA = new ZeitslotBuilder()
            .setStart(nachmittagStart)
            .setEnde(nachmittagEnde)
            .setEssensplatz(karlsruhe)
            .build();

        public static Buchung petersBuchung = new BuchungBuilder()
            .setBuchungsNummer("ABC123")
            .setEssensZeit(vormittagNbg)
            .setPersonen(1)
            .addGericht(pommesKlein)
            .gebuchtVon(peter)
            .build();

        public DemoData()
        {
            petersBuchung.EnthaeltGerichte.Add(pommesGross);
        }

        public IEnumerable<Zeitslot> Zeitslots
        {
            get
            {
                yield return nachmittagKA;
                yield return vormittagNbg;
            }
        }

        public IEnumerable<Buchung> Buchungen
        {
            get
            {
                yield return petersBuchung;
            }
        }

        public IEnumerable<Kunde> Kunden
        {
            get
            {
                yield return peter;
                yield return hermann;
            }
        }

        public IEnumerable<Filiale> Filialen
        {
            get
            {
                yield return nuernberg;
                yield return karlsruhe;
            }
        }

        public IEnumerable<Gericht> Gerichte
        {
            get
            {
                yield return pommesKlein;
                yield return pommesGross;
            }
        }
    }
}
