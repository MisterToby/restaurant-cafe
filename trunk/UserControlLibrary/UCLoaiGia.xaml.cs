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

namespace UserControlLibrary
{
    /// <summary>
    /// Interaction logic for UCLoaiGia.xaml
    /// </summary>
    public partial class UCLoaiGia : UserControl
    {
        private Data.MENULOAIGIA mLoaiGia = null;
        private Data.Transit mTransit = null;
        public UCLoaiGia(Data.Transit transit)
        {
            InitializeComponent();
            mTransit = transit;
        }

        private void btnTaoMoi_Click(object sender, RoutedEventArgs e)
        {
            mLoaiGia = null;
            SetValues();
        }

        private void btnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            if (mLoaiGia != null)
            {
                GetValues();
                Data.BOMenuLoaiGia.CapNhat(mLoaiGia);
                LoadDanhSachLoaiGia();
                btnTaoMoi_Click(sender, e);
                lbStatus.Text = "Thêm thành công";
            }
            else
            {
                GetValues();
                Data.BOMenuLoaiGia.Them(mLoaiGia);
                btnTaoMoi_Click(null, null);
                LoadDanhSachLoaiGia();
                lbStatus.Text = "Cập nhật thành công";
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (mLoaiGia != null)
            {
                Data.BOMenuLoaiGia.Xoa(mLoaiGia.LoaiGiaID);
                btnTaoMoi_Click(null, null);
                LoadDanhSachLoaiGia();
            }
        }

        private void LoadDanhSachLoaiGia()
        {
            lvData.ItemsSource = Data.BOMenuLoaiGia.GetAll();
        }

        private bool CheckValues()
        {
            lbStatus.Text = "";
            if (txtLoaiGia.Text == "")
            {
                lbStatus.Text = "Loại giá không được bỏ trống";
                return false;
            }
            return true;
        }

        private void GetValues()
        {
            if (mLoaiGia == null)
            {
                mLoaiGia = new Data.MENULOAIGIA();
            }
            mLoaiGia.DienGiai = txtDienGiai.Text;
            mLoaiGia.Ten = txtLoaiGia.Text;
            mLoaiGia.Deleted = false;
            mLoaiGia.Visual = true;
        }

        private void SetValues()
        {
            if (mLoaiGia != null)
            {
                txtDienGiai.Text = mLoaiGia.DienGiai;
                txtLoaiGia.Text = mLoaiGia.Ten;
                btnThem.Content = "Cập nhật";
            }
            else
            {
                txtDienGiai.Text = "";
                txtLoaiGia.Text = "";
                btnThem.Content = "Thêm mới";
            }
        }        

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                mLoaiGia = (item as Data.MENULOAIGIA);
                SetValues();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDanhSachLoaiGia();
        }
    }
}