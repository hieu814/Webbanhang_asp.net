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
    public class sanphamsController : Controller
    {
        private Model1 db = new Model1();

        // GET: admin/Sanphams
        public ActionResult Index()
        {
            var sanphams = db.sanphams.Include(s => s.Danhmuc);
            ViewBag.sanphams = sanphams;
            return View(sanphams.ToList());
        }

        // GET: admin/Sanphams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sanpham = db.sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // GET: admin/Sanphams/Create
        public ActionResult Create()
        {
            ViewBag.ID_danhmuc = new SelectList(db.Danhmucs, "id", "tenHDT");
            return View();
        }

        // POST: admin/Sanphams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, sanpham sanphams)
        {
            if (file != null)
            {
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/images/sanpham/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);
                sanphams.avatar = ImageName;
            }

            if (ModelState.IsValid)
            {

                db.sanphams.Add(sanphams);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_danhmuc = new SelectList(db.Danhmucs, "id", "tenHDT", sanphams.ID_danhmuc);
            return View(sanphams);
        }

        // GET: admin/Sanphams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sanpham = db.sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_danhmuc = new SelectList(db.Danhmucs, "id", "tenHDT", sanpham.ID_danhmuc);
            return View(sanpham);
        }

        // POST: admin/Sanphams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, sanpham sanpham)
        {
            if (file != null)
            {
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/images/sanpham/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);               
                sanpham.avatar = ImageName;
            }
            if (ModelState.IsValid)
            {

                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_danhmuc = new SelectList(db.Danhmucs, "id", "tenHDT", sanpham.ID_danhmuc);
            return View(sanpham);
        }

        // GET: admin/Sanphams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sanpham = db.sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // POST: admin/Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sanpham sanpham = db.sanphams.Find(id);
            db.sanphams.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("Index");
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
