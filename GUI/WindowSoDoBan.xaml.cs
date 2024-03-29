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
    /// Interaction logic for WindowSoDoBan.xaml
    /// </summary>
    public partial class WindowSoDoBan : Window
    {
        private Data.Transit mTransit;
        public WindowSoDoBan(Data.Transit tran)
        {
            mTransit = tran;
            InitializeComponent();
            ucTile.SetTransit(tran);
            ucTile.TenChucNang = "Sơ đồ bàn";

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            uCFloorPlan1.Init(mTransit);
            uCListArea1.Init(mTransit);
            uCListArea1._UCFloorPlan = uCFloorPlan1;

            if (mTransit.NhanVien.CapDo < (int)Data.EnumLoaiNhanVien.NhanVien)
                btnThoat.Content = "Màn hình chính";
            else
                btnThoat.Content = "Thoát";
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
           if (mTransit.NhanVien.CapDo < (int)Data.EnumLoaiNhanVien.NhanVien)
                DialogResult = false;
            else
                DialogResult = true;
        }

        private void uCFloorPlan1__OnEventFloorPlan(ControlLibrary.POSButtonTable tbl)
        {            
            mTransit.Ban = tbl._Ban;
            btnForcus.Focus();
            WindowBanHang win = new WindowBanHang(mTransit, uCFloorPlan1);
            win.ShowDialog();
        }
        public void LoadAlllStatus()
        {
            uCFloorPlan1.LoadAlllStatus();
        }

        private void btnChucNang_Click(object sender, RoutedEventArgs e)
        {
            UserControlLibrary.WindowChucNangSoDoBan win = new UserControlLibrary.WindowChucNangSoDoBan(uCFloorPlan1, mTransit);
            win.ShowDialog();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key==Key.Enter)
            //{
            //    e.Handled = true;
            //}
        }
    }
}
