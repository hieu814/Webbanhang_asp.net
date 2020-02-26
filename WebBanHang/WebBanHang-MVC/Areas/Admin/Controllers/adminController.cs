using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang_MVC.Models;
namespace WebBanHang_MVC.Areas.Admin.Controllers
{
    public class adminController : Controller
    {
        // GET: Admin/admin
        Model1 db = new Model1();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            string TK = collection.Get("txtuser").ToString();
            string MK = collection.Get("txtpass").ToString();
            admin dangnhap = db.admins.SingleOrDefault(n => n.username == TK && n.password == MK);
            if (dangnhap != null)
            {

                Session["TaiKhoan"] = dangnhap;
                return RedirectToAction("Index", "default");
            }
            else
            {
                ModelState.AddModelError("", "Sai Email hoặc mật khẩu. Vui lòng thử lại!");
                return Redirect("Login");
            }
        }
    }
}