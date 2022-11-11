using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThriftShop.Models;

namespace ThriftShop.Controllers.User
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        SneakerThriffEntities db = new SneakerThriffEntities();
        [HttpGet]
        public ActionResult UserProfile(int id)
        {

            var user = db.Nguoi_dung.SingleOrDefault(x => x.id_user == id);;
            return View(user);
        }
        [HttpPost]
        public ActionResult UserProfile( FormCollection f)
        {
            string email_s = f["email"].ToString();
            string sdt_s = f["sdt"].ToString();
            var user = db.Nguoi_dung.SingleOrDefault(x => x.id_user == LoginRegisterController.id_user);
            int countcheckmail = db.Nguoi_dung.Where(x => x.email == email_s).Count();
            int countchecksdt = db.Nguoi_dung.Where(x => x.so_dien_thoai == sdt_s).Count();
            var checkmail = db.Nguoi_dung.SingleOrDefault(x => x.email == email_s);
            var checksdt = db.Nguoi_dung.SingleOrDefault(x => x.so_dien_thoai == sdt_s);
            //Check
            if (LoginRegisterController.id_user != 0)
            {
                user.ho_ten = f["last_name"]+" " + f["first_name"];
                user.dia_chi = f["diachi"];
                if (countcheckmail == 1 && user.email!= email_s && checkmail == null)
                {           
                    user.email=f["email"];
                }
                if (countchecksdt == 1 && user.so_dien_thoai!=sdt_s && checksdt==null)
                {
                    user.so_dien_thoai = f["sdt"];
                }
                db.SaveChanges();
                return RedirectToAction("UserProfile", "UserProfile");
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult quanLyDon()
        {
            var user = db.Nguoi_dung.SingleOrDefault(x => x.id_user == LoginRegisterController.id_user);
            var donhang = db.Don_hang.Where(x => x.sdt == user.so_dien_thoai).ToList();
            return View(donhang);
        }
        public ActionResult detail(int id)
        {
            List<Chi_tiet_don_hang> chitiet = db.Chi_tiet_don_hang.Where(x => x.id_don_hang == id).ToList();
            return View(chitiet);
        }

        [HttpGet]
        public  ActionResult changePass()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult changePass(FormCollection f)
        {
            var user = db.Nguoi_dung.SingleOrDefault(x => x.id_user == LoginRegisterController.id_user);
            string passwd = f["password"].ToString();
            string new_passwd = f["new_pass"].ToString();
            string confirm_passwd = f["confirm_new_pass"].ToString();
            if (passwd != user.mat_khau)
            {
                Response.Write("<script>alert('Mật khẩu không đúng. Vui lòng keierm tra và nhập lại !!!!')</script>");
                return View();
            }
            else if(passwd == new_passwd)
            {
                Response.Write("<script>alert('Mật khẩu cũ và mật khẩu mới bị trùng nhau. Vui lòng nhập lại !!!')</script>");
                return View();
            }
            else if (new_passwd != confirm_passwd)
            {
                Response.Write("<script>alert('Nhập lại mật khẩu không chính xác. Vui lòng kiểm tra lại !!!')</script>");
                return View();
            }
            user.mat_khau = new_passwd;
            db.SaveChanges();
            Response.Write("<script>alert('Đổi mật khẩu thành công !!!')</script>");
            return View();
        }

        public ActionResult ThongKe()
        {
            var listdh = db.Don_hang.Where(x => x.sdt == LoginRegisterController.soDienThoai).ToList();
            var t1 = db.Don_hang.Where(n => (n.ngay_tao.Value.Month == 1)).Sum(n => n.tong_tien);
            var t2 = db.Don_hang.Where(n => (n.ngay_tao.Value.Month == 2)).Sum(n => n.tong_tien);
            var t3 = db.Don_hang.Where(n => (n.ngay_tao.Value.Month == 3)).Sum(n => n.tong_tien);
            var t4 = db.Don_hang.Where(n => (n.ngay_tao.Value.Month == 4)).Sum(n => n.tong_tien);
            var t5 = db.Don_hang.Where(n => (n.ngay_tao.Value.Month == 5)).Sum(n => n.tong_tien);
            var t6 = db.Don_hang.Where(n => (n.ngay_tao.Value.Month == 6)).Sum(n => n.tong_tien);
            var t7 = db.Don_hang.Where(n => (n.ngay_tao.Value.Month == 7)).Sum(n => n.tong_tien);
            var t8 = db.Don_hang.Where(n => (n.ngay_tao.Value.Month == 8)).Sum(n => n.tong_tien);
            var t9 = db.Don_hang.Where(n => (n.ngay_tao.Value.Month == 9)).Sum(n => n.tong_tien);
            var t10 = db.Don_hang.Where(n => (n.ngay_tao.Value.Month == 10)).Sum(n => n.tong_tien);
            var t11 = db.Don_hang.Where(n => (n.ngay_tao.Value.Month == 11)).Sum(n => n.tong_tien);
            var t12 = db.Don_hang.Where(n => (n.ngay_tao.Value.Month == 12)).Sum(n => n.tong_tien);
            ViewBag.T1 = t1 ?? 0;
            ViewBag.T2 = t2 ?? 0;
            ViewBag.T3 = t3 ?? 0;
            ViewBag.T4 = t4 ?? 0;
            ViewBag.T5 = t5 ?? 0;
            ViewBag.T6 = t6 ?? 0;
            ViewBag.T7 = t7 ?? 0;
            ViewBag.T8 = t8 ?? 0;
            ViewBag.T9 = t9 ?? 0;
            ViewBag.T10 = t10 ?? 0;
            ViewBag.T11 = t11 ?? 0;
            ViewBag.T12 = t12 ?? 0;
            return View();
        }
    }
}