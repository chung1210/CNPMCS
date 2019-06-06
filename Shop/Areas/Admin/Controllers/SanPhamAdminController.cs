
using PagedList;
using ShopDegreyConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.IO;
using Shop.Models.BUS;

namespace Shop.Areas.Admin.Controllers
{
    public class SanPhamAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/SanPhamAdmin
        public ActionResult Index(int page = 1, int pagesize = 12)
        {

            return View(ShopBUS.DanhSachSP().ToPagedList(page, pagesize));
        }

        // GET: Admin/SanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public string LoadImages(string id)
        {
            var product = ShopBUS.ChiTiet(id);
            var images = product.Hinh;
            return images;
        }
        public string SaveImagePhoto(string productName)
        {
            var basePath = "~/Asset/images";
            var filename = "";
            var path = Server.MapPath(basePath);
            var savedFileName = "";

            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0)
            {
                filename = productName + Path.GetExtension(file.FileName);
                savedFileName = Path.Combine(path, filename);
                file.SaveAs(savedFileName);
            }
            //filename = (basePath + "/" + fileName).ToAbsoluteUrl()
            return string.Format("{0}", filename);
        }
        // GET: Admin/SanPhamAdmin/Create
        public ActionResult Create()
        {

            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham");
            return View();
        }

        // POST: Admin/SanPhamAdmin/Create
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Create(SanPham sp)
        {
            try
            {
                sp.TinhTrang = "0";
                sp.SoLuongDaBan = 0;
                sp.LuotXem = 0;
                sp.TinhTrang = "1";
                sp.Hinh = SaveImagePhoto(sp.MaSanPham);
                // TODO: Add insert logic here
                ShopBUS.InsertSP(sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Edit/5
        public ActionResult Edit(String id)
        {

            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham", ShopBUS.ChiTiet(id).MaLoaiSanPham);
            return View(ShopBUS.ChiTiet(id));
        }

        // POST: Admin/SanPhamAdmin/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(String id, SanPham sp)
        {
            var tam = ShopBUS.ChiTiet(id);
            try
            {
                // TODO: Add update logic here
                sp.Hinh = tam.Hinh;
                if (sp.SoLuongDaBan > 10000)
                {
                    sp.SoLuongDaBan = 0;
                }
                else { sp.SoLuongDaBan = tam.SoLuongDaBan; }
                if (sp.LuotXem > 10000) { sp.LuotXem = 0; } else { sp.LuotXem = tam.LuotXem; }
                sp.TinhTrang = tam.TinhTrang;
                ShopBUS.UpdateSP(id, sp);
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Delete(String id, SanPham sp)
        {
           // var tam = ShopBUS.ChiTiet(id);
            try
            {
                // TODO: Add delete logic here
                //if (tam.SoLuongDaBan > 10)
                //{
                //    tam.SoLuongDaBan = 0;
                //}
                //if (tam.LuotXem > 10) { tam.LuotXem = 0; }
                //if (tam.TinhTrang == "1         ") { tam.TinhTrang = "0         "; }
                //else
                //{
                //    tam.TinhTrang = "1         ";
                //}

                //ShopBUS.UpdateSP(id, tam);
                ShopBUS.DeleteSP(id, sp);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
