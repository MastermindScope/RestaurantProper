//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantLibDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Buchung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Buchung()
        {
            this.EnthaeltGerichte = new HashSet<Gericht>();
        }
    
        public int Id { get; set; }
        public string Buchungsnummmer { get; set; }
        public int Personen { get; set; }
        public int ZeitslotId { get; set; }
        public int KundeId { get; set; }
    
        public virtual Zeitslot Um { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gericht> EnthaeltGerichte { get; set; }
        public virtual Kunde GebuchtVon { get; set; }
    }
}
