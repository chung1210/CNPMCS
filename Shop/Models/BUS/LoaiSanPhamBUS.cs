﻿using ShopDegreyConnection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models.BUS
{
    public class LoaiSanPhamBUS
    {
        //KHACH HANG
        public static IEnumerable<LoaiSanPham> DanhSach()
        {
            var db = new ShopDegreyConnectionDB();
            return db.Query<LoaiSanPham>("select * from LoaiSanPham where TinhTrang = '0             '");
        }
        public static IEnumerable<SanPham> ChiTiet(String id)
        {
            var db = new ShopDegreyConnectionDB();
            return db.Query<SanPham>("select * from SanPham where MaLoaiSanPham = '" + id + "'");
        }
        //ADMIN
        public static IEnumerable<LoaiSanPham> DanhSachAdmin()
        {
            var db = new ShopDegreyConnectionDB();
            return db.Query<LoaiSanPham>("select * from LoaiSanPham ");
        }
        public static void InsertLSP(LoaiSanPham lsp)
        {
            var db = new ShopDegreyConnectionDB();
            db.Insert(lsp);
        }
        public static LoaiSanPham ChiTietAdmin(String id)
        {
            var db = new ShopDegreyConnectionDB();
            return db.SingleOrDefault<LoaiSanPham>("select * from LoaiSanPham where MaLoaiSanPham = '" + id + "'");
        }
        public static void EditLSP(String id, LoaiSanPham lsp)
        {
            var db = new ShopDegreyConnectionDB();
            db.Update(lsp, id);
        }
        public static void DeleteLSP(String id, LoaiSanPham lsp)
        {
            var db = new ShopDegreyConnectionDB();
            db.Delete("LoaiSanPham", "MaLoaiSanPham", lsp, id);
        }

        
    }
}