﻿using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using ControlLibrary;
using System;

namespace GUI
{
    /// <summary>
    /// Interaction logic for WindowBanHang.xaml
    /// </summary>
    public partial class WindowBanHang : Window
    {
        private ControlLibrary.POSButtonTable mPOSButtonTable;
        private bool IsThayDoiSoLuong = true;
        private Data.Transit mTransit = null;
        private ProcessOrder.ProcessOrder mProcessOrder;
        public WindowBanHang(Data.Transit transit, ControlLibrary.POSButtonTable table)
        {
            mTransit = transit;
            mPOSButtonTable = table;
            InitializeComponent();
            PhanQuyen();
        }

        private void PhanQuyen()
        {
            Data.BOChiTietQuyen quyenSoLuong = mTransit.BOChiTietQuyen.KiemTraQuyen((int)Data.TypeChucNang.BanHang.ThayDoiSoLuong);
            txtSoLuong.Tag = quyenSoLuong;
            if (!mTransit.KiemTraChucNang((int)Data.TypeChucNang.BanHang.ThayDoiSoLuong) || !quyenSoLuong.ChiTietQuyen.ChoPhep)
            {
                txtSoLuong.IsEnabled = false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            uCMenuBanHang.SetTransit(mTransit);
            uCTile.OnEventExit += new ControlLibrary.UCTile.OnExit(uCTile_OnEventExit);
            uCTile.TenChucNang = "Bán hàng";
            uCTile.SetTransit(mTransit);
            mProcessOrder = new ProcessOrder.ProcessOrder(mTransit);
            GanChucNang();
            LoadBanHang();
        }

        private void uCTile_OnEventExit()
        {
            this.Close();
        }

        private void btnChucNang_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.CommandParameter == null)
            {
                return;
            }
            Data.BOChiTietQuyen mPhanQuyen = (Data.BOChiTietQuyen)btn.Tag;
            if (mPhanQuyen.ChiTietQuyen.DangNhap)
            {
                UserControlLibrary.WindowLoginDialog loginWindow = new UserControlLibrary.WindowLoginDialog(mTransit);
                if (loginWindow.ShowDialog() == true)
                {
                    XuLyButonChucNang(btn);
                }
            }
            else
            {
                XuLyButonChucNang(btn);
            }

        }

