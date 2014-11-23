﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class BOMenuKichThuocMon
    {
        public Data.MENUKICHTHUOCMON MenuKichThuocMon { get; set; }
        public Data.MENUMON MenuMon { get; set; }
        public Data.LOAIBAN LoaiBan { get; set; }
        public List<BOMenuKhuyenMai> DanhSachKhuyenMai { get; set; }

        public int KichThuocLoaiBan
        {
            get
            {
                if (MenuKichThuocMon != null && LoaiBan != null)
                    return (int)(MenuKichThuocMon.KichThuocLoaiBan / LoaiBan.KichThuocBan);
                return 0;
            }
        }

        public string TenMon
        {
            get
            {
                if (MenuMon != null && MenuKichThuocMon != null)
                    return MenuMon.TenDai + " (" + MenuKichThuocMon.TenLoaiBan + ")";
                else
                    return "";
            }


        }

        public int SoLuongMonKhuyenMai
        {
            get
            {

                if (DanhSachKhuyenMai != null)
                {
                    return DanhSachKhuyenMai.Count();
                }

                return 0;

            }
        }

        public string DanhSachTenMonKhuyenMai
        {
            get
            {
                string result = "";
                if (DanhSachKhuyenMai != null)
                {
                    foreach (BOMenuKhuyenMai item in DanhSachKhuyenMai)
                    {
                        result += item.KichThuocMonTang.TenMon + ", ";
                    }
                    if (DanhSachKhuyenMai.Count > 0)
                    {
                        result = result.Trim().Remove(result.Length - 2);
                    }
                }
                return result;
            }
        }

        FrameworkRepository<MENUKICHTHUOCMON> frmKichThuocMon = null;
        FrameworkRepository<MENUMON> frmmenuMon = null;
        FrameworkRepository<LOAIBAN> frmLoaiBan = null;

        public BOMenuKichThuocMon()
        {
            MenuKichThuocMon = new MENUKICHTHUOCMON();
            MenuMon = new MENUMON();
            LoaiBan = new LOAIBAN();
            DanhSachKhuyenMai = new List<BOMenuKhuyenMai>();
        }

        public BOMenuKichThuocMon(Data.Transit transit)
        {
            frmKichThuocMon = new FrameworkRepository<MENUKICHTHUOCMON>(transit.KaraokeEntities, transit.KaraokeEntities.MENUKICHTHUOCMONs);
            frmmenuMon = new FrameworkRepository<MENUMON>(transit.KaraokeEntities, transit.KaraokeEntities.MENUMONs);
            frmLoaiBan = new FrameworkRepository<LOAIBAN>(transit.KaraokeEntities, transit.KaraokeEntities.LOAIBANs);
        }

        public BOMenuKichThuocMon(Data.MENUKICHTHUOCMON menuKichThuocMon, Data.MENUMON menuMon)
        {
            MenuKichThuocMon = menuKichThuocMon;
            MenuMon = menuMon;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MonID"></param>
        /// <param name="IsDinhLuong">Có cho load định lượng lên không</param>
        /// <param name="IsThoiGian">Có cho load thời gian lên không</param>
        /// <param name="mTransit"></param>
        /// <returns></returns>
        public IQueryable<BOMenuKichThuocMon> GetAll(int MonID, bool IsSoLuong, bool IsTrongLuong, bool IsTheTich, bool IsDinhLuong, bool IsThoiGian, Transit mTransit)
        {
            var res = (from k in frmKichThuocMon.Query()
                       join m in frmmenuMon.Query() on k.MonID equals m.MonID
                       join l in frmLoaiBan.Query() on k.LoaiBanID equals l.LoaiBanID
                       where k.MonID == MonID && k.Deleted == false
                       select new BOMenuKichThuocMon
                       {
                           MenuKichThuocMon = k,
                           MenuMon = m,
                           LoaiBan = l
                       });
            if (!IsSoLuong)
                res = res.Where(s => s.MenuKichThuocMon.DonVi != (int)EnumDonVi.SoLuong);
            if (!IsTrongLuong)
                res = res.Where(s => s.MenuKichThuocMon.DonVi != (int)EnumDonVi.TrongLuong);
            if (!IsTheTich)
                res = res.Where(s => s.MenuKichThuocMon.DonVi != (int)EnumDonVi.TheTich);
            if (!IsThoiGian)
                res = res.Where(s => s.MenuKichThuocMon.DonVi != (int)EnumDonVi.ThoiGian);
            if (!IsDinhLuong)
                res = res.Where(s => s.MenuKichThuocMon.DonVi != (int)EnumDonVi.DinhLuong);
            return res;
        }

        private int Them(BOMenuKichThuocMon item, Transit mTransit)
        {
            frmKichThuocMon.AddObject(item.MenuKichThuocMon);
            return item.MenuKichThuocMon.KichThuocMonID;
        }

        private int Sua(BOMenuKichThuocMon item, Transit mTransit)
        {
            frmKichThuocMon.Update(item.MenuKichThuocMon);
            return item.MenuKichThuocMon.KichThuocMonID;
        }

        private int Xoa(BOMenuKichThuocMon item, Transit mTransit)
        {
            frmKichThuocMon.DeleteObject(item.MenuKichThuocMon);
            return item.MenuKichThuocMon.KichThuocMonID;
        }

        public void Luu(List<BOMenuKichThuocMon> lsArray, List<BOMenuKichThuocMon> lsArrayDeleted, Transit mTransit)
        {
            if (lsArray != null)
                foreach (BOMenuKichThuocMon item in lsArray)
                {
                    if (item.MenuKichThuocMon.KichThuocMonID > 0)
                        Sua(item, mTransit);
                    else
                        Them(item, mTransit);
                }
            if (lsArrayDeleted != null)
                foreach (BOMenuKichThuocMon item in lsArrayDeleted)
                {
                    Xoa(item, mTransit);
                }
            frmKichThuocMon.Commit();
            if (lsArray != null && lsArray.Count > 0)
            {
                UpdateSoLuongKichThuocMon((int)lsArray[0].MenuKichThuocMon.MonID, mTransit);
                SapXep((int)lsArray[0].MenuKichThuocMon.MonID, mTransit);
            }
            else if (lsArrayDeleted != null && lsArrayDeleted.Count > 0)
            {
                UpdateSoLuongKichThuocMon((int)lsArrayDeleted[0].MenuKichThuocMon.MonID, mTransit);
                SapXep((int)lsArrayDeleted[0].MenuKichThuocMon.MonID, mTransit);
            }

        }

        public void UpdateSoLuongKichThuocMon(int MonID, Data.Transit mTransit)
        {
            var Parameter_MonID = new System.Data.SqlClient.SqlParameter("@MonID", System.Data.SqlDbType.Int);
            Parameter_MonID.Value = MonID;
            mTransit.KaraokeEntities.ExecuteStoreCommand("SP_UPDATE_SOLUONGKICHTHUOCMON @MonID", Parameter_MonID);
        }

        public void SapXep(int MonID, Data.Transit mTransit)
        {
            var Parameter_MonID = new System.Data.SqlClient.SqlParameter("@MonID", System.Data.SqlDbType.Int);
            Parameter_MonID.Value = MonID;
            mTransit.KaraokeEntities.ExecuteStoreCommand("SP_SAPXEP_KICHTHUOCMON @MonID", Parameter_MonID);
        }

    }
}