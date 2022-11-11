using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ThriftShop.Models;

namespace ThriftShop.Controllers.AdminArea
{
    public class ProductsController : Controller
    {
        //Static
        static int id = 0;
        static int del_flag = 0;
        // GET: Products
        SneakerThriffEntities db = new SneakerThriffEntities();
        //GetProducts
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var links = db.San_pham.ToList();
            string tb = "Success";
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (del_flag == 1)
            {
                Response.Write("<script>alert('Success!!!')</script>");
                del_flag = 0;
            }           
            return View(links.ToPagedList(pageNumber, pageSize));
        }
        //AddProducts
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(FormCollection f)
        {
            //Đặt flag
            ViewBag.flag = 0;
            //Thêm sp
            San_pham sp = new San_pham();
            sp.ten_sp = Request.Form["name"].ToString();
            sp.color = Request.Form["color"].ToString();
            sp.mo_ta_sp = Request.Form["describe"].ToString();
            sp.anh_sp = Request.Form["image"].ToString();
            sp.ngay_sx = Convert.ToDateTime(Request.Form["importdate"].ToString());
            sp.luot_xem = 0;
            sp.luot_tim_kiem = 0;
            sp.gia_ban = 0;
            if (Request.Form["brand"].ToString() == "Nike")
            {
                sp.id_hangsx = 1;
            }
            else if (Request.Form["brand"].ToString() == "Adidas")
            {
                sp.id_hangsx = 2;
            }
            else if (Request.Form["brand"].ToString() == "Converse")
            {
                sp.id_hangsx = 3;
            }
            db.San_pham.Add(sp);

            //Thêm vào kho
            Kho_hang kh = new Kho_hang();
            kh.id_sp = sp.id_sp;
            kh.ten_sp = sp.ten_sp;
            if (sp.id_hangsx == 1) { kh.ten_hangsx = "Nike"; }
            else if (sp.id_hangsx == 2) { kh.ten_hangsx = "Adidas"; }
            else if (sp.id_hangsx == 3) { kh.ten_hangsx = "Converse"; }
            kh.ngay_nhap = DateTime.Now;
            kh.color = sp.color;
            kh.so_luong = 0;
            kh.size = Request.Form["size"].ToString();
            kh.gia_nhap = 0;
            kh.gia_ban = 0;
            kh.saleOf = 0;
            db.Kho_hang.Add(kh);
            var kt = db.Kho_hang.SingleOrDefault(x => x.ten_sp == sp.ten_sp && x.size == kh.size);
            if (kt != null)
            {
                ViewBag.flag = 1;
                ViewBag.ThongBao = "Sản phẩm đã tồn tại!! Vui lòng kiểm tra lại ";
            }
            else
            {
                db.SaveChanges();
                del_flag = 1;
                return RedirectToAction("Index", "Products");
            }
            return View();
            ViewBag.flag = 0;
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var sp = db.San_pham.SingleOrDefault(x => x.id_sp == id);
            id = sp.id_sp;
            return View(sp);
        }
        [HttpPost]
        public ActionResult UpdateProduct(FormCollection f, int id)
        {
            //Kiểm tra
            San_pham sp = db.San_pham.SingleOrDefault(x => x.id_sp == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                //Update luôn kho hàng
                Kho_hang kho_Hang = db.Kho_hang.SingleOrDefault(x => x.id_sp == sp.id_sp);
                //Lưu dữ liệu chỉnh sữa
                sp.ten_sp = f["u_name"].ToString();
                kho_Hang.ten_sp = f["u_name"].ToString();
                sp.color = f["u_color"].ToString();
                kho_Hang.color = f["u_color"].ToString();
                if (f["u_brand"].ToString() == "Nike")
                {
                    sp.id_hangsx = 1;
                    kho_Hang.ten_hangsx = f["u_brand"].ToString();
                }
                else if (f["u_brand"].ToString() == "Adidas")
                {
                    sp.id_hangsx = 2;
                    kho_Hang.ten_hangsx = f["u_brand"].ToString();
                }
                else if (f["u_brand"].ToString() == "Converse")
                {
                    sp.id_hangsx = 3;
                    kho_Hang.ten_hangsx = f["u_brand"].ToString();
                }
                else
                {
                    sp.id_hangsx = 4;
                    kho_Hang.ten_hangsx = f["u_brand"].ToString();
                }
                sp.mo_ta_sp = f["u_describe"].ToString();
                sp.anh_sp = f["u_image"].ToString();
                db.SaveChanges();
            }
            del_flag = 1;
            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public ActionResult deleteProduct(int id)
        {
            //Tìm sp
            San_pham sp = db.San_pham.SingleOrDefault(x => x.id_sp == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }

        [HttpPost]
        public ActionResult deleteProduct(int id, FormCollection f)
        {
            //KT sp
            San_pham sp = db.San_pham.SingleOrDefault(x => x.id_sp == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                Kho_hang kh = db.Kho_hang.SingleOrDefault(x => x.id_sp == sp.id_sp);
                db.San_pham.Remove(sp);
                db.Kho_hang.Remove(kh);
                del_flag = 1;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Products");
        }
        //=========================================================================================================


        //KhoHang
        public ActionResult inventoryManagement(int? page)
        {
            ViewBag.img = db.San_pham.OrderBy(x=>x.id_sp).ToList();
            if (page == null) page = 1;
            var links = db.Kho_hang.OrderBy(x=> x.id_sp).ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (del_flag == 1)
            {
                Response.Write("<script>alert('Success!!!')</script>");
            }
            del_flag = 0;
            return View(links.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult updateInventory(int id)
        {
            var sp = db.Kho_hang.SingleOrDefault(x => x.id_sp == id);
            return View(sp);
        }
        [HttpPost]
        public ActionResult updateInventory(int id, FormCollection f)
        {
            //Kiểm tra sp
            var sp = db.Kho_hang.SingleOrDefault(x => x.id_sp == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                //Cập nhập lại thông tin sp trong kho
                sp.so_luong = int.Parse(f["up_number"]);
                sp.gia_ban = int.Parse(f["price"]);
                sp.saleOf = int.Parse(f["sale"]);
                db.SaveChanges();
            }
            del_flag = 1;
            return RedirectToAction("inventoryManagement", "Products");
        }
        //Addsize
        [HttpGet]
        public ActionResult addSize(int id)
        {
            var sp = db.San_pham.SingleOrDefault(x => x.id_sp == id);
            return View(sp);
        }
        [HttpPost]
        public ActionResult addSize(int id,FormCollection f)
        {
            var sp = db.Kho_hang.Where(x => x.id_sp == id).ToList();
            Kho_hang new_sp = new Kho_hang();
            foreach(var size in sp)
            {
                if (size.size == f["add_size"])
                {
                    return View();
                }
            }         
            new_sp.id_sp = sp[0].id_sp;
            new_sp.ten_sp = sp[0].ten_sp;
            new_sp.ten_hangsx = sp[0].ten_hangsx;
            new_sp.so_luong = 0;
            new_sp.size = f["add_size"].ToString();
            new_sp.color = sp[0].color;
            new_sp.gia_nhap = sp[0].gia_nhap;
            new_sp.gia_ban = 0;
            new_sp.saleOf = 0;
            new_sp.id_loai_sp = sp[0].id_loai_sp;
            db.Kho_hang.Add(new_sp);
            db.SaveChanges();
            del_flag = 1;
            return RedirectToAction("inventoryManagement", "Products");
        }
        //===================================================================================================
        //Đơn hàng
        [HttpGet]
        public ActionResult orderManagement(int? page)
        {
            if (del_flag == 10)
            {
                Response.Write("<script>alert('Success!!!')</script>");
            }
            if (page == null) page = 1;
            var links = db.Don_hang.ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            del_flag = 0;
            return View(links.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult orderManagement(int? page, int id,FormCollection f)
        {
            if (page == null) page = 1;
            var links = db.Don_hang.ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var dh = db.Don_hang.SingleOrDefault(x => x.id_don_hang == id);
            dh.tinh_trang = f["tinh_trang"].ToString();
            db.SaveChanges();
            Response.Write("<script>alert('Cập nhập thành công. Tình trạng đơn id:"+dh.id_don_hang+" hiện tại là:"+dh.tinh_trang+"!!!')</script>");
            return View(links.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult deleteOrder(int id)
        {
            var dh= db.Don_hang.SingleOrDefault(x=> x.id_don_hang==id);
            return View(dh);
        }
        [HttpPost]
        public ActionResult deleteOrder(FormCollection f, int id)
        {
            var dh = db.Don_hang.SingleOrDefault(x => x.id_don_hang == id);
            var ctdh = db.Chi_tiet_don_hang.Where(x => x.id_don_hang == id).ToList();
            foreach(var item in ctdh)
            {
                dh.Chi_tiet_don_hang.Remove(item);
            }
            db.Don_hang.Remove(dh);
            db.SaveChanges();
            del_flag = 10;
            return RedirectToAction("orderManagement", "Products");
        }
        //ChiTietDon
        public ActionResult DetailOrder(int id_dh)
        {
            var chitietdh = db.Chi_tiet_don_hang.Where(x => x.id_don_hang == id_dh).ToList();
            return View(chitietdh);
        }

        //====================================================================
        //2HAND
        public ActionResult productproductClassification()
        {
            var class2hand = db.Phan_loai_sp.ToList();
            return View(class2hand);
        }

        [HttpGet]
        public ActionResult addproductproductClassification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addproductproductClassification(int id_pClass)
        {
            return View();
        }
    }
}