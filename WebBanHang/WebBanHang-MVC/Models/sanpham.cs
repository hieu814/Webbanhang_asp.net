namespace WebBanHang_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sanpham")]
    public partial class sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sanpham()
        {
            GioHangs = new HashSet<GioHang>();
        }

        public int id { get; set; }

        public int ID_danhmuc { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tên sản phẩm")]
        public string tenSP { get; set; }
        [Display(Name = "Giá")]
        public double gia { get; set; }
        [Display(Name = "Khuyến mãi")]
        public int? khuyenmai { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
        public string avatar { get; set; }

        public DateTime? ngaytao { get; set; }
        [Display(Name = "Số lượng")]
        public int? soluong { get; set; }
        [Display(Name = "Chi tiết")]
        public string chitiet { get; set; }

        [StringLength(50)]
        [Display(Name = "Hãng")]
        public string Hang { get; set; }

        public virtual Danhmuc Danhmuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}
