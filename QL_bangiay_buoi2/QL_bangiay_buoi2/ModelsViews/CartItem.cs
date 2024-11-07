using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QL_bangiay_buoi2.ModelsViews
{
    public class Cartsitem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
        public float Price { get; set; }

        public float Total { get; set; }
    }
}