        private void XuLyButonChucNang(Button btn)
        {
            switch ((int)btn.CommandParameter)
            {
                case (int)Data.TypeChucNang.BanHang.TinhTien:
                    TinhTien();
                    break;
                case (int)Data.TypeChucNang.BanHang.LuuHoaDon:
                    GuiNhaBep();
                    break;
                case (int)Data.TypeChucNang.BanHang.TamTinh:
                    TamTinh();
                    break;
                case (int)Data.TypeChucNang.BanHang.ThayDoiGia:
                    break;
                case (int)Data.TypeChucNang.BanHang.XoaMon:
                    XoaMon();
                    break;
                case (int)Data.TypeChucNang.BanHang.XoaToanBoMon:
                    XoaToanBoMon();
                    break;
                case (int)Data.TypeChucNang.BanHang.ChuyenBan:
                    ChuyenBan();
                    break;
                case (int)Data.TypeChucNang.BanHang.TachBan:
                    TachBan();
                    break;
                case (int)Data.TypeChucNang.BanHang.DongBan:
                    DongBan();
                    break;
                case (int)Data.TypeChucNang.BanHang.ChonGia:
                    ChonGia();
                    break;
                default:
                    break;
            }
        }
        private void ChonGia()
        {
            if (mProcessOrder.KiemTraHoaDonDaHoanThanh())
            {
                UserControlLibrary.WindowMessageBox.ShowDialog("Hóa đơn đã thanh toán, không thể thay đổi");
                return;
            }
            if (lvData.SelectedItems.Count > 0)
            {
                Data.BOChiTietBanHang chitiet = (Data.BOChiTietBanHang)lvData.SelectedItems[0];
                UserControlLibrary.WindowBanHangTheoGia win = new UserControlLibrary.WindowBanHangTheoGia(mTransit, chitiet.MENUKICHTHUOCMON);
                if (win.ShowDialog() == true)
                {
                    chitiet.ChangePriceChiTietBanHang(win._MenuGia.Gia);
                    lvData.Items.Refresh();
                    ReloadData();
                }
            }
        }
        private void DongBan()
        {
            if (mProcessOrder.BanHang.TrangThaiID == 3)
            {
                if (mProcessOrder.DongBan() > 0)
                {
                    mPOSButtonTable._ButtonTableStatusColor = (ControlLibrary.POSButtonTable.POSButtonTableStatusColor)mProcessOrder.BanHang.TrangThaiID;
                }
            }
            this.Close();
        }
        public void TamTinh()
        {
            if (mProcessOrder.KiemTraDanhSachMon() > 0)
            {
                WindowTamTinh win = new WindowTamTinh(mTransit, mProcessOrder.GetBanHang());
                if (win.ShowDialog() == true)
                {
                    if (mProcessOrder.TamTinh() > 0)
                    {
                        mPOSButtonTable._ButtonTableStatusColor = (ControlLibrary.POSButtonTable.POSButtonTableStatusColor)mProcessOrder.BanHang.TrangThaiID;
                        this.Close();

                    }
                }
            }
            else
            {
                UserControlLibrary.WindowMessageBox.ShowDialog("Không thể tính tiền hóa hơn ! Vui lòng chọn món");
            }
        }
        private void GuiNhaBep()
        {
            if (mProcessOrder.KiemTraDanhSachMon() == 0)
            {
                UserControlLibrary.WindowMessageBox.ShowDialog("Không thể gửi ra nhà bếp ! Vui lòng chọn món");
                return;
            }
            if (mProcessOrder.SendOrder() > 0)
            {
                mPOSButtonTable._ButtonTableStatusColor = (ControlLibrary.POSButtonTable.POSButtonTableStatusColor)mProcessOrder.BanHang.TrangThaiID;
            }
            this.Close();
        }
        private void TinhTien()
        {
            if (mProcessOrder.KiemTraDanhSachMon() > 0)
            {
                WindowTinhTien win = new WindowTinhTien(mTransit, mProcessOrder.GetBanHang());
                if (win.ShowDialog() == true)
                {
                    mProcessOrder.TinhTien();
                    mPOSButtonTable._ButtonTableStatusColor = (ControlLibrary.POSButtonTable.POSButtonTableStatusColor)mProcessOrder.BanHang.TrangThaiID;
                    this.Close();
                }
            }
            else
            {
                UserControlLibrary.WindowMessageBox.ShowDialog("Không thể tính tiền hóa hơn ! Vui lòng chọn món");
            }
        }
        private void XoaMon()
        {
            if (mProcessOrder.KiemTraHoaDonDaHoanThanh())
            {
                UserControlLibrary.WindowMessageBox.ShowDialog("Hóa đơn đã thanh toán, không thể thay đổi");
                return;
            }
            if (lvData.SelectedItems.Count > 0)
            {
                Data.BOChiTietBanHang chitiet = (Data.BOChiTietBanHang)lvData.SelectedItems[0];
                mProcessOrder.XoaChiTietBanHang(chitiet);
                lvData.Items.Remove(chitiet);
                ReloadData();
                if (lvData.Items.Count > 0)
                {
                    lvData.SelectedIndex = lvData.Items.Count - 1;
                }
            }
            XoaTextThongTinMon();
        }
        private void TachBan()
        {
            this.DialogResult = false;
            UserControlLibrary.WindowBanHangChonBan win1 = new UserControlLibrary.WindowBanHangChonBan(mTransit,true);
            if (win1.ShowDialog() == true)
            {
                UserControlLibrary.WindowBanHangTachBan win2 = new UserControlLibrary.WindowBanHangTachBan(mTransit, win1._TachGopBan);
                win2.ShowDialog();
            }
        }
        private void GopBan()
        {
            this.DialogResult = false;
            UserControlLibrary.WindowBanHangChonBan win1 = new UserControlLibrary.WindowBanHangChonBan(mTransit,false);
            if (win1.ShowDialog() == true)
            {
                UserControlLibrary.WindowBanHangGopBan win2 = new UserControlLibrary.WindowBanHangGopBan(mTransit, win1._TachGopBan);
                win2.ShowDialog();
            }
        }
        private void ChuyenBan()
        {
            this.DialogResult = false;
            UserControlLibrary.WindowBanHangChuyenBan win1 = new UserControlLibrary.WindowBanHangChuyenBan(mTransit);
            win1.ShowDialog();

        }
        private void XoaToanBoMon()
        {
            if (mProcessOrder.KiemTraHoaDonDaHoanThanh())
            {
                UserControlLibrary.WindowMessageBox.ShowDialog("Hóa đơn đã thanh toán, không thể thay đổi");
                return;
            }
            foreach (Data.BOChiTietBanHang item in lvData.Items)
            {
                mProcessOrder.XoaChiTietBanHang(item);
            }
            lvData.Items.Clear();
            XoaTextThongTinMon();
        }
        private void XoaTextThongTinMon()
        {
            if (lvData.Items.Count == 0)
            {
                txtTenMon.Text = "";
                txtSoLuong.Text = "";
            }
        }
        private void LoadBanHang()
        {
            txtMaHoaDon.Text = "HĐ: " + mProcessOrder.BanHang.MaHoaDon.ToString();
            txtTenNhanVien.Text = "NV: " + mTransit.NhanVien.TenNhanVien;
            txtTenBan.Text = mTransit.Ban.TenBan;
            ReloadData();
            lvData.Items.Clear();
            foreach (var item in mProcessOrder.ListChiTietBanHang)
            {
                lvData.Items.Add(item);
            }

        }
        private void ReloadData()
        {
            txtTongTien.Text = Utilities.MoneyFormat.ConvertToStringFull(mProcessOrder.GetBanHang().TongTien());
        }
        private void AddChiTietBanHang(Data.BOChiTietBanHang item)
        {
            ListViewItem li = new ListViewItem();
            li.Content = item;
            if (mProcessOrder.AddChiTietBanHang(item) == 0)
            {
                lvData.Items.Add(item);
            }
            else
            {
                lvData.Items.Refresh();
            }
            if (lvData.Items.Count > 0)
            {
                lvData.SelectedIndex = lvData.Items.Count - 1;
            }
            ReloadData();
        }

