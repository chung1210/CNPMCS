using ShopDegreyConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models.BUS
{
    public class TimKiemBUS
    {
        public static IEnumerable<SanPham> TimKiem(string TimKiem, string MaLoaiSanPham)
        {

            var db = new ShopDegreyConnectionDB();

            if ( MaLoaiSanPham == "" )
            {
                return db.Query<SanPham>("select * from SanPham where TenSanPham like '%" + TimKiem + "%'");
            }
            return db.Query<SanPham>("select * from SanPham where MaLoaiSanPham ='" + MaLoaiSanPham + "' AND TenSanPham like '%" + TimKiem + "%'");

        }
    }
}