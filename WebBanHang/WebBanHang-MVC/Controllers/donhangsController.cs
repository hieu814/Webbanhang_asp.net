using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebBanHang_MVC.Models;
using System;

namespace WebBanHang_MVC.Controllers
{
    public class donhangsController : Controller
    {
        private Model1 db = new Model1();

        // GET: donhangs
        public ActionResult Index()
        {
            user user = Session["TaiKhoan"] as user;

            var donhangs = (from i in db.donhangs where i.user_id == user.id && i.trangthai>0 select i);
            return View(donhangs.ToList());
        }


        public ActionResult TaoDonHang()
        {
            ViewBag.user_id = new SelectList(db.users, "id", "Ten");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoDonHang(donhang dh)
        {
            try
            {

                user user = Session["TaiKhoan"] as user;
               // int x = user.id;
                //them don hang
                List<GioHang> giohang = Session["giohang"] as List<GioHang>;
                Session["giohang"] = null;
                //donhang a = new donhang();               
                dh.user_id = user.id;
                dh.trangthai = 1;
                
                db.donhangs.Add(dh);
                db.SaveChanges();
                dh.thanhtien = giohang.Sum(m => m.tongsotien);
                foreach (GioHang i in giohang)
                {
                    i.id_donhang = dh.id;
  //                  i.tongsotien = i.soluong * i.dongia;
                    db.GioHangs.Add(i);
                    //tt =dh.thanhtien+ i.tongsotien;
                }
                if (ModelState.IsValid)
                {
                    dh.ngaytao = DateTime.Now;
                    db.Entry(dh).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                return View(dh);

            }
            catch
            {
                return RedirectToAction("dangnhap","dangnhap");
            }

            //ViewBag.user_id = new SelectList(db.users, "id", "Ten", donhang.user_id);
        }

        public RedirectToRouteResult huydon(int id_donhang)
        {
            List<GioHang> gh = (from i in db.GioHangs where i.id_donhang == id_donhang select i).ToList();
            GioHang itemXoa = null;
            foreach(GioHang i in gh)
            {
                itemXoa = db.GioHangs.Find(i.id);
                db.GioHangs.Remove(itemXoa);
                db.SaveChanges();
            }
            if (ModelState.IsValid)
            {
                List<donhang> x = (from i in db.donhangs where i.id == id_donhang select i).ToList();
                donhang dh = x[0];
                dh.trangthai = 0;
                db.Entry(dh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }
}
