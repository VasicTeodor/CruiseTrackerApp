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
    
    public partial class Brod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brod()
        {
            this.Kapetans = new HashSet<Kapetan>();
        }
    
        public int idBroda { get; set; }
        public string naziv { get; set; }
    
        public virtual Putnicki Putnicki { get; set; }
        public virtual Teretni Teretni { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kapetan> Kapetans { get; set; }
    }
}
