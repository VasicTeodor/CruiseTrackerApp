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
    
    public partial class Putnicki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Putnicki()
        {
            this.Kartas = new HashSet<Karta>();
        }
    
        public int idBroda { get; set; }
        public int brPutnika { get; set; }
        public int brKabina { get; set; }
    
        public virtual Brod Brod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Karta> Kartas { get; set; }
    }
}
