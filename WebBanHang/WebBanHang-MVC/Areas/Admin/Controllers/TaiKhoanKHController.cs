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
    public class TaiKhoanKHController : BaseController
    {
        private Model1 db = new Model1();


        public ActionResult Index()
        {
            return View(db.users.ToList());
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Ten,email,soDT,Username,Password,ngaytao")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public RedirectToRouteResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                user sanpham = db.users.Find(id);
                db.users.Remove(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


        }


    }
}
