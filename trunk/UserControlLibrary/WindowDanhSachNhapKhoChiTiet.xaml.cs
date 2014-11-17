﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Linq;

namespace UserControlLibrary
{
    /// <summary>
    /// Interaction logic for WindowDanhSachNhapKhoChiTiet.xaml
    /// </summary>
    public partial class WindowDanhSachNhapKhoChiTiet : Window
    {
        public List<Data.BOChiTietNhapKho> lsArray = null;
        public List<Data.BOChiTietNhapKho> lsArrayDeleted = null;
        private List<Data.LOAIBAN> lsLoaiBan = null;
        private Data.BONhapKho mNhapKho = null;
        private Data.Transit mTransit = null;
        private Data.BOChiTietNhapKho BOChiTietNhapKho = null;

        public WindowDanhSachNhapKhoChiTiet()
        {
            InitializeComponent();
        }

        public void Init(Data.BONhapKho nhapKho, Data.Transit transit)
        {
            mTransit = transit;
            BOChiTietNhapKho = new Data.BOChiTietNhapKho(transit);
            mNhapKho = nhapKho;
            lsLoaiBan = Data.BOLoaiBan.GetAllNoTracking(mTransit).ToList();
            if (mNhapKho != null)
            {
                btnLuu.Visibility = System.Windows.Visibility.Visible;
                btnThemMon.Visibility = System.Windows.Visibility.Visible;
                btnDanhSach.Visibility = System.Windows.Visibility.Visible;
            }
        }

        public void LoadDanhSach()
        {
            if (mNhapKho != null)
            {
                lvData.ItemsSource = lsArray = BOChiTietNhapKho.GetAll((int)mNhapKho.NhapKho.NhapKhoID, mTransit).ToList();
                lvData.Items.Refresh();
            }
            else
            {
                lsArray = new List<Data.BOChiTietNhapKho>();
                lvData.ItemsSource = lsArray;
                lvData.Items.Refresh();
            }
        }

        private void btnDanhSach_Click(object sender, RoutedEventArgs e)
        {
            lsArrayDeleted = null;
            LoadDanhSach();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnThemMon_Click(object sender, RoutedEventArgs e)
        {
            WindowChonMon win = new WindowChonMon(mTransit, true);
            if (win.ShowDialog() == true)
            {
                Data.BOChiTietNhapKho item = new Data.BOChiTietNhapKho();
                item.MenuMon = win._ItemMon.MenuMon;

                item.ChiTietNhapKho.KichThuocBan = 1;
                item.ChiTietNhapKho.MonID = win._ItemMon.MenuMon.MonID;
                item.ChiTietNhapKho.SoLuong = 1;
                item.ChiTietNhapKho.GiaBan = 0;
                item.ChiTietNhapKho.GiaMua = 0;
                item.ChiTietNhapKho.NgayHetHan = DateTime.Now;
                item.ChiTietNhapKho.NgaySanXuat = DateTime.Now;
                item.ChiTietNhapKho.Deleted = false;
                item.ChiTietNhapKho.Visual = true;
                item.ChiTietNhapKho.Edit = false;
                item.ListLoaiBan = lsLoaiBan;
                if (item.ListLoaiBan.Count > 0)
                    item.ChiTietNhapKho.LoaiBanID = item.ListLoaiBan[0].LoaiBanID;
                if (lsArray == null)
                    lsArray = new List<Data.BOChiTietNhapKho>();
                lsArray.Add(item);
                lvData.Items.Refresh();
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            Data.BOChiTietNhapKho item = ((Button)sender).DataContext as Data.BOChiTietNhapKho;
            if (item.ChiTietNhapKho.ChiTietNhapKhoID > 0)
            {
                if (lsArrayDeleted == null)
                    lsArrayDeleted = new List<Data.BOChiTietNhapKho>();
                lsArrayDeleted.Add(item);

            }
            lsArray.Remove(item);
            lvData.Items.Refresh();
        }

        private void cbbLoaiBan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data.BOChiTietNhapKho item = ((ComboBox)sender).DataContext as Data.BOChiTietNhapKho;
            if (item != null)
            {
                switch (item.ChiTietNhapKho.LoaiBanID)
                {
                    case (int)Data.EnumLoaiBan.Cai:
                    case (int)Data.EnumLoaiBan.DinhLuong:
                    case (int)Data.EnumLoaiBan.Gram:
                    case (int)Data.EnumLoaiBan.Millilit:
                    case (int)Data.EnumLoaiBan.Kg:
                    case (int)Data.EnumLoaiBan.Lit:
                    case (int)Data.EnumLoaiBan.Gio:
                    case (int)Data.EnumLoaiBan.Phut:
                    case (int)Data.EnumLoaiBan.Giay:
                        item.ChiTietNhapKho.Edit = true;
                        if (item.ChiTietNhapKho.ChiTietNhapKhoID == 0)
                            item.ChiTietNhapKho.KichThuocBan = 1;
                        else if (item.ChiTietNhapKho.LoaiBanID != item.LoaiBan.LoaiBanID)
                            item.ChiTietNhapKho.KichThuocBan = 1;
                        break;
                    default:
                        break;
                }
                item.LoaiBan = item.ListLoaiBan.Where(s => s.LoaiBanID == item.ChiTietNhapKho.LoaiBanID).FirstOrDefault();
                lvData.Items.Refresh();
            }
        }

        private void txt_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (Char.IsNumber(e.Text, e.Text.Length - 1))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDanhSach();
        }
    }
}