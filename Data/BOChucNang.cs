﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class BOChucNang
    {

        FrameworkRepository<CHUCNANG> frmChucNang = null;
        public BOChucNang(Data.Transit transit)
        {
            frmChucNang = new FrameworkRepository<CHUCNANG>(transit.KaraokeEntities, transit.KaraokeEntities.CHUCNANGs);
        }

        public IQueryable<CHUCNANG> GetAll(Transit transit)
        {
            return frmChucNang.Query().Where(s => s.Deleted == false);
        }

        public void LuuChucNangHienThi(List<CHUCNANG> lsArray)
        {
            foreach (var item in lsArray)
            {
                frmChucNang.Update(item);
            }
            frmChucNang.Commit();
        }

        public static IQueryable<CHUCNANG> GetAllNoTracking(Transit mTransit)
        {
            return FrameworkRepository<CHUCNANG>.QueryNoTracking(mTransit.KaraokeEntities.CHUCNANGs).Where(s => s.Deleted == false);
        }
    }

    public class TypeChucNang
    {
        public enum ChucNangChinh
        {
            None = 0,
            BanHang = 1,
            NhanVien = 2,
            MayIn = 3,
            ThucDon = 4,
            KhachHang = 5,
            ThuChi = 6,
            Gia = 7,
            PhanQuyen = 8,
            Kho = 9,
            DingLuong = 10,
            SoDoBan = 11,
            BaoCao = 12,
            The = 13,
            CaiDat = 14,
            ThongTinPhanMem = 15
        }

        public enum BanHang
        {
            TinhTien = 101,
            LuuHoaDon = 102,
            TamTinh = 103,
            ThayDoiGia = 104,
            XoaMon = 105,
            XoaToanBoMon = 106,
            ChuyenBan = 107,
            TachBan = 108,
            DongBan = 109,
            ThayDoiSoLuong = 110,
            ChonGia = 111,
            GopBan = 112,
            GiamGiaMon=113
        }

        public enum NhanVien
        {
            NhanVien = 201
        }

        public enum MayIn
        {
            CaiDatMayIn = 301,
            CaiDatThucDonMayIn = 302
        }

        public enum ThucDon
        {
            ThucDon = 401
        }

        public enum KhachHang
        {
            KhachHang = 501,
            LoaiKhachHang = 502
        }

        public enum ThuChi
        {
            ThuChi = 601
        }

        public enum Gia
        {
            LoaiGia = 701,
            LichBieuDinhKy = 702,
            LichBieuKhongDinhKy = 703,
            DanhSachBan = 704,
            DanhSachGia = 705,
            KhuyenMai = 706
        }

        public enum PhanQuyen
        {
            Quyen = 801,
            CaiDatQuyenNhanVienThuocNhomQuyen = 802,
            CaiDatQuyenCuaNhomQuyen = 803
        }

        public enum Kho
        {
            TonKho = 901,
            NhaKho = 902,
            NhapKho = 903,
            ChuyenKho = 904,
            XuLyKho = 905,
            NhaCungCap = 906
        }

        public enum DinhLuong
        {
            DinhLuong = 1001
        }

        public enum SoDoBan
        {
            Khu = 1101,
            Ban = 1102
        }

        public enum Baocao
        {

        }

        public enum The
        {
            The = 1301
        }

        public enum CaiDat
        {
            None,
            CaiDatThongTinCongTy = 1401,
            CaiDatGiaoDienBanHang,
            btnCaiDatChucNangHienThi,
            CaiDatBan,
            CaiDatMayInNhaBep,
            CaiDatMayInHoaDon,
            CaiDatThucDon
        }

        public enum ThongTinPhanMem
        {
            ThongTinPhanMem = 1501
        }
    }
}
