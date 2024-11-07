using LTQ_Webbangiay.Bussiness;
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
        private const string CartSessionKey = "CartSession";
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
        public ActionResult AddToCart(int Id, string name,string image,float price, int qty = 1)
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

        // GET: Cart
        public ActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }
    }
}