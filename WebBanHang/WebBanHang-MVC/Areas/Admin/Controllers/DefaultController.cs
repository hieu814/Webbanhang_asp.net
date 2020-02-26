using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang_MVC.Models;

namespace WebBanHang_MVC.Areas.Admin.Controllers
{
    public class DefaultController : BaseController
    {
        // GET: Admin/Default
        Model1 db = new Model1();
        public ActionResult Index()

        {
            var ds = db.donhangs.Include("user").Where(x => x.trangthai == 1);
            var donhang = db.donhangs.Where(x => x.trangthai < 3).ToList();
            var sanpham = db.sanphams.ToList();
            ViewBag.sanpham = sanpham.Count;
            ViewBag.donhangmoi = donhang.Count();
            
            
            return View(ds.ToList());
        }
       

    }
}