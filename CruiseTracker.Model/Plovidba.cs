//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CruiseTracker.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plovidba
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plovidba()
        {
            this.Kartas = new HashSet<Karta>();
        }
    
        public int brPlovidbe { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }
        public System.DateTime polazak { get; set; }
        public int brPutnika { get; set; }
        public int brDestinacije { get; set; }
        public int idKapetana { get; set; }
        public int idLuke { get; set; }
    
        public virtual Destinacija Destinacija { get; set; }
        public virtual Kapetan Kapetan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Karta> Kartas { get; set; }
        public virtual Luka Luka { get; set; }
    }
}
