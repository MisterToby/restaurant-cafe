﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class BOBanHang
    {
        private BAN mBan;
        public BANHANG BANHANG { get; set; }
        public List<BOChiTietBanHang> _ListChiTietBanHang { get; set; }        
        private Transit mTransit;

        public FrameworkRepository<BANHANG> frBanHang;
        public FrameworkRepository<CHITIETBANHANG> frChiTietBanHang;
        public FrameworkRepository<MENUKICHTHUOCMON> frMenuKichThuocMon;
        public FrameworkRepository<MENUMON> frMenuMon;
        public FrameworkRepository<LICHSUBANHANG> frLichSu;
        public FrameworkRepository<CHITIETLICHSUBANHANG> frChiTietLichSuBanHang;
        public string TenBan 
        {
            get { return mBan.TenBan; }
        }
        public string MaHoaDon 
        {
            get { return BANHANG.MaHoaDon; }
        }
        public BOBanHang(Transit tran)
        {                        
            mTransit = tran;
            
            frBanHang = new FrameworkRepository<Data.BANHANG>(mTransit.KaraokeEntities,mTransit.KaraokeEntities.BANHANGs);
            frChiTietBanHang = new FrameworkRepository<CHITIETBANHANG>(mTransit.KaraokeEntities,mTransit.KaraokeEntities.CHITIETBANHANGs);
            frMenuKichThuocMon = new FrameworkRepository<MENUKICHTHUOCMON>(mTransit.KaraokeEntities,mTransit.KaraokeEntities.MENUKICHTHUOCMONs);
            frMenuMon = new FrameworkRepository<MENUMON>(mTransit.KaraokeEntities,mTransit.KaraokeEntities.MENUMONs);
            frLichSu = new FrameworkRepository<LICHSUBANHANG>(mTransit.KaraokeEntities,mTransit.KaraokeEntities.LICHSUBANHANGs);
            frChiTietLichSuBanHang = new FrameworkRepository<CHITIETLICHSUBANHANG>(mTransit.KaraokeEntities,mTransit.KaraokeEntities.CHITIETLICHSUBANHANGs);
            
            _ListChiTietBanHang = new List<BOChiTietBanHang>();            
            //LoadBanHang();
        }
        public static IQueryable<BANHANG> GetAllNotCompleted(Transit transit)
        {
            return FrameworkRepository<BANHANG>.QueryNoTracking(transit.KaraokeEntities.BANHANGs).Where(b=>b.TrangThaiID<3);
        }
        public void LoadBanHang(BAN ban)
        {
            mBan = ban;
            var list = frBanHang.Query().Where(o => o.BanID == ban.BanID && o.TrangThaiID < 3).ToList();
            if (list.Count() > 0)
            {
                BANHANG = list.FirstOrDefault();
                var listItem = BOChiTietBanHang.Query(BANHANG.BanHangID, this);
                foreach (BOChiTietBanHang item in listItem)
                {
                    item.SoLuongBanTam = (int)item.CHITIETBANHANG.SoLuongBan;
                    this.AddChiTietBanHang(item);
                }
            }
            else
            {
                BANHANG = new BANHANG();
                BANHANG.NhanVienID = mTransit.NhanVien.NhanVienID;
                if (BANHANG.NhanVienID == 0)
                {
                    BANHANG.NhanVienID = null;
                }
                BANHANG.BanID = ban.BanID;
                BANHANG.NgayBan = DateTime.Now;
                BANHANG.MaHoaDon = String.Format("HD{0:000000}", 1);
                BANHANG.TienMat = 0;
                //BANHANG.TheID = mTransit.The.TheID;
                BANHANG.TienThe = 0;
                BANHANG.TienTraLai = 0;
                BANHANG.TienGiam = 0;
                BANHANG.ChietKhau = 0;
                BANHANG.TienBo = 0;
                BANHANG.PhiDichVu = 0;
                BANHANG.TongTien = 0;
                BANHANG.TrangThaiID = 1;
                if (mTransit.KhachHang!=null)
                {
                    BANHANG.KhachHangID = mTransit.KhachHang.KhachHangID;
                }
                BANHANG.TienKhacHang = 0;
            }

        }
        public void LoadBanHang()
        {
            LoadBanHang(mTransit.Ban);
        }
        private bool KiemTraThayDoi()
        {            
            foreach (BOChiTietBanHang item in _ListChiTietBanHang)
            {
                if (item.IsDeleted|| item.SoLuongBanTam!=item.CHITIETBANHANG.SoLuongBan || item.CHITIETBANHANG.ChiTietBanHangID==0)
                {
                    return true;
                }
            }
            return false;
        }        
        public int AddChiTietBanHang(BOChiTietBanHang chiTiet)
        {
            if (_ListChiTietBanHang.Count>0)
            {
                BOChiTietBanHang chitietLast=_ListChiTietBanHang.Last();
                if (chitietLast.CHITIETBANHANG.KichThuocMonID==chiTiet.CHITIETBANHANG.KichThuocMonID)
                {
                    chitietLast.ChangeQtyChiTietBanHang((int)(chitietLast.CHITIETBANHANG.SoLuongBan+chiTiet.CHITIETBANHANG.SoLuongBan));
                    return (int)chitietLast.CHITIETBANHANG.KichThuocMonID;
                }
            }
            chiTiet.CHITIETBANHANG.NhanVienID = this.BANHANG.NhanVienID;
            _ListChiTietBanHang.Add(chiTiet);
            return 0;
        }
        public int DongBan()
        {            
            if (this.BANHANG.TrangThaiID==3)
            {
                this.BANHANG.TrangThaiID = 4;
                frBanHang.Update(this.BANHANG);
                frBanHang.Commit();
                return this.BANHANG.BanHangID;
            }
            return 0;
        }
        public int GuiNhaBep()
        {
            int lichSuBanHangId = 0;
            if (this.BANHANG.BanHangID==0)
            {                
                frBanHang.AddObject(this.BANHANG);
                frBanHang.Commit();
                LICHSUBANHANG lichsu = GetLichSuBanHang();
                frLichSu.AddObject(lichsu);
                frLichSu.Commit();
                lichSuBanHangId = lichsu.LichSuBanHangID;

                foreach (BOChiTietBanHang item in _ListChiTietBanHang)
                {
                    item.CHITIETBANHANG.BanHangID = BANHANG.BanHangID;
                    CHITIETLICHSUBANHANG chitiet = GetChiTietLichSuBanHang(item, lichsu);
                    frChiTietBanHang.AddObject(item.CHITIETBANHANG);
                    frChiTietLichSuBanHang.AddObject(chitiet);
                }
                frChiTietBanHang.Commit();
                frChiTietLichSuBanHang.Commit();
            }
            else
            {
                frBanHang.Update(this.BANHANG);
                frBanHang.Commit();
                if (KiemTraThayDoi())
                {                    
                    LICHSUBANHANG lichsu = GetLichSuBanHang();
                    frLichSu.AddObject(lichsu);
                    frLichSu.Commit();
                    lichSuBanHangId = lichsu.LichSuBanHangID;
                    foreach (BOChiTietBanHang item in _ListChiTietBanHang)
                    {                        
                        if (item.CHITIETBANHANG.ChiTietBanHangID==0)
                        {
                            CHITIETLICHSUBANHANG chitiet = GetChiTietLichSuBanHang(item, lichsu);
                            item.ChangeQtyChiTietLichSuBanHang(chitiet, (int)chitiet.SoLuong);
                            item.CHITIETBANHANG.BanHangID = this.BANHANG.BanHangID;
                            frChiTietBanHang.AddObject(item.CHITIETBANHANG);
                            frChiTietLichSuBanHang.AddObject(chitiet);
                        }
                        else if (item.IsDeleted)
                        {
                            CHITIETLICHSUBANHANG chitiet = GetChiTietLichSuBanHang(item, lichsu);
                            item.ChangeQtyChiTietLichSuBanHang(chitiet, 0 - (int)chitiet.SoLuong);                            
                            frChiTietLichSuBanHang.AddObject(chitiet);
                            frChiTietBanHang.DeleteObject(item.CHITIETBANHANG);
                        }
                        else if(item.SoLuongBanTam!=item.CHITIETBANHANG.SoLuongBan)
                        {
                            CHITIETLICHSUBANHANG chitiet = GetChiTietLichSuBanHang(item, lichsu);
                            chitiet.SoLuong = item.CHITIETBANHANG.SoLuongBan - item.SoLuongBanTam;
                            chitiet.ThanhTien = chitiet.SoLuong * chitiet.GiaBan;
                            frChiTietLichSuBanHang.AddObject(chitiet);
                            frChiTietBanHang.Update(item.CHITIETBANHANG);
                        }                        
                    }                    
                    frChiTietBanHang.Commit();
                    frChiTietLichSuBanHang.Commit();
                }
            }
            return lichSuBanHangId;
        }
        public int TinhTien()
        {
            if (this.BANHANG.TrangThaiID==1 || this.BANHANG.TrangThaiID==2)
            {
                this.BANHANG.TrangThaiID = 4;
                frBanHang.Update(this.BANHANG);
                frBanHang.Commit();
                return this.BANHANG.BanHangID;
            }
            return 0;
        }
        public int TamTinh()
        {
            if (this.BANHANG.TrangThaiID == 1 || this.BANHANG.TrangThaiID == 2)
            {
                this.BANHANG.TrangThaiID = 2;
                frBanHang.Update(this.BANHANG);
                frBanHang.Commit();
                return this.BANHANG.BanHangID;
            }
            return 0;
        }
        public void ChuyenBan(BAN ban)
        {            
            Nullable<int> trangThai = this.BANHANG.TrangThaiID;
            //chuyen ban
            this.BANHANG.TrangThaiID = 5;
            frBanHang.Update(this.BANHANG);
            frBanHang.Commit();

            //ban moi
            this.BANHANG.TrangThaiID = trangThai;
            this.BANHANG.BanID = ban.BanID;
            this.BANHANG.BanHangID = 0;            
            foreach (var item in _ListChiTietBanHang)
            {
                item.CHITIETBANHANG.ChiTietBanHangID = 0;                
            }
            GuiNhaBep();

        }
        public void GopBan(BOTachGopBan gopban)
        {
            if (this.BANHANG.BanHangID>0)
            {
                Nullable<int> trangthaiID=this.BANHANG.TrangThaiID;
                this.BANHANG.TrangThaiID = 6;
                frBanHang.Update(this.BANHANG);
                frBanHang.Commit();
                this.BANHANG.TrangThaiID = trangthaiID;
            }
            this.BANHANG.BanHangID = 0;
            foreach (var banhang in gopban._ListBan)
            {
                banhang.BANHANG.TrangThaiID = 6;
                frBanHang.Update(banhang.BANHANG);
                foreach (var item in banhang._ListChiTietBanHang)
                {
                    item.CHITIETBANHANG.ChiTietBanHangID = 0;
                    this.AddChiTietBanHang(item);
                }
            }
            GuiNhaBep();
        }
        public decimal TongTien()
        {
            decimal tong = 0;
            foreach (var item in _ListChiTietBanHang)
            {
                if (item.IsDeleted==false)
                {
                    tong += (decimal)item.CHITIETBANHANG.ThanhTien;
                }
            }
            return tong;
        }
        private LICHSUBANHANG GetLichSuBanHang()
        {
            LICHSUBANHANG lichsu = new LICHSUBANHANG();
            lichsu.BanHangID = this.BANHANG.BanHangID;
            lichsu.NhanVienID = mTransit.NhanVien.NhanVienID;
            if (lichsu.NhanVienID==0)
            {
                lichsu.NhanVienID = null;
            }
            lichsu.NgayBan = DateTime.Now;
            lichsu.InNhaBep = false;
            return lichsu;
        }
        private CHITIETLICHSUBANHANG GetChiTietLichSuBanHang(BOChiTietBanHang item,LICHSUBANHANG lichsu)
        {            
            CHITIETLICHSUBANHANG chitiet = new CHITIETLICHSUBANHANG();
            chitiet.LichSuBanHangID = lichsu.LichSuBanHangID;
            chitiet.KichThuocMonID = item.CHITIETBANHANG.KichThuocMonID;
            chitiet.TonKhoID = item.CHITIETBANHANG.TonKhoID;
            chitiet.SoLuong = item.CHITIETBANHANG.SoLuongBan;
            chitiet.ThanhTien = item.CHITIETBANHANG.ThanhTien;
            chitiet.GiaBan = item.CHITIETBANHANG.GiaBan;
            chitiet.TrangThai = 0;
            return chitiet;
        }        
        
    }
}