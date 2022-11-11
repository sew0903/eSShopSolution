using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ThriftShop.Helpers;
using ThriftShop.Models;

namespace ThriftShop.Controllers.AdminArea
{
    public class UserManagermentController : Controller
    {
        SneakerThriffEntities db = new SneakerThriffEntities();
        static int flag = 0;
        [HttpGet]
        //Login 
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            Nguoi_dung acc_admin = new Nguoi_dung();
            Session["current_login_admin"] = acc_admin;
            if (acc_admin != null)
            {
                RedirectToAction("Index", "Products");
            }
            string str_username = f["exampleInputUsername"].ToString();
            string str_passwd = f["exampleInputPassword"].ToString();

            Nguoi_dung user = db.Nguoi_dung.SingleOrDefault(x => x.tai_khoan == str_username && x.mat_khau == str_passwd && x.id_quyen == 1);
            if (user != null)
            {
                ViewBag.ThongBao = "Chúc mừng bạn đã đăng nhập thành công";
                Session["current_login_admin"] = user;
                Response.Write("<script>alert('Chúc mừng bạn đăng nhập thành công!!!')</script>");
                return RedirectToAction("Index", "Products");
            }
            else if (user == null)
            {
                Response.Write("<script>alert('Mời bạn kiểm tra lại thông tin!!!')</script>");
                return View();
            }
            return RedirectToAction("Index", "Products");
        }
        // GET: UserManagerment
        public ActionResult userManagerments(int? page)
        {
            if (page == null) page = 1;
            var links = db.Nguoi_dung.ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (flag == 1)
            {
                Response.Write("<script>alert('Success!!!')</script>");
            }
            flag=0;
            return View(links.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult deleteUser(int id)
        {
            var user = db.Nguoi_dung.SingleOrDefault(x => x.id_user == id);
            if (user == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult deleteUser(int id, FormCollection f)
        {
            //KT user
            var user = db.Nguoi_dung.SingleOrDefault(x => x.id_user == id);
            if (user == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var tich_diem = db.Tich_diem.SingleOrDefault(x => x.id_user == user.id_user);
            //var voucherU = db.Vouchers.SingleOrDefault(x => x.id_user == id_kh);
            //if (voucherU != null)
            //{
            //    db.Vouchers.Remove(voucherU);
            //}
            db.Nguoi_dung.Remove(user);
            db.Tich_diem.Remove(tich_diem);
            flag = 1;
            db.SaveChanges();
            return RedirectToAction("userManagerments", "UserManagerment");
        }
        //===========================================================
        public ActionResult listVoucher(int? page)
        {
            if (flag == 5)
            {
                Response.Write("<script>alert('Gửi voucher cho khách hàng thành công!!!')</script>");
            }
            flag = 0;
            if (page == null) page = 1;
            var links = db.Vouchers.ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(links.ToPagedList(pageNumber, pageSize));    
        }

        [HttpGet]
        public ActionResult addVoucher()
        {
            //if (flag == 1)
            //{
            //    Response.Write("<script>alert('Success!!!')</script>");
            //}
            //flag = 0;
            return View();
        }
        [HttpPost]
        public ActionResult resetVoucher()
        {
            List<int> listngay = new List<int>();
            var a = db.Vouchers.ToList();
            foreach (var i in a)
            {
                TimeSpan Time = (TimeSpan)(i.han_sd - DateTime.Now);
                if (Time.Days <= 0)
                {
                    db.Vouchers.Remove(i);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("listVoucher", "UserManagerment");
        }
        [HttpPost]
        public ActionResult addVoucher(FormCollection f)
        {
            //AddVoucher
            Voucher vch = new Voucher();
            var id = f["id_user"].ToString();
            string[] arrList = id.Split(' ');
            vch.id_user = int.Parse(arrList[0]);
            vch.code_voucher = RandomString(10, false);
            vch.han_sd = Convert.ToDateTime(f["expiry"].ToString());
            vch.sale = int.Parse(f["phantram"]);
            var user = db.Nguoi_dung.SingleOrDefault(x => x.id_user == vch.id_user);
            db.Vouchers.Add(vch);
            db.SaveChanges();
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Template/AddVoucher.html"));
            content = content.Replace("{{customer}}", user.ho_ten);
            content = content.Replace("{{giftcode}}", vch.code_voucher);
            content = content.Replace("{{date}}", DateTime.Now.ToString());
            content = content.Replace("{{phantram}}", f["phantram"]);
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
            MailHelpers ms = new MailHelpers();
            ms.SendMail(user.email, "GỬI TẶNG VOUCHER", content);
            flag = 5;
            return RedirectToAction("listVoucher", "UserManagerment");
        }
        public  ActionResult Voucher(int id_kh)
        {
            var voucher = db.Vouchers.Where(x => x.id_user == id_kh).ToList();
            return View(voucher);
        }

        //======================================
        public ActionResult PhanQuyen()
        {
            var listquyen = db.Phan_quyen.ToList();
            return View(listquyen);
        }
        //Add quyền


        //Random string
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 87)));
                sb.Append(c);
            }
            if (lowerCase)
            {
                return sb.ToString().ToLower();
            }
            return sb.ToString();
        }
    }
}