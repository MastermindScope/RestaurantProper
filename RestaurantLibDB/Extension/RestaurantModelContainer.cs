using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibDB.Extension
{
    public partial class RestaurantModelContainer
    {
        public virtual DbSet<Buchung> Buchungen { get; set; }
        public virtual DbSet<Filiale> Filialen { get; set; }
        public virtual DbSet<Gericht> Gerichte { get; set; }
        public virtual DbSet<Kunde> Kunden { get; set; }
        public virtual DbSet<Zeitslot> Zeitslots { get; set; }


    }
}
