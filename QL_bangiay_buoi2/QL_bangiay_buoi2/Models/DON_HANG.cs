//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QL_bangiay_buoi2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DON_HANG
    {
        public int ID { get; set; }
        public string MADH { get; set; }
        public int MaKH { get; set; }
        public Nullable<int> Ten_Nguoi_Nhan { get; set; }
        public string Dia_Chi_Nhan { get; set; }
        public string Dien_Thoai_Nhan { get; set; }
        public Nullable<System.DateTime> Ngay_dat_hang { get; set; }
        public Nullable<decimal> Tong_tien { get; set; }
        public Nullable<byte> Trang_thai { get; set; }
    
        public virtual KHACH_HANG KHACH_HANG { get; set; }
        public virtual KHACH_HANG KHACH_HANG1 { get; set; }
    }
}