using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThriftShop.Models;

namespace ThriftShop.Models
{
    public class GioHang
    {
        SneakerThriffEntities db = new SneakerThriffEntities();

        public int s_id_sp { get; set; }
        public string s_anh_sp { get; set; }
        public string s_ten_sp { get; set; }
        public string s_color { get; set; }
        public int s_size { get; set; }
        public int s_so_luong { get; set; }

        public int s_hangsx { get; set; }
        public Nullable<int> s_don_gia { get; set; }
        public int s_thanh_tien { get; set; }

        public string size { get; set; }

        //Thanh toán
        public int ThanhTien()
        {
            if(s_so_luong!=null && s_don_gia != null)
            {
                var tt = s_so_luong * s_don_gia;
                return (int)tt;
            }
            return 0;
        }
        public int sl()
        {
            int sl = 0;
            List<GioHang> lst = new List<GioHang>();
            foreach(var item in lst)
            {
                sl += item.s_so_luong;
            }
            return sl;
        }

        //Hàm tạo giỏ sp
      
        public GioHang(int id_sp)
        {
            s_id_sp = id_sp;
            San_pham sp = db.San_pham.SingleOrDefault(x => x.id_sp == s_id_sp);
            s_ten_sp = sp.ten_sp;
            s_anh_sp = sp.anh_sp;
            s_don_gia = (int?)sp.gia_ban;
            s_color = sp.color;
            //s_don_gia = int.Parse(sp.gia_ban.Value);
            s_so_luong = 1;
            s_hangsx = (int)sp.id_hangsx;
  
        }
    }
}