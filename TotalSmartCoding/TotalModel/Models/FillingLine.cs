//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TotalModel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FillingLine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FillingLine()
        {
            this.Batches = new HashSet<Batch>();
            this.Pickups = new HashSet<Pickup>();
            this.Cartons = new HashSet<Carton>();
            this.Packs = new HashSet<Pack>();
        }
    
        public int FillingLineID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool HasPack { get; set; }
        public bool HasCarton { get; set; }
        public bool HasPallet { get; set; }
        public int LocationID { get; set; }
        public Nullable<int> LastLogonFillingLineID { get; set; }
        public string PortName { get; set; }
        public Nullable<int> ServerID { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string Remarks { get; set; }
        public bool InActive { get; set; }
        public string NickName { get; set; }
        public bool PalletChanged { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Batch> Batches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pickup> Pickups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Carton> Cartons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pack> Packs { get; set; }
    }
}
