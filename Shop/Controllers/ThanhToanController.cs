using Microsoft.AspNet.Identity;
using Shop.Models.BUS;
using ShopDegreyConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ThanhToanController : Controller
    {
        [Authorize]
        // GET: ThanhToan
        public ActionResult Index()
        {
            List<GioHang> ds = GioHangBUS.DanhSach(User.Identity.GetUserId()).ToList();
            if (ds.Count() == 0)
            {
                return RedirectToAction("../Shop/index");
            }
            ViewBag.TongTien = GioHangBUS.TongTien(User.Identity.GetUserId());
            return View(ds);
        }
        [HttpPost]
        public ActionResult Them(string nguoinhan, string sdt, string diachi)
        {
            //try
            //{
                ThanhToanBUS.ThemOrder(nguoinhan, sdt, diachi, User.Identity.GetUserId());
                return RedirectToAction("../Shop/Index");
            //}
            //catch
            //{
            //    return RedirectToAction("../GioHang/Index");
            //}

        }
    }
}