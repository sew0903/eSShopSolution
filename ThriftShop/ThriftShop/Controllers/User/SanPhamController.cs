using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ThriftShop.Models;
namespace ThriftShop.Controllers.User
{
    public class SanPhamController : Controller
    {
        //Static
        public static string size = "";
        //Tạo obj db
        SneakerThriffEntities db = new SneakerThriffEntities();
        // GET: SanPham
        public ActionResult productsList(int? page)
        {
            if (ThanhToanController.flag == 1)
            {
                Response.Write("<script>alert('Đặt hàng thành công. Mời quý khách kiểm tra lại email!!!')</script>");
            }
            ThanhToanController.flag = 0;
            if (page == null) page = 1;
            var links = db.San_pham.ToList();
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(links.ToPagedList(pageNumber, pageSize));
        }

        //Chi_tiet_sp
        [HttpGet]
        public ActionResult tim_sp( int id)
        {
            var list = db.San_pham.Where(n => n.id_hangsx == id).ToList();
            return View(list);
        }

        //Tim theo ten
        public ActionResult getName(string name)
        {
            var listSP = db.San_pham.Where(x => x.ten_sp.Contains(name)).ToList();
            return View(listSP);
        }
       

        //Chi_tiet_sp
        public ActionResult Chi_tiet_sp(int id_sp)
        {
            var sl= db.Kho_hang.Where(x => x.id_sp == id_sp).FirstOrDefault();
            var size = db.Kho_hang.Where(x => x.id_sp == id_sp).ToList();
            List<Kho_hang> kho_Hangs = new List<Kho_hang>();
            foreach(var item in size)
            {
                foreach(var x in kho_Hangs)
                {
                    if (x.size == item.size) { break; }
                }
                kho_Hangs.Add(item);
            }
            var sp = db.San_pham.Where(x => x.id_sp == id_sp).FirstOrDefault();
            ViewBag.SoLuongSp = sl;
            ViewBag.SizeS = kho_Hangs;
            return View(sp);
        }
        [HttpPost]
        public ActionResult Chi_tiet_sp(int id_sp, FormCollection f)
        {
            //getCard
            List<GioHang> listCart = Session["Cart"] as List<GioHang>;
            if (listCart == null)
            {
                //Khởi tạo listCart nếu Session Cart chưa tt
                listCart = new List<GioHang>();
                Session["Cart"] = listCart;
            }
            //Check products in cart
            GioHang cart = listCart.Find(x => x.s_id_sp == id_sp && x.size!=f["size_value"].ToString());
            if(cart== null)
            {
                cart = new GioHang(id_sp);
                cart.size = f["size_value"];
                listCart.Add(cart);
                GioHangController.listGh.Add(cart);
                GioHangController.cart_numbers += 1;
                return RedirectToAction("Chi_tiet_sp", "SanPham", new { @id_sp = id_sp });
            }
            else
            {
                GioHangController.cart_numbers += 1;
                cart.s_so_luong++;
            }
            return View();
        }
       
    }
}