        private void lvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvData.SelectedItems.Count > 0)
            {
                mProcessOrder.CurrentChiTietBanHang = (Data.BOChiTietBanHang)lvData.SelectedItems[0];
                ThayDoiQty();
            }
        }

        private void ThayDoiQty()
        {
            if (mProcessOrder.CurrentChiTietBanHang != null)
            {
                IsThayDoiSoLuong = false;
                txtSoLuong.Text = mProcessOrder.CurrentChiTietBanHang.CHITIETBANHANG.SoLuongBan.ToString();
                txtTenMon.Text = mProcessOrder.CurrentChiTietBanHang.TenMon.ToString();
                txtSoLuong.Focus();
                TextBox_PreviewMouseDown(txtSoLuong, null);
                IsThayDoiSoLuong = true;
            }
        }

        private void TextBox_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.SelectAll();
            uCKeyPad._TextBox = txt;
        }

        private void txtSoLuong_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mProcessOrder.CurrentChiTietBanHang != null && IsThayDoiSoLuong)
            {
                string str = "1";
                if (txtSoLuong.Text != "")
                {
                    str = txtSoLuong.Text;
                }
                mProcessOrder.CurrentChiTietBanHang.ChangeQtyChiTietBanHang(System.Convert.ToInt32(str));
                ReloadData();
                if (lvData.SelectedItems.Count > 0)
                {
                    lvData.SelectedItems[0] = mProcessOrder.CurrentChiTietBanHang;
                    lvData.Items.Refresh();
                }
            }
        }


        private void GanChucNang()
        {
            IQueryable<Data.GIAODIENCHUCNANGBANHANG> lsArray = Data.BOGiaoDienChucNangBanHang.GetNoTracking(mTransit).OrderBy(s => s.ID);
            foreach (var item in lsArray)
            {
                Data.BOChiTietQuyen ctq = mTransit.BOChiTietQuyen.KiemTraQuyen((int)item.ChucNangID);
                var myButton = (POSButtonChucNang)this.FindName("btnChucNang_" + item.ID);
                myButton.Tag = ctq;
                myButton.CommandParameter = item.ChucNangID;
                if (!ctq.ChiTietQuyen.ChoPhep || item.ChucNangID == 0 || !mTransit.KiemTraChucNang((int)item.ChucNangID))
                {
                    myButton.IsEnabled = false;
                    myButton.Content = "";
                    myButton.Image = null;
                }
                else
                {
                    myButton.Content = item.HienThi;
                    if (item.Hinh != null && item.Hinh.Length > 0)
                        myButton.Image = Utilities.ImageHandler.BitmapImageFromByteArray(item.Hinh);
                    else
                        myButton.Image = null;
                }
            }
        }

        private void uCMenuBanHang__OnEventMenuKichThuocMon(Data.BOMenuKichThuocMon ob)
        {
            Data.BOChiTietBanHang item = new Data.BOChiTietBanHang(ob, mTransit);
            AddChiTietBanHang(item);
        }

        private void txt_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (Char.IsNumber(e.Text, e.Text.Length - 1))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}