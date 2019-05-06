using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopWishConnection;

namespace Shop.Models.BUS
{
    public class GioHangBUS
    {
        public static void Them(string masanpham, string mataikhoan, int soluong, int price, string tensanpham)
        {

            using (var db = new ShopWishConnectionDB())
            {
                var x = db.Query<GioHang>("select * from GioHang Where MaTaiKhoan = '" + mataikhoan + "' and MaSanPham = '" + masanpham + "'").ToList(); //dựa vào mã tài khoản để biết dc tài khoản nào đang đặt trong giỏ hàng thanh toán còn mã sản phẩm dc phân theo nhóm để biết ngta đặt sp nào
                if (x.Count() > 0)
                {
                    // gọi hàm update so lượng
                    int a = (int)x.ElementAt(0).SoLuong + soluong;
                    CapNhat(masanpham, mataikhoan, a, price, tensanpham);
                }
                else
                {
                    GioHang giohang = new GioHang()
                    {
                        MaSanPham = masanpham,
                        MaTaiKhoan = mataikhoan,
                        SoLuong = soluong,
                        Price = price,
                        TenSanPham = tensanpham,
                        TongTien = price * soluong
                    };
                    db.Insert(giohang);
                }

            }
        }

        public static IEnumerable<GioHang> DanhSach(string mataikhoan)
        {
            using (var db = new ShopWishConnectionDB())
            {
                return db.Query<GioHang>("select G.IdGH,G.MaTaiKhoan,G.MaSanPham,G.TenSanPham,G.SoLuong,G.Price,G.TongTien,S.MoreImages from GioHang G INNER JOIN SanPham S ON G.MaSanPham = S.MaSanPham  where MaTaiKhoan = '" + mataikhoan + "'");
            }
        }
        public static void CapNhat(string masanpham, string mataikhoan, int soluong, int price, string tensanpham)
        {
            using (var db = new ShopWishConnectionDB())
            {
                GioHang giohang = new GioHang()
                {
                    MaSanPham = masanpham,
                    MaTaiKhoan = mataikhoan,
                    SoLuong = soluong,
                   Price = price,
                    TenSanPham = tensanpham,
                    TongTien = price * soluong
                };
                var tamp = db.Query<GioHang>("Select IdGH from GioHang Where MaTaiKhoan = '" + mataikhoan + "' and MaSanPham = '" + masanpham + "'").FirstOrDefault();
                db.Update(giohang, tamp.IdGH);
            }
        }
        public static void Xoa(string masanpham, string mataikhoan)
        {
            using (var db = new ShopWishConnectionDB())
            {
                var a = db.Query<GioHang>("select * from GioHang where MaSanPham = '" + masanpham + "' and MaTaiKhoan ='" + mataikhoan + "'").FirstOrDefault();
                db.Delete(a);
            }
        }
        public static int TongTien(string mataikhoan)
        {
            using (var db = new ShopWishConnectionDB())
            {
                List<GioHang> a = DanhSach(mataikhoan).ToList();
                if (a.Count() == 0)
                {
                    return 0;
                }
                return db.Query<int>("select sum(TongTien) from GioHang where MaTaiKhoan = '" + mataikhoan + "' ").FirstOrDefault();

            }
        }
    }
}