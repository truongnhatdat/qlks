//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dichvu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dichvu()
        {
            this.Chitietdatdichvus = new HashSet<Chitietdatdichvu>();
        }
    
        public long IDDV { get; set; }
        public string TenDV { get; set; }
        public double GiaDV { get; set; }
        public string DVT { get; set; }
        public string Hinh { get; set; }
        public string Mota { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietdatdichvu> Chitietdatdichvus { get; set; }
    }
}
