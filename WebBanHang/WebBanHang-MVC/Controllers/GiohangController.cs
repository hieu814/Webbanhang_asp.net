using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang_MVC.Models;

namespace WebBanHang_MVC.Controllers
{
    public class GiohangController : Controller
    {
        // GET: Giohang
        Model1 db = new Model1();
        public ActionResult Index()
        {
            List<GioHang> giohang = Session["giohang"] as List<GioHang>;
            return View(giohang);
        }
        public RedirectToRouteResult ThemVaoGio(int id_sanpham)
        {
            if (Session["giohang"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<GioHang>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }

            List<GioHang> giohang = Session["giohang"] as List<GioHang>;  // Gán qua biến giohang dễ code
            //giohang.Count
            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa

            if (giohang.FirstOrDefault(m => m.id_sanpham == id_sanpham) == null) // ko co sp nay trong gio hang
            {
                sanpham sp = db.sanphams.Find(id_sanpham);  // tim sp theo sanPhamID

                GioHang newItem = new GioHang();
                newItem.id_sanpham = id_sanpham;
                    newItem.TenSanPham = sp.tenSP;
                    newItem.soluong = 1;
                    newItem.avatar = sp.avatar;
                newItem.dongia = sp.gia;


                    //to = sp.price

                giohang.Add(newItem);  // Thêm CartItem vào giỏ 
            }
            else
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                GioHang cardItem = giohang.FirstOrDefault(m => m.id_sanpham == id_sanpham);
                cardItem.soluong++;
            }

            // Action này sẽ chuyển hướng về trang chi tiết sp khi khách hàng đặt vào giỏ thành công. Bạn có thể chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); nếu muốn.
            // return RedirectToAction("ChiTiet", "SanPham", new { id = SanPhamID });
            return RedirectToAction("index");
        }
        public RedirectToRouteResult SuaSoLuong(int id_sanpham, int soluongmoi)
        {
            // tìm carditem muon sua
            List<GioHang> giohang = Session["giohang"] as List<GioHang>;
            GioHang itemSua = giohang.FirstOrDefault(m => m.id_sanpham == id_sanpham);
            if (itemSua != null)
            {
                itemSua.soluong = soluongmoi;
               
            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult XoaKhoiGio(int id_sanpham)
        {
            List<GioHang> giohang = Session["giohang"] as List<GioHang>;
            GioHang itemXoa = giohang.FirstOrDefault(m => m.id_sanpham == id_sanpham);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }

        // tien hanh dat hang

    }
}