using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThriftShop.Models;

namespace ThriftShop.Controllers
{
    public class HomeController : Controller
    {
        SneakerThriffEntities db = new SneakerThriffEntities();
        // GET: Home
        public ActionResult Index()
        {
            
            //Nike
            ViewBag.listNike = db.San_pham.Where(x => x.id_hangsx == 1).Take(5).OrderBy(x => x.luot_xem).ToList();
            //Adidas
            ViewBag.listAdidas = db.San_pham.Where(x => x.id_hangsx == 2).Take(5).OrderBy(x => x.luot_xem).ToList();
            //Converse
            ViewBag.listConverse = db.San_pham.Where(x => x.id_hangsx == 3).Take(5).OrderBy(x => x.luot_xem).ToList();
            //New Balance
            ViewBag.listBalance = db.San_pham.Where(x => x.id_hangsx == 4).Take(5).OrderBy(x => x.luot_xem).ToList();
            return View();
        }
    }
}