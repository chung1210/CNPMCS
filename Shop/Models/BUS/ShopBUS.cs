﻿using ShopWishConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Shop.Controllers;
namespace Shop.Models.BUS
{
    public class ShopBUS
    {

        public static IEnumerable<SanPham> DanhSach()
        {

            var db = new ShopWishConnectionDB();
            return db.Query<SanPham>("select * from SanPham where TinhTrang = '0             '");
        }
        public static SanPham ChiTiet(string a)
        {
            var db = new ShopWishConnectionDB();
            return db.SingleOrDefault<SanPham>("select * from SanPham where MaSanPham = @0", a);
        }
        public static IEnumerable<SanPham> HotItems()
        {
            var db = new ShopWishConnectionDB();
            return db.Query<SanPham>("select Top 9 * from SanPham where  TinhTrang='0' ORDER BY LuotView DESC ");
        }
       
        public static IEnumerable<SanPham> News()
        {
            var db = new ShopWishConnectionDB();
            return db.Query<SanPham>("select Top 6 * from SanPham where GhiChu=N'New' AND TinhTrang='0   '");
        }

        public static IEnumerable<SanPham> Related(string masp) //tự động truyền vào masp
        {
            var db = new ShopWishConnectionDB();
            return db.Query<SanPham>("select distinct S1.*  FROM SanPham S INNER JOIN SanPham S1 ON S.MaLoaiSanPham = S1.MaLoaiSanPham where S.MaSanPham='" + masp + "'");
        }
        public static IEnumerable<SanPham> Latest(string masp, string ck)
        {
            string lstProduct = ck.Replace(",", "','"); // để SQL hiểu format

            var db = new ShopWishConnectionDB();
            return db.Query<SanPham>("select distinct * FROM  SanPham WHERE MaSanPham IN ('" + lstProduct + "')");
        }
        //-------------------------------------------admin--------
        public static IEnumerable<SanPham> DanhSachSP()
        {
            var db = new ShopWishConnectionDB();
            return db.Query<SanPham>("select * from SanPham ");
        }
        public static void InsertSP(SanPham sp)
        {
            var db = new ShopWishConnectionDB();
            db.Insert(sp);
        }
        public static void UpdateSP(String id, SanPham sp)
        {
            var db = new ShopWishConnectionDB();
            db.Update(id, sp);
        }
        public static void CapNhatLuotView(string masp)
        {
            var db = new ShopWishConnectionDB();
            var a = ChiTiet(masp);
            a.LuotView = a.LuotView + 1;
            db.Update(a, masp);
        }
        //----------------------------------update images---------------
        public static void UpdateImages(string id, string images)
        {
            var db = new ShopWishConnectionDB();
            var sp = ShopBUS.ChiTiet(id);
            sp.MoreImages = images;
            db.Update(sp, id);
        }
        public static string LoadAvartaImg(string id)
        {
            var sp = ChiTiet(id);
            var product = ShopBUS.ChiTiet(id);
            var images = product.MoreImages;
            return images;
        }

    }
}