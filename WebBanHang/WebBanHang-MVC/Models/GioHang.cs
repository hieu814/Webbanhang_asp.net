namespace WebBanHang_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        public int? id_donhang { get; set; }

        public int id { get; set; }

        public int? id_sanpham { get; set; }

        public int? soluong { get; set; }

        public double? tongsotien { get {
                return soluong * dongia;
            } }

        public bool? status { get; set; }

        [StringLength(250)]
        public string TenSanPham { get; set; }

        [StringLength(50)]
        public string avatar { get; set; }

        public double? dongia { get; set; }

        public virtual donhang donhang { get; set; }

        public virtual sanpham sanpham { get; set; }
    }
}
