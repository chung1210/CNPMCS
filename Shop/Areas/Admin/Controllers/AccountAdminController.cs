using ShopDegreyConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class AccountAdminController : Controller
    {
        // GET: Admin/AccountAdmin
        public ActionResult Index()
        {
            var db = new ShopDegreyConnectionDB();
            return View(db.Query<AspNetUser>("select * from AspNetUsers"));
        }
        public ActionResult Delete(String id, AspNetUser asp)
        {
            try
            {
                var db = new ShopDegreyConnectionDB();
                db.Delete("AspNetUsers", "Id", asp, id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}