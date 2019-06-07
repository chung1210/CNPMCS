using PagedList;
using Shop.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        public ActionResult KetQuaTimKiem(string timkiem,  string MaLoaiSanPham, int page = 1, int pagesize = 9)
        {

            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSachAdmin(), "MaLoaiSanPham", "TenLoaiSanPham");
            var db = TimKiemBUS.TimKiem(timkiem, MaLoaiSanPham).ToPagedList(page, pagesize);
             return View(db);

        }
    }
}