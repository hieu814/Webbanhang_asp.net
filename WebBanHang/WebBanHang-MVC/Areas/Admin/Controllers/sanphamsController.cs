using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang_MVC.Models;
using System.IO;
namespace WebBanHang_MVC.Areas.Admin.Controllers
{
    public class sanphamsController : BaseController
    {
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            var sanphams = db.sanphams.Include(s => s.Danhmuc);
            ViewBag.sanphams = sanphams;
            return View(sanphams.ToList());
        }

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
        public ActionResult Create()
        {
            ViewBag.ID_danhmuc = new SelectList(db.Danhmucs, "id", "tenHDT");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, sanpham sanphams)
        {
            if (file != null)
            {
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/images/sanpham/" + ImageName);
                sanphams.ngaytao = DateTime.Now;
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
                //sanpham sanpham2 = db.sanphams.Find(sanpham.id);
                //sanpham.avatar = sanpham2.avatar;
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_danhmuc = new SelectList(db.Danhmucs, "id", "tenHDT", sanpham.ID_danhmuc);
            return View(sanpham);
        }

        public RedirectToRouteResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {

                
                sanpham sanpham = db.sanphams.Find(id);
                System.IO.File.Delete("~/images/sanpham/" + sanpham.avatar);
                db.sanphams.Remove(sanpham);
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
