//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kho2222.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTphieunhap
    {
        public int id { get; set; }
        public string maPN { get; set; }
        public string maHG { get; set; }
        public string mak { get; set; }
        public Nullable<System.DateTime> namSX { get; set; }
        public Nullable<int> soluong { get; set; }
        public Nullable<int> gianhap { get; set; }
        public Nullable<int> thanhtien { get; set; }
    
        public virtual hang hang { get; set; }
        public virtual kho kho { get; set; }
        public virtual phieunhap phieunhap { get; set; }
    }
}
