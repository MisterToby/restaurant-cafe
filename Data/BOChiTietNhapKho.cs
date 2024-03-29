﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class BOChiTietNhapKho
    {
        public CHITIETNHAPKHO ChiTietNhapKho { get; set; }
        public MENUMON MenuMon { get; set; }
        public LOAIBAN LoaiBan { get; set; }
        public NHAPKHO NhapKho { get; set; }
        public BOMenuKichThuocMon MenuKichThuocMon { get; set; }
        public List<LOAIBAN> ListLoaiBan { get; set; }
        public string TenChiTiet 
        {
            get 
            {                                
                if (MenuKichThuocMon!=null)
                {                    
                    return MenuKichThuocMon.TenMon;
                }
                return "";
            }
        }

        public BOChiTietNhapKho(Transit transit)
        {            
        }

        public BOChiTietNhapKho()
        {
            ChiTietNhapKho = new CHITIETNHAPKHO();
            ChiTietNhapKho.NgaySanXuat = ChiTietNhapKho.NgayHetHan = DateTime.Now;
            ChiTietNhapKho.SoLuongNhap = 1;
            MenuMon = new MENUMON();
            LoaiBan = new LOAIBAN();            
            NhapKho = new NHAPKHO();
        }

        public IQueryable<BOChiTietNhapKho> GetAll(int NhapKhoID, Transit mTransit)
        {
            //return from ctnk in frmChiTietNhapKho.Query()
            //       join tk in frmTonKho.Query() on ctnk.TonKhoID equals tk.TonKhoID
            //       join lb in frmLoaiBan.Query() on tk.LoaiBanID equals lb.LoaiBanID
            //       join mm in frmMenuMon.Query() on tk.MonID equals mm.MonID
            //       join nk in frmNhapKho.Query() on ctnk.NhapKhoID equals nk.NhapKhoID
            //       select new BOChiTietNhapKho
            //       {
            //           ChiTietNhapKho = ctnk,
            //           NhapKho = nk,
            //           LoaiBan = lb,
            //           TonKho = tk,
            //           MenuMon = mm
            //       };
            return null;
        }

    }
}
