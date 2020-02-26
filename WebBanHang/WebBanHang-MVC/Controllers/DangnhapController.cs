using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang_MVC.Models;

namespace WebBanHang_MVC.Controllers
{
    public class DangnhapController : Controller
    {
        // GET: Dangnhap
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection f)
        {
            
            string TK = f.Get("txtUser").ToString();
            string MK = f.Get("txtpass").ToString();
          
            user dangnhap = db.users.SingleOrDefault(n => n.Username == TK && n.Password == MK);
            if (dangnhap != null)
            {

                Session["TaiKhoan"] = dangnhap;
                return RedirectToAction("Index", "home");
            }
            else
            {
                ViewBag.loi = "Đăng nhập không đúng";
                return View("DangNhap");
            }
            
        }
        public ActionResult Dangki()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangki(user users)
        {
           

            if (ModelState.IsValid)
            {
                users.ngaytao = DateTime.Now;
                db.users.Add(users);
                db.SaveChanges();
                return RedirectToAction("dangnhap");
            }

           
            return View(users);
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return new RedirectResult("DangNhap");
        }
    }
}