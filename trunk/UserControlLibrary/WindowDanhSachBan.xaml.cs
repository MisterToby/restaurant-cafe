﻿using System.Windows;
using System.Windows.Input;

namespace UserControlLibrary
{
    /// <summary>
    /// Interaction logic for WindowDanhSachBan.xaml
    /// </summary>
    public partial class WindowDanhSachBan : Window
    {
        private Data.Transit mTransit = null;
        private Data.MENUMON mMon = null;

        public WindowDanhSachBan(Data.MENUMON mon, Data.Transit transit)
        {
            InitializeComponent();
            mTransit = transit;
            mMon = mon;
            uCDanhSachBanList.OnEventExit += new UCDanhSachBanList.OnExit(uCDanhSachBanList_OnEventExit);
            uCDanhSachBanList.Init(mMon, mTransit);
        }

        private void uCDanhSachBanList_OnEventExit()
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            uCDanhSachBanList.LoadDanhSach();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            uCDanhSachBanList.Window_KeyDown(sender, e);
        }
    }
}