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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Data.Transit mTransit = null;
        public MainWindow()
        {
            InitializeComponent();
            mTransit = new Data.Transit();
        }

        private void btnQuanLyThucDon_Click(object sender, RoutedEventArgs e)
        {
            WindowMenuChange win = new WindowMenuChange(mTransit);
            win.ShowDialog();
        }

        private void btnQuanLyNhanVien_Click(object sender, RoutedEventArgs e)
        {
            WindowQuanLyNhanVien win = new WindowQuanLyNhanVien(mTransit);
            win.ShowDialog();
        }

        private void btnQuanLyMayIn_Click(object sender, RoutedEventArgs e)
        {
            WindowQuanLyMayIn win = new WindowQuanLyMayIn(mTransit);
            win.ShowDialog();
        }

        private void btnBanHang_Click(object sender, RoutedEventArgs e)
        {
            //WindowSoDoBan win = new WindowSoDoBan(mTransit);
            WindowBanHang win = new WindowBanHang(mTransit);
            win.ShowDialog();
        }

        private void btnQuanLyKhachHang_Click(object sender, RoutedEventArgs e)
        {
            WindowQuanLyKhachHang win = new WindowQuanLyKhachHang(mTransit);
            win.ShowDialog();
        }

        private void btnQuanLyThuChi_Click(object sender, RoutedEventArgs e)
        {
            WindowQuanLyKhachHang win = new WindowQuanLyKhachHang(mTransit);
            win.ShowDialog();
        }

        private void btnQuanLyGiaKhuyenMai_Click(object sender, RoutedEventArgs e)
        {
            WindowQuanLyGiaKhuyenMai win = new WindowQuanLyGiaKhuyenMai(mTransit);
            win.ShowDialog();
        }

        private void btnQuanLyPhanQuyen_Click(object sender, RoutedEventArgs e)
        {
            WindowQuanLyPhanQuyen win = new WindowQuanLyPhanQuyen(mTransit);
            win.ShowDialog();
        }

        private void btnQuanLyKhoHang_Click(object sender, RoutedEventArgs e)
        {
            WindowQuanLyKhoHang win = new WindowQuanLyKhoHang(mTransit);
            win.ShowDialog();
        }

        private void btnQuanLyDinhLuong_Click(object sender, RoutedEventArgs e)
        {
            WindowQuanLyDinhLuong win = new WindowQuanLyDinhLuong(mTransit);
            win.ShowDialog();
        }

        private void btnQuanSoDoBan_Click(object sender, RoutedEventArgs e)
        {
            WindowQuanLySoDoBan win = new WindowQuanLySoDoBan(mTransit);
            win.ShowDialog();
        }

        private void btnBaoCaoThongKe_Click(object sender, RoutedEventArgs e)
        {
            WindowBaoCaoThongKe win = new WindowBaoCaoThongKe(mTransit);
            win.ShowDialog();
        }

        private void btnThongTinCongTy_Click(object sender, RoutedEventArgs e)
        {
            WindowThongTinCongTy win = new WindowThongTinCongTy(mTransit);
            win.ShowDialog();
        }

        private void btnThongTinPhanMem_Click(object sender, RoutedEventArgs e)
        {
            WindowThongTinPhanMem win = new WindowThongTinPhanMem(mTransit);
            win.ShowDialog();
        }
    }
}
