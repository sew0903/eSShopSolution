//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThriftShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class San_pham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public San_pham()
        {
            this.Chi_tiet_don_hang = new HashSet<Chi_tiet_don_hang>();
            this.Kho_hang = new HashSet<Kho_hang>();
        }
    
        public int id_sp { get; set; }
        public string ten_sp { get; set; }
        public string color { get; set; }
        public Nullable<int> id_hangsx { get; set; }
        public string mo_ta_sp { get; set; }
        public Nullable<System.DateTime> ngay_sx { get; set; }
        public string anh_sp { get; set; }
        public Nullable<int> luot_xem { get; set; }
        public Nullable<int> luot_tim_kiem { get; set; }
        public Nullable<int> gia_ban { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chi_tiet_don_hang> Chi_tiet_don_hang { get; set; }
        public virtual Hang_sx Hang_sx { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kho_hang> Kho_hang { get; set; }
    }
}