using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QL_bangiay_buoi2.Bussiness
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; }
        public ShoppingCart()
        {
            Items=new List<CartItem>()
        }
        public void AddItem(CartItem item)
        {
            var existingItem = Items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Qty += item.Qty;   // Nếu sản phẩm đã có trong giỏ, tăng số lượng
            }
            else
            {
                Items.Add(item);  // Nếu chưa có, thêm sản phẩm mới vào giỏ hàng
            }
        }
        // Phương thức để xóa một sản phẩm khỏi giỏ hàng
        public void RemoveItem(int productId)
        {
            var item = Items.FirstOrDefault(i => i.Id == productId);
            if (item != null)
            {
                Items.Remove(item);  // Xóa sản phẩm khỏi giỏ hàng
            }
        }
        // Phương thức tính tổng tiền của giỏ hàng
        public float GetTotal()
        {
            return Items.Sum(i => i.Price * i.Quantity);   // Tổng tiền = giá x số lượng
        }
    }
}