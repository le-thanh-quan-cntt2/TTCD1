﻿using System.Web;
using System.Web.Mvc;

namespace web_bán_giày_ttcd
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
