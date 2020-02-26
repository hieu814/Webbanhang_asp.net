namespace WebBanHang_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("admin")]
    public partial class admin
    {
        public int id { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Họ và tên")]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên tài khoản")]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
        public string password { get; set; }

    }
}
