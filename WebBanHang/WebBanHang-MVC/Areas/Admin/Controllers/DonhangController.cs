using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang_MVC.Models;

namespace WebBanHang_MVC.Areas.Admin.Controllers
{
    public class DonhangController : BaseController
    {
        private Model1 db = new Model1();

        // GET: Admin/Donhang
        public ActionResult Index(string loaidonhang)
        {
            if (loaidonhang == null)
            {
                var ds = db.donhangs.Include("user");
                return View(ds.ToList());
            }
            else
            {
                int a = int.Parse(loaidonhang);
                var ds = db.donhangs.Include("user").Where(x=> x.trangthai==a);
                return View(ds.ToList());

            }
  //          var d = ds;
            //var donhanggs = db.donhangs.Include("user");
            //var ds = from i in donhanggs where i.trangthai == x select i;
            
        }

        // GET: Admin/Donhang/Details/5
        public ActionResult Chitietdonhang(int id)
        {
            var ct = (from i in db.GioHangs where i.id_donhang == id select i).ToList();
            donhang donhang = db.donhangs.Find(id);
            ViewBag.gh = ct;
            return View(donhang);
        }
        
        public RedirectToRouteResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                donhang donhang = db.donhangs.Find(id);
                db.donhangs.Remove(donhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public RedirectToRouteResult CapnhatTT(int? id,int tt)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {           
                donhang donhang = db.donhangs.Find(id);
                if (donhang.trangthai == tt && tt!=3)
                {
                    donhang.trangthai++;

                }
                else
                {
                    donhang.ngayxn = DateTime.Now;
                }
                db.Entry(donhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
