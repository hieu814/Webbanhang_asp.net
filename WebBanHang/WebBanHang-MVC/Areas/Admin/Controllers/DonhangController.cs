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
        [HttpPost]
        //public ActionResult Chitietdonhang(int id)
        //{

        //    return View();
        //}
        // GET: Admin/Donhang/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.users, "id", "Ten");
            return View();
        }

        // POST: Admin/Donhang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,trangthai,user_id,Diachi,user_soDT,thanhtien,ngaytao")] donhang donhang)
        {
            if (ModelState.IsValid)
            {
                db.donhangs.Add(donhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.users, "id", "Ten", donhang.user_id);
            return View(donhang);
        }

        // GET: Admin/Donhang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donhang donhang = db.donhangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.users, "id", "Ten", donhang.user_id);
            return View(donhang);
        }

        // POST: Admin/Donhang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,trangthai,user_id,Diachi,user_soDT,thanhtien,ngaytao")] donhang donhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.users, "id", "Ten", donhang.user_id);
            return View(donhang);
        }

        // GET: Admin/Donhang/Delete/5
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
                if (donhang.trangthai == tt && tt!=2)
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
