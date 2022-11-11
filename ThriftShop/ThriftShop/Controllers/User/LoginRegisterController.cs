using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThriftShop.Models;
using ThriftShop.Helpers;
using System.Configuration;

namespace ThriftShop.Controllers.User
{
    public class LoginRegisterController : Controller
    {
        //string user_name
        public static int id_user = 0;
        public static string login_user_name = null;
        public static string userName = null;
        public static string soDienThoai = null;
        public static string diaChi = null;
        public static string email = null;
        //Object db
        SneakerThriffEntities db = new SneakerThriffEntities();
        // GET: LoginRegister
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            Nguoi_dung current_user = new Nguoi_dung();
            Session["current_login"] = current_user;
            if (current_user != null)
            {
                RedirectToAction("Index", "Home");
            }
            string str_username = f["tai_khoan"].ToString();
            string str_passwd = f["mat_khau"].ToString();

            Nguoi_dung user = db.Nguoi_dung.SingleOrDefault(x => x.tai_khoan == str_username && x.mat_khau == str_passwd && x.id_quyen==3);
            if (user != null)
            {
                ViewBag.ThongBao = "Chúc mừng bạn đã đăng nhập thành công";
                Session["current_login"] = user;
                id_user = user.id_user;
                login_user_name = user.id_user.ToString();
                userName = user.ho_ten;
                soDienThoai = user.so_dien_thoai;
                diaChi = user.dia_chi;
                email = user.email;
                return RedirectToAction("productsList", "SanPham");
            }
            ViewBag.ThongBao = "Mời bạn kiểm tra lại thông tin!!!";
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["current_login"] = null;
            id_user = 0;
            login_user_name = null;
            userName = null;
            soDienThoai = null;
            diaChi = null;
            Response.Write("<script>alert('Đăng xuất thành công!!!')</script>");
            return RedirectToAction("productsList", "SanPham");
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        //GET Register
        [HttpPost]
        public ActionResult Register(FormCollection f)
        {
            Nguoi_dung nd = new Nguoi_dung();
            Tich_diem tich_diem = new Tich_diem();
            var txt_username = f["user_name"].ToString();
            var txt_email = f["register_email"].ToString();
            //if (email == null)
            //{
            //    email = "null";
            //}
            var flag = db.Nguoi_dung.Where(x => x.tai_khoan ==txt_username || x.email== txt_email).FirstOrDefault();
            if(flag == null)
            {
                nd.tai_khoan = Request.Form["user_name"];
                nd.mat_khau = Request.Form["passwd"];
                nd.ho_ten = Request.Form["hoten"];
                nd.so_dien_thoai = Request.Form["sdt"];
                nd.dia_chi = Request.Form["diachi"];
                nd.email = Request.Form["register_email"];
                nd.id_quyen = 3;
                db.Nguoi_dung.Add(nd);
                tich_diem.id_user = nd.id_user;
                tich_diem.diem_tich_luy = 10;
                tich_diem.diem_tich_luy = 15;
                db.Tich_diem.Add(tich_diem);
                db.SaveChanges();
                ViewBag.ThongBao = "Đăng kí thành công !";
                return RedirectToAction("Login", "LoginRegister");
            }
            else
            {
                ViewBag.ThongBao = "Tài khoản hoặc email đã tồn tại";
            }
            return View();
        }

        //Reset paswd
        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(FormCollection f)
        {
            RandomString random = new RandomString();
            MailHelpers sendMail = new MailHelpers();
            var tk = f["tai_khoan"].ToString();
            var email = f["email"].ToString();
            var nguoidung = db.Nguoi_dung.SingleOrDefault( x=> x.tai_khoan== tk && x.email==email && x.id_quyen==3);
            if (nguoidung == null)
            {
                ViewBag.ThongBao = "Tài khoản không tồn tại hoặc email không hợp lệ. Vui lòng kiểm tra lại!";
                return View();
            }
            nguoidung.mat_khau = random.randomString(10, false);
            //sendMail(nguoidung.email,"RESET MẬT KHẨU",)
            db.SaveChanges();
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Template/ResetPassword.html"));
            content = content.Replace("{{customer}}", nguoidung.ho_ten);
            content = content.Replace("{{newpassword}}", nguoidung.mat_khau);
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
            MailHelpers ms = new MailHelpers();
            ms.SendMail(nguoidung.email, "ĐẶT LẠI MẬT KHẨU", content);
            return RedirectToAction("Login", "LoginRegister");
        }
    }
}