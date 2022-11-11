using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThriftShop.Models;
using ThriftShop.Controllers;
using ThriftShop.Controllers.User;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using ThriftShop.Helpers;
using System.Threading.Tasks;

namespace ThriftShop.Controllers
{
    public class ThanhToanController : Controller
    {
        MailHelpers mailHelpers = new MailHelpers();
        public static string hoten = "";
        public static string diachi = "";
        public static string sdt = "";
        public static int? diem_tich_luy=0;
        public static int diem_sd = 0;
        public static int flag = 0;
        //TienSP
        private int? tien = 0;
        // GET: ThanhToan
        SneakerThriffEntities db = new SneakerThriffEntities();
        public ActionResult Payment()
        {
            diem_tich_luy = 0;
            var listDiem = db.Tich_diem.Where(x => x.id_user == LoginRegisterController.id_user).ToList();
            foreach(var item in listDiem)
            {
                diem_tich_luy += item.diem_tich_luy;
            }
            var listVoucher = db.Vouchers.Where(x=>x.id_user==LoginRegisterController.id_user).ToList();
            return View(listVoucher);
        }
        [HttpPost]
        public ActionResult Payment(FormCollection f)
        {
            if (LoginRegisterController.id_user != 0)
            {
                diem_sd = int.Parse(Request.Form["diem_tich_luy"].ToString());
                if (diem_sd == null)
                {
                    diem_sd = 0;
                }
                if (diem_sd > diem_tich_luy || diem_sd == null)
                {
                    Response.Write("<script>alert('Không hợp lệ !!!')</script>");
                    return RedirectToAction("Payment", "ThanhToan");
                }
            }
            return RedirectToAction("Delivery", "ThanhToan");
        }
       

        //Delivery
        public ActionResult Delivery()
        {
           
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> listCart = Session["Cart"] as List<GioHang>;
            ViewBag.sale = db.Kho_hang.ToList();
            return View(listCart);
        }

        [HttpPost]
        public ActionResult Delivery(FormCollection f)
        {
            Don_hang dh = new Don_hang();
            if (LoginRegisterController.id_user == 0)
            {
                dh.ten_kh = f["delivery_hoten"].ToString();
                dh.sdt = f["delivery_dienthoai"];
                dh.dia_chi = f["delivery_diachi"].ToString();
                dh.ngay_tao = DateTime.Now;
                dh.tinh_trang = "Chờ xác nhận";
            }
            else
            {
                dh.ten_kh = LoginRegisterController.userName;
                dh.sdt = f["delivery_dienthoai"];
                dh.dia_chi = f["delivery_diachi"].ToString();
                dh.ngay_tao = DateTime.Now;
                dh.tinh_trang = "Liên hệ số điện thoại:" + f["delivery_dienthoai"].ToString() + " để xác nhận";
            }
            //Lấy giỏ hàng
            List<GioHang> listCart = Session["Cart"] as List<GioHang>;
            //Thêm chi tiết đơn hàng
            foreach (var item in listCart)
            {
                Chi_tiet_don_hang ctdh = new Chi_tiet_don_hang();
                ctdh.id_don_hang = dh.id_don_hang;
                ctdh.ten_sp = item.s_ten_sp;
                ctdh.color = item.s_color;
                ctdh.anh_sp = item.s_anh_sp;
                ctdh.id_sp = item.s_id_sp;
                ctdh.so_luong = item.s_so_luong;
                ctdh.don_gia = item.s_don_gia;
                ctdh.thanh_tien = item.s_don_gia * item.s_so_luong;
                tien += item.s_so_luong * item.s_don_gia;
                db.Chi_tiet_don_hang.Add(ctdh);
                GioHangController.listGh.Remove(item);
            }
            dh.tong_tien = (tien*108/100)-diem_sd*1000;
            db.Don_hang.Add(dh);
            db.SaveChanges();
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Template/XacNhanDonHang.html"));
            content = content.Replace("{{customer}}",f["delivery_hoten"]);
            content = content.Replace("{{address}}", f["delivery_diachi"]);
            content = content.Replace("{{phonenumber}}", f["delivery_dienthoai"]);
            content = content.Replace("{{iddonhang}}", dh.id_don_hang.ToString());
            content = content.Replace("{{iddon}}", dh.id_don_hang.ToString());
            content = content.Replace("{{ngaytao}}", DateTime.Now.ToString());
            content = content.Replace("{{trangthai}}", "CHỜ XÁC NHẬN CỦA NHÂN VIÊN");
            content = content.Replace("{{tongtien}}", dh.tong_tien.ToString());
            content = content.Replace("{{thue}}", "8%");
            content = content.Replace("{{tienhang}}", tien.ToString());
            content = content.Replace("{{tienthanhtoan}}", dh.tong_tien.ToString());
            if (LoginRegisterController.id_user == 0)
            {
                content = content.Replace("{{email}}", f["delivery_email"]);
            }
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
            MailHelpers ms = new MailHelpers();
            if (LoginRegisterController.id_user != 0) 
            {
                ms.SendMail(LoginRegisterController.email, "XÁC NHẬN ĐẶT HÀNG THÀNH CÔNG", content);
            }
            else
            {
                ms.SendMail(f["delivery_email"], "XÁC NHẬN ĐẶT HÀNG THÀNH CÔNG", content);
            }
            ThanhToanController.flag = 1;
            Session["Cart"] = null;
            GioHangController.cart_numbers = 0;
            diem_sd= 0;
            flag = 1;
            return RedirectToAction("productsList","SanPham");
        }
       
        public   ActionResult Test()
        {
            List<int> listngay = new List<int>();
            var a = db.Vouchers.ToList();
            foreach(var i in a)
            {
                TimeSpan Time = (TimeSpan)(i.han_sd - DateTime.Now);
                listngay.Add(Time.Days);
            }
            ViewBag.test = listngay;
            return View();
        }

        //public void SendMail(string toEmailAddress,string subject, string content)
        //{
        //    var fromEmailAddress= ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
        //    var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
        //    var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
        //    var sMTPHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
        //    var sMTPPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
        //    bool enabledSSL = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());
        //    string body = content;
        //    MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress));
        //    message.Subject = subject;
        //    message.IsBodyHtml = true;
        //    message.Body = body;
        //    var client = new SmtpClient();
        //    client.Credentials = new    NetworkCredential(fromEmailAddress, fromEmailPassword);
        //    client.Host = sMTPHost;
        //    client.EnableSsl = enabledSSL;
        //    client.Port = int.Parse("587");
        //    client.Send(message);
        //}

        
    }
}