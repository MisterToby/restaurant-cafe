﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Linq;

namespace UserControlLibrary
{
    /// <summary>
    /// Interaction logic for UCLichBieuKhongDinhKy.xaml
    /// </summary>
    public partial class UCLichBieuKhongDinhKy : UserControl
    {
        private Data.Transit mTransit = null;
        private Data.BOLichBieuKhongDinhKy mItem = null;
        private List<Data.BOLichBieuKhongDinhKy> lsArrayDeleted = null;
        private Data.BOLichBieuKhongDinhKy BOLichBieuKhongDinhKy = null;

        public UCLichBieuKhongDinhKy(Data.Transit transit)
        {
            InitializeComponent();
            mTransit = transit;
            BOLichBieuKhongDinhKy = new Data.BOLichBieuKhongDinhKy(mTransit);
        }

        private void LoadDanhSach()
        {
            IQueryable<Data.BOLichBieuKhongDinhKy> lsArray = BOLichBieuKhongDinhKy.GetAll(mTransit);
            lvData.Items.Clear();
            foreach (var item in lsArray)
            {
                AddList(item);
            }
        }

        private void AddList(Data.BOLichBieuKhongDinhKy item)
        {
            ListViewItem li = new ListViewItem();
            li.Content = item;
            li.Tag = item;
            lvData.Items.Add(li);
        }

        private void lvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvData.SelectedItems.Count > 0)
            {
                ListViewItem li = (ListViewItem)lvData.SelectedItems[0];
                mItem = (Data.BOLichBieuKhongDinhKy)li.Tag;
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            UserControlLibrary.WindowThemLichBieuKhongDinhKy win = new UserControlLibrary.WindowThemLichBieuKhongDinhKy(mTransit);
            if (win.ShowDialog() == true)
            {
                AddList(win._Item);
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (lvData.SelectedItems.Count > 0)
            {
                ListViewItem li = (ListViewItem)lvData.SelectedItems[0];
                mItem = (Data.BOLichBieuKhongDinhKy)li.Tag;

                UserControlLibrary.WindowThemLichBieuKhongDinhKy win = new UserControlLibrary.WindowThemLichBieuKhongDinhKy(mTransit);
                win._Item = mItem;
                if (win.ShowDialog() == true)
                {
                    win._Item.LichBieuKhongDinhKy.Edit = true;
                    li.Tag = win._Item;
                    li.Content = win._Item;
                    lvData.Items.Refresh();
                }
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (lvData.SelectedItems.Count > 0)
            {
                mItem = (Data.BOLichBieuKhongDinhKy)((ListViewItem)lvData.SelectedItems[0]).Tag;
                if (lsArrayDeleted == null)
                {
                    lsArrayDeleted = new List<Data.BOLichBieuKhongDinhKy>();
                }
                if (mItem.LichBieuKhongDinhKy.LichBieuKhongDinhKyID > 0)
                    lsArrayDeleted.Add(mItem);
                lvData.Items.Remove(lvData.SelectedItems[0]);
                if (lvData.Items.Count > 0)
                {
                    lvData.SelectedIndex = 0;
                }
            }
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            List<Data.BOLichBieuKhongDinhKy> lsArray = null;
            foreach (ListViewItem li in lvData.Items)
            {
                mItem = (Data.BOLichBieuKhongDinhKy)li.Tag;
                if (mItem.LichBieuKhongDinhKy.LichBieuKhongDinhKyID == 0 || mItem.LichBieuKhongDinhKy.Edit == true)
                {
                    if (lsArray == null)
                        lsArray = new List<Data.BOLichBieuKhongDinhKy>();
                    lsArray.Add(mItem);
                }
            }
            BOLichBieuKhongDinhKy.Luu(lsArray, lsArrayDeleted, mTransit);
            LoadDanhSach();
            UserControlLibrary.WindowMessageBox messageBox = new UserControlLibrary.WindowMessageBox(mTransit.StringButton.LuuThanhCong);
            messageBox.ShowDialog();
        }

        public void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.S && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                btnLuu_Click(null, null);
                return;
            }
            if (e.Key == System.Windows.Input.Key.N && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                btnThem_Click(null, null);
                return;
            }
            if (e.Key == System.Windows.Input.Key.R && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                btnDanhSach_Click(null, null);
                return;
            }
            if (e.Key == System.Windows.Input.Key.F2)
            {
                btnSua_Click(null, null);
                return;
            }
            if (e.Key == System.Windows.Input.Key.Delete)
            {
                btnXoa_Click(null, null);
                return;
            }
        }

        private void btnDanhSach_Click(object sender, RoutedEventArgs e)
        {
            mItem = null;
            lsArrayDeleted = null;
            LoadDanhSach();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDanhSach();
        }
    }
}