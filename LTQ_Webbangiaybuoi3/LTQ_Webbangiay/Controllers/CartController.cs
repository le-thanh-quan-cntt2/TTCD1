using LTQ_Webbangiay.Bussiness;
using LTQ_Webbangiay.Models;
using LTQ_Webbangiay.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTQ_Webbangiay.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "ShoppingCart";
        QL_BanHang1Entities db = new QL_BanHang1Entities();
        
        // Lấy giỏ hàng từ Session hoặc tạo mới nếu chưa có
        private ShoppingCart GetCart()
        {
            var cart = Session[CartSessionKey] as ShoppingCart;
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session[CartSessionKey] = cart;
            }
            return cart;
        }
        // Thêm sản phẩm vào giỏ hàng
        public ActionResult AddToCart(int Id, string name,string image,float price, int qty=1)
        {
           
            var cart = GetCart();
            var item = new CartItem
            {
                Id = Id,
                Name = name,
                Image = image,
                Price = price,
                Qty = qty ,
                Total=price*qty,
        };
            cart.AddToCart(item);
            return RedirectToAction("Index");

        }
        public ActionResult UpdateToCart(int id, int qty )
        {

            var cart = GetCart();
            cart.UpdateToCart(id,qty);
            return RedirectToAction("Index");

        }

        // GET: Cart
        public ActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }
        // Thông tin thanh toán
        public ActionResult ThongTinThanhToan()
        {
            var cart = GetCart();
            return View(cart);
        }
        public ActionResult ThanhToan(FormCollection form)
        {
            // lấy thông tin khách hàng
            var ten_nguoi_nhan = form["Ten_Nguoi_Nhan"];
            var diachi_nguoi_nhan =form ["Dia_Chi_Nhan"];
            var dienthoai_nguoi_nhan = form["Dien_Thoai_Nhan"];

            // Tạo đơn hàng (thêm mới một đơn hàng vào bảng DON_HANG
            DON_HANG don_hang = new DON_HANG();
            DateTime dt = DateTime.Now;
            don_hang.MaDH = "DH"+dt.ToString();
            don_hang.Ten_Nguoi_Nhan = ten_nguoi_nhan;
            don_hang.Dia_Chi_Nhan = diachi_nguoi_nhan;
            don_hang.Dien_Thoai_Nhan = dienthoai_nguoi_nhan;
            don_hang.Ngay_dat = dt;
            don_hang.Trang_thai = 0;
            db.DON_HANG.Add(don_hang);
            db.SaveChanges();

            //Lấy mã đơn hang  mới nhất thêm vào chi tiết đơn hàng
            int maxID_HD = db.DON_HANG.Max(x => x.ID);
            var cart = GetCart();

            foreach(var item in cart.Items)
            {
                CHI_TIET_DON_HANG ct = new CHI_TIET_DON_HANG();
                ct.ID_DH = maxID_HD;
                ct.ID_SP = item.Id;
                ct.So_luong = item.Qty;
                ct.Don_Gia = item.Price;
                db.CHI_TIET_DON_HANG.Add(ct);
                db.SaveChanges();
               
            }    

            return Redirect("/");
        }
    }
}