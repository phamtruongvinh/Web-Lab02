//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab02.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tintuc
    {
        public int IdTin { get; set; }
        public Nullable<int> IDLoai { get; set; }
        public string Tieudetin { get; set; }
        public string Noidungtin { get; set; }
    
        public virtual Theloaitin Theloaitin { get; set; }
    }
}
