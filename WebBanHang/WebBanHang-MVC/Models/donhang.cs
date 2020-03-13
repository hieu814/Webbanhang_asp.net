namespace WebBanHang_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("donhang")]
    public partial class donhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public donhang()
        {
            GioHangs = new HashSet<GioHang>();
        }

        public int id { get; set; }

        public int trangthai { get; set; }

        public int user_id { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }

        [StringLength(15)]
        [Display(Name = "Số điện thoại")]
        public string user_soDT { get; set; }
        [Display(Name = "Thành tiền")]
        public int thanhtien { get; set; }
        [Display(Name = "Ngày đặt")]
        public DateTime? ngaytao { get; set; }
        [Display(Name = "Ngày hoàn thành")]
        public DateTime? ngayxn { get; set; }
        [Display(Name = "Ghi chú")]
        public string ghichu { get; set; }
        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}
