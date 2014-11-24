﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for WindowTamTinh.xaml
    /// </summary>
    public partial class WindowTamTinh : Window
    {
        private Data.Transit mTransit;
        private Data.BOBanHang mBOBanHang;
        private Data.BOXuliTinhTien mBOXuliTinhTien;
        public WindowTamTinh(Data.Transit transit, Data.BOBanHang banhang)
        {
            mTransit = transit;
            mBOBanHang = banhang;
            mBOXuliTinhTien = new Data.BOXuliTinhTien(mTransit, mBOBanHang);            
            InitializeComponent();            
        } 

        private void txtGiamGia_TextChanged(object sender, TextChangedEventArgs e)
        {
            mBOXuliTinhTien.TienGiam = Utilities.MoneyFormat.ConvertToDecimal(txtGiamGia.Text) * mBOXuliTinhTien.TongTien / 100;
            ReLoadData();
        }
        private void ReLoadData()
        {
            if (txtTongTien != null)
            {
                txtTongTien.Text = "Tổng Tiền: " + Utilities.MoneyFormat.ConvertToStringFull(mBOXuliTinhTien.TongTien);
            }
            if (txtTongTienPhaiTra != null)
            {
                txtTongTienPhaiTra.Text = Utilities.MoneyFormat.ConvertToStringFull(mBOXuliTinhTien.TongTienPhaiTra);
            }            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            txtGiamGia._UCKeyPad = uCKeyPad1;            
            if (mBOXuliTinhTien.GiamGiaPhanTram>0)
                txtGiamGia.Text = Utilities.NumberFormat.FormatToString(mBOXuliTinhTien.GiamGiaPhanTram);
            ReLoadData();
        }
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnDongY_Click(object sender, RoutedEventArgs e)
        {
            mBOBanHang.BANHANG = mBOXuliTinhTien.BanHang;
            this.DialogResult = true;
        }

        private void btnChonKhachHang_Click(object sender, RoutedEventArgs e)
        {
            UserControlLibrary.WindowTimKhachHang win = new UserControlLibrary.WindowTimKhachHang(mTransit);
            if (win.ShowDialog() == true)
            {
                mBOXuliTinhTien.BanHang.KhachHangID = win._KhachHang.KhachHangID;
                //mBOXuliTinhTien.BanHang.KHACHHANG = win._KhachHang;
                btnChonKhachHang.Content = mBOXuliTinhTien.BanHang.KHACHHANG.TenKhachHang;
            }
        }
    }
}
