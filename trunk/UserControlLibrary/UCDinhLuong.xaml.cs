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
    /// Interaction logic for UCDinhLuong.xaml
    /// </summary>
    public partial class UCDinhLuong : UserControl
    {
        private Data.Transit mTransit = null;
        public UCDinhLuong()
        {
            InitializeComponent();
        }

        public void Init(Data.Transit transit)
        {
            mTransit = transit;
            uCMenu._OnEventMenuKichThuocMon += new UCMenu.EventMenuKichThuocMon(uCMenu__OnEventMenuKichThuocMon);
            uCMenu.Init(mTransit);
            uCMenu._IsDinhLuong = true;
            uCMenu._IsSoLuong = false;
            uCMenu._IsTrongLuong = false;
            uCMenu._IsTheTich = false;
            uCMenu._IsThoiGian = false;
        }

        void uCMenu__OnEventMenuKichThuocMon(Data.BOMenuKichThuocMon ob)
        {
            uCDanhSachDinhLuong.Init(ob, mTransit);
            uCDanhSachDinhLuong.LoadDanhSach();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            uCDanhSachDinhLuong.Window_KeyDown(sender, e);
        }
    }
}