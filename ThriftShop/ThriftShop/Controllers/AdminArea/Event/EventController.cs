using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThriftShop.Controllers.AdminArea.Event
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Chart()
        {
            var t1 = 1;
            var t2 = 2;
            var t3 = 3;
            var t4 = 4;
            var t5 = 5;
            var t6 = 6;
            var t7 = 7;
            var t8 = 8;
            var t9 = 9;
            var t10 = 10;
            var t11 = 11;
            var t12 = 12;
            ViewBag.T1 = t1;
            ViewBag.T2 = t2;
            ViewBag.T3 = t3;
            ViewBag.T4 = t4;
            ViewBag.T5 = t5;
            ViewBag.T6 = t6;
            ViewBag.T7 = t7;
            ViewBag.T8 = t8;
            ViewBag.T9 = t9;
            ViewBag.T10 = t10;
            ViewBag.T11 = t11;
            ViewBag.T12 = t12;
            return View();
        }
    }
}