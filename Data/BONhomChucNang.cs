﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class BONhomChucNang
    {
        public Data.NHOMCHUCNANG BanHang { get; set; }
        public Data.NHOMCHUCNANG NhanVien { get; set; }
        public Data.NHOMCHUCNANG MayIn { get; set; }
        public Data.NHOMCHUCNANG ThucDon { get; set; }
        public Data.NHOMCHUCNANG KhachHang { get; set; }
        public Data.NHOMCHUCNANG ThuChi { get; set; }
        public Data.NHOMCHUCNANG Gia { get; set; }
        public Data.NHOMCHUCNANG PhanQuyen { get; set; }
        public Data.NHOMCHUCNANG Kho { get; set; }
        public Data.NHOMCHUCNANG DingLuong { get; set; }
        public Data.NHOMCHUCNANG SoDoBan { get; set; }
        public Data.NHOMCHUCNANG BaoCao { get; set; }
        public Data.NHOMCHUCNANG The { get; set; }
        public Data.NHOMCHUCNANG CaiDat { get; set; }
        public Data.NHOMCHUCNANG ThongTinPhanMem { get; set; }

        public BONhomChucNang(Transit transit)
        {
            BanHang = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.BanHang, TenNhomChucNang = "Bán hàng", Deleted = false, Visual = true, Edit = false };
            BanHang.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.BanHang.TinhTien, TenChucNang = "Tính tiền", NhomChucNangID = BanHang.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = false, Xoa = false, Sua = false, Visual = true, Deleted = false, Edit = false });
            BanHang.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.BanHang.LuuHoaDon, TenChucNang = "Lưu hóa đơn", NhomChucNangID = BanHang.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = false, Xoa = false, Sua = false, Visual = true, Deleted = false, Edit = false });
            BanHang.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.BanHang.ThayDoiGia, TenChucNang = "Thay đổi giá", NhomChucNangID = BanHang.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = false, Xoa = false, Sua = false, Visual = true, Deleted = false, Edit = false });
            BanHang.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.BanHang.ChuyenBan, TenChucNang = "Chuyển bàn", NhomChucNangID = BanHang.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = false, Xoa = false, Sua = false, Visual = true, Deleted = false, Edit = false });
            BanHang.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.BanHang.TachBan, TenChucNang = "Tách bàn", NhomChucNangID = BanHang.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = false, Xoa = false, Sua = false, Visual = true, Deleted = false, Edit = false });
            BanHang.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.BanHang.XoaMon, TenChucNang = "Xóa món", NhomChucNangID = BanHang.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = false, Xoa = false, Sua = false, Visual = true, Deleted = false, Edit = false });
            BanHang.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.BanHang.XoaToanBoMon, TenChucNang = "Xóa toàn bộ món", NhomChucNangID = BanHang.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = false, Xoa = false, Sua = false, Visual = true, Deleted = false, Edit = false });
            BanHang.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.BanHang.DongBan, TenChucNang = "Đóng bàn", NhomChucNangID = BanHang.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = false, Xoa = false, Sua = false, Visual = true, Deleted = false, Edit = false });
            BanHang.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.BanHang.ThayDoiSoLuong, TenChucNang = "Thay đổi số lượng", NhomChucNangID = BanHang.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = false, Xoa = false, Sua = false, Visual = true, Deleted = false, Edit = false });

            NhanVien = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.NhanVien, TenNhomChucNang = "Quản lý nhân viến", Deleted = false, Visual = true, Edit = false };
            NhanVien.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.NhanVien.NhanVien, TenChucNang = "Quản lý nhân viên", NhomChucNangID = NhanVien.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });

            MayIn = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.MayIn, TenNhomChucNang = "Quản lý máy in", Deleted = false, Visual = true, Edit = false };
            MayIn.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.MayIn.CaiDatMayIn, TenChucNang = "Cài đặt máy in", NhomChucNangID = MayIn.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            MayIn.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.MayIn.CaiDatThucDonMayIn, TenChucNang = "Cài đặt thực đơn máy in", NhomChucNangID = MayIn.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });

            ThucDon = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.ThucDon, TenNhomChucNang = "Quản lý thực đơn", Deleted = false, Visual = true, Edit = false };
            ThucDon.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.ThucDon.ThucDon, TenChucNang = "Quản lý thực đơn", NhomChucNangID = ThucDon.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });

            KhachHang = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.KhachHang, TenNhomChucNang = "Quản lý khách hàng", Deleted = false, Visual = true, Edit = false };
            KhachHang.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.KhachHang.KhachHang, TenChucNang = "Khách hàng", NhomChucNangID = KhachHang.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            KhachHang.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.KhachHang.LoaiKhachHang, TenChucNang = "Loại khách hàng", NhomChucNangID = KhachHang.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });

            ThuChi = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.ThuChi, TenNhomChucNang = "Quản lý thu chi", Deleted = false, Visual = true, Edit = false };
            ThuChi.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.ThuChi.ThuChi, TenChucNang = "Quản lý thu chi", NhomChucNangID = ThuChi.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });

            Gia = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.Gia, TenNhomChucNang = "Quản lý giá", Deleted = false, Visual = true, Edit = false };
            Gia.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.Gia.LoaiGia, TenChucNang = "Loại giá", NhomChucNangID = Gia.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            Gia.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.Gia.LichBieuDinhKy, TenChucNang = "Lịch biểu định kỳ", NhomChucNangID = Gia.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            Gia.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.Gia.LichBieuKhongDinhKy, TenChucNang = "Lịch biểu không định kỳ", NhomChucNangID = Gia.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            Gia.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.Gia.DanhSachBan, TenChucNang = "Danh sách bán", NhomChucNangID = Gia.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            Gia.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.Gia.DanhSachGia, TenChucNang = "Danh sách giá", NhomChucNangID = Gia.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = false, Xoa = false, Sua = true, Visual = true, Deleted = false, Edit = false });
            Gia.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.Gia.KhuyenMai, TenChucNang = "Khuyễn mãi", NhomChucNangID = Gia.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });


            PhanQuyen = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.PhanQuyen, TenNhomChucNang = "Quản lý phần quyền", Deleted = false, Visual = true, Edit = false };
            PhanQuyen.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.PhanQuyen.Quyen, TenChucNang = "Quyền", NhomChucNangID = PhanQuyen.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            PhanQuyen.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.PhanQuyen.CaiDatQuyenCuaNhomQuyen, TenChucNang = "Cài đặt nhân viên thuộc nhóm quyền", NhomChucNangID = PhanQuyen.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            PhanQuyen.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.PhanQuyen.CaiDatQuyenNhanVienThuocNhomQuyen, TenChucNang = "Cài đặt quyền của nhóm quyền", NhomChucNangID = PhanQuyen.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });

            Kho = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.Kho, TenNhomChucNang = "Quản lý kho", Deleted = false, Visual = true, Edit = false };
            Kho.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.Kho.TonKho, TenChucNang = "Tồn kho", NhomChucNangID = Kho.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            Kho.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.Kho.NhaKho, TenChucNang = "Nhà kho", NhomChucNangID = Kho.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            Kho.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.Kho.NhapKho, TenChucNang = "Nhập kho", NhomChucNangID = Kho.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            Kho.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.Kho.HuKho, TenChucNang = "Hư kho", NhomChucNangID = Kho.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            Kho.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.Kho.MatKho, TenChucNang = "Mất kho", NhomChucNangID = Kho.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            Kho.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.Kho.ChuyenKho, TenChucNang = "Chuyển kho", NhomChucNangID = Kho.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            Kho.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.Kho.ChinhKho, TenChucNang = "Chỉnh kho", NhomChucNangID = Kho.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            Kho.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.Kho.NhaCungCap, TenChucNang = "Nhà cung cấp", NhomChucNangID = Kho.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });

            DingLuong = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.DingLuong, TenNhomChucNang = "Định lượng", Deleted = false, Visual = true, Edit = false };
            DingLuong.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.DinhLuong.DinhLuong, TenChucNang = "Định lượng", NhomChucNangID = DingLuong.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });

            SoDoBan = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.SoDoBan, TenNhomChucNang = "Quản lý sơ đồ bàn", Deleted = false, Visual = true, Edit = false };
            SoDoBan.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.SoDoBan.Khu, TenChucNang = "Quản lý khu", NhomChucNangID = SoDoBan.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });
            SoDoBan.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.SoDoBan.Ban, TenChucNang = "Quản lý bàn", NhomChucNangID = SoDoBan.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });

            BaoCao = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.BaoCao, TenNhomChucNang = "Báo cáo", Deleted = false, Visual = true, Edit = false };


            The = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.The, TenNhomChucNang = "Quản lý thẻ", Deleted = false, Visual = true, Edit = false };
            The.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.The.The, TenChucNang = "Quản lý thẻ", NhomChucNangID = The.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });

            CaiDat = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.CaiDat, TenNhomChucNang = "Cài đặt chương trình", Deleted = false, Visual = true, Edit = false };
            CaiDat.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.CaiDat.CaiDat, TenChucNang = "Cài đặt chương trình", NhomChucNangID = CaiDat.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = true, Xoa = true, Sua = true, Visual = true, Deleted = false, Edit = false });

            ThongTinPhanMem = new NHOMCHUCNANG() { NhomChucNangID = (int)TypeChucNang.ChucNangChinh.ThongTinPhanMem, TenNhomChucNang = "Thông tin phần mềm", Deleted = false, Visual = true, Edit = false };
            ThongTinPhanMem.CHUCNANGs.Add(new CHUCNANG() { ChucNangID = (int)TypeChucNang.ThongTinPhanMem.ThongTinPhanMem, TenChucNang = "Thông tin phần mềm", NhomChucNangID = ThongTinPhanMem.NhomChucNangID, ChoPhep = true, DangNhap = true, Them = false, Xoa = false, Sua = false, Visual = true, Deleted = false, Edit = false });

            FrameworkRepository<NHOMCHUCNANG> frmNhomChucNang = new FrameworkRepository<NHOMCHUCNANG>(transit.KaraokeEntities, transit.KaraokeEntities.NHOMCHUCNANGs);
            frmNhomChucNang.AddObject(BanHang);
            frmNhomChucNang.AddObject(NhanVien);
            frmNhomChucNang.AddObject(MayIn);
            frmNhomChucNang.AddObject(ThucDon);
            frmNhomChucNang.AddObject(KhachHang);
            frmNhomChucNang.AddObject(ThuChi);
            frmNhomChucNang.AddObject(Gia);
            //frmNhomChucNang.AddObject(PhanQuyen);
            frmNhomChucNang.AddObject(Kho);
            frmNhomChucNang.AddObject(DingLuong);
            frmNhomChucNang.AddObject(SoDoBan);
            frmNhomChucNang.AddObject(BaoCao);
            frmNhomChucNang.AddObject(The);
            frmNhomChucNang.AddObject(CaiDat);
            frmNhomChucNang.AddObject(ThongTinPhanMem);
            frmNhomChucNang.Commit();
        }
    }
}