using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThriftShop.Models;
using ThriftShop.Controllers;
using ThriftShop.Controllers.User;

namespace ThriftShop.Controllers
{
    public class GioHangController : Controller
    {
        public static List<GioHang> listGh = new List<GioHang>();
        SneakerThriffEntities db = new SneakerThriffEntities();
        public static int cart_numbers = 0;
        //GET: Cart
        public List<GioHang> getCart()
        {
            List<GioHang> listCart = Session["Cart"] as List<GioHang>;
            if (listCart == null)
            {
                //Khởi tạo listCart nếu Session Cart chưa tt
                listCart = new List<GioHang>();
                Session["Cart"] = listCart;
            }
            return listCart;
        }

        //GET: addCart
        public ActionResult addCart(int id_sp, string url)
        {
            San_pham sp = db.San_pham.SingleOrDefault(x => x.id_sp == id_sp);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //kt giỏ hàng và lấy giỏ hàng
            List<GioHang> listCart = getCart();

            //Kt sp đã có trong giỏ chưa
            GioHang cart = listCart.Find(x => x.s_id_sp == id_sp);
            if (cart == null)
            {
                cart = new GioHang(id_sp);
                listCart.Add(cart);
                listGh.Add(cart);
                cart_numbers += 1;
                return Redirect(url);
            }
            else
            {
                cart_numbers += 1;
                cart.s_so_luong++;
                return Redirect(url);
            }
            return View();
        }
        //Update cart
        public ActionResult CartUpdate( int id_sp, FormCollection f)
        {
            //Check id_sp
            San_pham sp_1 = db.San_pham.SingleOrDefault(x => x.id_sp == id_sp);
            if( sp_1 == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> listCart = getCart();
            GioHang sp = listCart.SingleOrDefault(x => x.s_id_sp == id_sp);
            if(sp!= null)
            {
                sp.s_so_luong = int.Parse(Request.Form["cart_sl"]);
                sp.size = Request.Form["size_p"].ToString();
            }

            return RedirectToAction("Cart");
        }

        public ActionResult DeleteCart(int id_sp)
        {
            //Check id_sp
            San_pham sp_1 = db.San_pham.SingleOrDefault(x => x.id_sp == id_sp);
            if (sp_1 == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> listCart = getCart();
            GioHang sp = listCart.SingleOrDefault(x => x.s_id_sp == id_sp);
            if (sp != null)
            {
                listCart.RemoveAll(x => x.s_id_sp == id_sp);
        
            }
            return RedirectToAction("Cart");
        }

        //Đặt hàng
        public ActionResult DatHang()
        {
            return View();
        }
       



        // GET: GioHang
        public ActionResult Cart()
        {
            int sl = 0;
            int tt = 0;
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> listCart = getCart();
            List<Kho_hang> kho_Hangs = new List<Kho_hang>();
            var sp_kho = db.Kho_hang.ToList();
            foreach (var item in listCart)
            {
                sl += item.s_so_luong;
                if (item.ThanhTien() != null)
                {
                    tt += item.ThanhTien();
                }        
            }
            foreach(var item in listCart)
            {
                foreach(var x in sp_kho)
                {
                    if (item.s_id_sp == x.id_sp)
                    {
                        kho_Hangs.Add(x);
                    }
                }
            }
            ViewBag.size = kho_Hangs;
            ViewBag.SL = sl;
            cart_numbers = sl;
            ViewBag.TT = tt;
            //getSize
            return View(listCart);
        }
    }
}