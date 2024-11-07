using LTQ_Webbangiay.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTQ_Webbangiay.Bussiness
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set;}
        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }

    
        public void AddToCart(CartItem item)
        {
            var existingItem = Items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Qty += item.Qty;
            }
            else
            {
                Items.Add(item);
            }
        }

        public void RemoveFromCart(int productId)
        {
            var itemToremove = Items.FirstOrDefault(i => i.Id == productId);
            if(itemToremove !=null)
            {
                Items.Remove(itemToremove);
            }
        }

        // Tính tổng tiền của giỏ hàng
        public float GetTotal()
        {
            return Items.Sum(i => i.Price * i.Qty);
        }

        
    }
}