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
    
    public partial class Don_hang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Don_hang()
        {
            this.Chi_tiet_don_hang = new HashSet<Chi_tiet_don_hang>();
        }
    
        public int id_don_hang { get; set; }
        public string tinh_trang { get; set; }
        public string ten_kh { get; set; }
        public string sdt { get; set; }
        public string dia_chi { get; set; }
        public Nullable<System.DateTime> ngay_tao { get; set; }
        public Nullable<int> tong_tien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chi_tiet_don_hang> Chi_tiet_don_hang { get; set; }
    }
}
