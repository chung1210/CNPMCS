using ShopDegreyConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models.BUS
{
    public class HoaDonBUS
    {
        public static IEnumerable<HoaDon> DanhSachAdmin()
        {
            var db = new ShopDegreyConnectionDB();
            return db.Query<HoaDon>("select * from HoaDon ");
        }
    }
}