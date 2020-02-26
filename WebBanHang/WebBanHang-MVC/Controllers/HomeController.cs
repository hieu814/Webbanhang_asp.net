using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang_MVC.Models;

namespace WebBanHang_MVC.Controllers
{
    public class HomeController : Controller
    {
        Model1 data = new Model1();
        public ActionResult Index()
        {
            var danhmuc = (from i in data.Danhmucs select i).ToList();
            var sanphamnoibat = (from i in data.sanphams where i.soluong >0 select i).Take(4).ToList();
            

            var sanphammoi = (from i in data.sanphams orderby i.id descending select i).Take(8).ToList();

            ViewBag.danhmuc = danhmuc;
            ViewBag.sanphamnoibat = sanphamnoibat;
            ViewBag.sanphammoi = sanphammoi;
            return View();
        }

     
        public ActionResult Chitietsp(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sanpham = data.sanphams.Find(id);
            //sanpham sanpham2 = data.sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }
        public ActionResult Danhsach(string check, string tukhoa)
        {

            //id=1 lấy sản phẩm theo danh mục, id=2 tìm kiếm
            if (check=="ds")
            {
                int id = int.Parse(tukhoa);
                ViewBag.sanpham = (from i in data.sanphams where i.ID_danhmuc == id select i).ToList();
                Danhmuc dm = data.Danhmucs.Find(id);
                ViewBag.tieude = dm.tenHDT;

            }
            else
            {
                ViewBag.sanpham = (from i in data.sanphams where i.tenSP.Contains(tukhoa) || i.Hang.Contains(tukhoa) select i).ToList();
                ViewBag.tieude = "Kết quả tìm kiếm";
            }

            
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}