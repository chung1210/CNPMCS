using Shop.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Xml.Linq;
using System.Net;

namespace Shop.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index(string valueINeed,int page = 1, int pagesize = 12)
        {
            var db = ShopBUS.DanhSach().ToPagedList(page, pagesize);
            return View(db);
        }

        //public ActionResult IndexASC(int page = 1, int pagesize = 12)
        //{
        //    var db = ShopBUS.DanhSachASC().ToPagedList(page, pagesize);
        //    return View(db);
        //}

        // GET: Shop/Details/5
        public ActionResult Details(String id, int page = 1, int pagesize = 12)
        {
            ShopBUS.CapNhatLuotView(id);
            var db = ShopBUS.ChiTiet(id);
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            string lstProduct = id;

            if (CheckCookie)
            {
                lstProduct = Request.Cookies["product"].Value;
                lstProduct = string.Format("{0},{1}", lstProduct, id);
            }
            HttpCookie cookies = new HttpCookie("product");
            cookies.Value = lstProduct;
            cookies.Expires = DateTime.Now.AddHours(24);
            Response.SetCookie(cookies);
            Response.Flush();
            ViewData["latest"] = lstProduct;
            return View(db);

        }
        public bool CheckCookie
        {
            get
            {
                object o = Request.Cookies["product"];
                if (o != null)
                    return true;
                return false;
            }
        }

        public string LoadImages(string id)
        {
            var product = ShopBUS.ChiTiet(id);
            var images = product.Hinh;

            return images;
        }
        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
