using Shop.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class HoaDonAdminController : Controller
    {
        // GET: Admin/HoaDonAdmin
        public ActionResult Index()
        {
            var db = HoaDonBUS.DanhSachAdmin();
            return View(db);
        }
    }
}