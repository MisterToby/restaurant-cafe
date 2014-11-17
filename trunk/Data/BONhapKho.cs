﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class BONhapKho
    {
        public Data.NHAPKHO NhapKho { get; set; }
        public Data.KHO Kho { get; set; }
        public Data.NHANVIEN NhanVien { get; set; }
        public Data.NHACUNGCAP NhaCungCap { get; set; }
        FrameworkRepository<NHAPKHO> frmNhapKho = null;
        FrameworkRepository<KHO> frmKho = null;
        FrameworkRepository<NHACUNGCAP> frmNhaCungCap = null;
        FrameworkRepository<NHANVIEN> frmNhanVien = null;
        public BONhapKho(Data.Transit transit)
        {
            transit.KaraokeEntities = new KaraokeEntities();
            frmNhapKho = new FrameworkRepository<NHAPKHO>(transit.KaraokeEntities, transit.KaraokeEntities.NHAPKHOes);
            frmKho = new FrameworkRepository<KHO>(transit.KaraokeEntities, transit.KaraokeEntities.KHOes);
            frmNhanVien = new FrameworkRepository<NHANVIEN>(transit.KaraokeEntities, transit.KaraokeEntities.NHANVIENs);
            frmNhaCungCap = new FrameworkRepository<NHACUNGCAP>(transit.KaraokeEntities, transit.KaraokeEntities.NHACUNGCAPs);

        }
        public BONhapKho()
        {
            NhapKho = new NHAPKHO();
            Kho = new KHO();
        }
        public IQueryable<BONhapKho> GetAll(Transit mTransit, DateTime dt)
        {
            return (from nk in frmNhapKho.Query()
                    join k in frmKho.Query() on nk.KhoID equals k.KhoID
                    join nv in frmNhanVien.Query() on nk.NhanVienID equals nv.NhanVienID
                    join ncc in frmNhaCungCap.Query() on nk.NhaCungCapID equals ncc.NhaCungCapID
                    //where ((DateTime)nk.ThoiGian).Date == dt.Date && nk.Deleted == false
                    select new BONhapKho
                    {
                        NhapKho = nk,
                        Kho = k,
                        NhanVien = nv,
                        NhaCungCap = ncc
                    }
                        );

        }

        public int Them(BONhapKho item, List<BOChiTietNhapKho> lsArray, Transit mTransit)
        {
            ThemMoi(item, lsArray, mTransit);
            frmNhapKho.AddObject(item.NhapKho);
            frmNhapKho.Commit();
            return item.NhapKho.NhapKhoID;
        }

        private int ThemMoi(BONhapKho item, List<BOChiTietNhapKho> lsArray, Transit mTransit)
        {
            if (lsArray != null)
            {
                foreach (BOChiTietNhapKho line in lsArray)
                {
                    line.ChiTietNhapKho.TONKHO = new TONKHO();
                    line.ChiTietNhapKho.TONKHO.KhoID = item.NhapKho.KhoID;
                    line.ChiTietNhapKho.TONKHO.PhatSinhTuTonKhoID = item.NhapKho.KhoID;
                    line.ChiTietNhapKho.TONKHO.NgayHetHan = line.ChiTietNhapKho.NgayHetHan;
                    line.ChiTietNhapKho.TONKHO.NgaySanXuat = line.ChiTietNhapKho.NgaySanXuat;
                    line.ChiTietNhapKho.TONKHO.LoaiPhatSinhID = (int)Data.TypeLoaiPhatSinh.NhapKho;
                    line.ChiTietNhapKho.TONKHO.MonID = line.ChiTietNhapKho.MonID;
                    line.ChiTietNhapKho.TONKHO.LoaiBanID = line.ChiTietNhapKho.LoaiBanID;
                    line.ChiTietNhapKho.TONKHO.KichThuocBan = line.ChiTietNhapKho.KichThuocBan;
                    line.ChiTietNhapKho.TONKHO.SoLuongNhap = line.ChiTietNhapKho.SoLuong;
                    line.ChiTietNhapKho.TONKHO.SoLuongTon = line.ChiTietNhapKho.TONKHO.SoLuongNhap;
                    line.ChiTietNhapKho.TONKHO.Visual = true;
                    line.ChiTietNhapKho.TONKHO.Deleted = false;
                    line.ChiTietNhapKho.TONKHO.Edit = false;
                    line.ChiTietNhapKho.TONKHO.SoLuongPhatSinh = 0;
                    line.ChiTietNhapKho.TONKHO.GiaNhap = line.ChiTietNhapKho.GiaMua;
                    item.NhapKho.CHITIETNHAPKHOes.Add(line.ChiTietNhapKho);
                    line.NhapKho = item.NhapKho;
                }
                item.NhapKho.TongTien = lsArray.Sum(s => s.ChiTietNhapKho.SoLuong * s.ChiTietNhapKho.GiaMua);
            }
            return item.NhapKho.NhapKhoID;
        }
        private int Them(BONhapKho item, Transit mTransit)
        {
            frmNhapKho.AddObject(item.NhapKho);
            return item.NhapKho.NhapKhoID;
        }

        private int Xoa(BONhapKho item, Transit mTransit)
        {
            item.NhapKho.Deleted = true;
            frmNhapKho.Update(item.NhapKho);
            return item.NhapKho.NhapKhoID;
        }

        private int Sua(BONhapKho item, Transit mTransit)
        {
            item.NhapKho.Edit = false;
            frmNhapKho.Update(item.NhapKho);
            return item.NhapKho.NhapKhoID;
        }

        public void Luu(List<BONhapKho> lsArray, List<BONhapKho> lsArrayDeleted, Transit mTransit)
        {
            if (lsArray != null)
                foreach (BONhapKho item in lsArray)
                {
                    if (item.NhapKho.NhapKhoID > 0)
                        Sua(item, mTransit);
                    else
                        ThemMoi(item, null, mTransit);
                }
            if (lsArrayDeleted != null)
                foreach (BONhapKho item in lsArrayDeleted)
                {
                    Xoa(item, mTransit);
                }
            mTransit.KaraokeEntities.SaveChanges();
        }
    }
}