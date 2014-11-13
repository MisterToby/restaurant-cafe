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

namespace ControlLibrary
{
    /// <summary>
    /// Interaction logic for UCFloorPlan.xaml
    /// </summary>
    public partial class UCFloorPlan : UserControl
    {
        public delegate void EventFloorPlan(POSButtonTable tbl);
        public event EventFloorPlan _OnEventFloorPlan;
        public bool _IsEdit { get; set; }        
        private Data.Transit mTransit;
        private List<Data.BAN> mListBan;
        public Data.KHU _Khu { get; set; }
        public UCFloorPlan()
        {            
            InitializeComponent();
        }
        
        public void Init(Data.Transit tran)
        {
            mTransit = tran;
        }        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {            
        }
        public void SaveChange()
        {
            List<POSButtonTable> listWillRemove = new List<POSButtonTable>();
            foreach (POSButtonTable tbl in this.gridFloorPlan.Children)
            {
                if (tbl._Ban.BanID==0)
                {
                    Data.BOBan.Them(tbl._Ban, mTransit);
                    tbl._ButtonTableStatus = POSButtonTable.POSButtonTableStatus.None;
                }
                else
                {
                    switch (tbl._ButtonTableStatus)
                    {                        
                        case POSButtonTable.POSButtonTableStatus.Edit:
                            Data.BOBan.CapNhat(tbl._Ban, mTransit);
                            tbl._ButtonTableStatus = POSButtonTable.POSButtonTableStatus.None;
                            break;
                        case POSButtonTable.POSButtonTableStatus.Delete:
                            Data.BOBan.Xoa(tbl._Ban.BanID, mTransit);
                            listWillRemove.Add(tbl);
                            break;
                        default:
                            break;
                    }                         
                }                
            }
            foreach (var item in listWillRemove)
            {
                gridFloorPlan.Children.Remove(item);
            }
        }
        public void LoadTable()
        {
            if (_Khu != null)
            {                
                //var listBan = Data.BOBan.GetTablePerArea(mTransit, _Khu);                                
                mListBan = Data.BOBan.GetTablePerArea(mTransit, _Khu);
                LoadDataToGui();
            }
        }
        private void LoadDataToGui()
        {
            gridFloorPlan.Children.Clear();
            foreach (var ban in mListBan)
            {
                addTable(ban);
            }
            imgBackground.Source = Utilities.ImageHandler.BitmapImageFromByteArray(_Khu.Hinh);
        }
        public void LoadBackgroundImage(BitmapImage img)
        {
            imgBackground.Source = img;
        }
        public void LoadTable(Data.KHU khu)
        {
            _Khu = khu;
            LoadTable();
        }
        public void addTable(Data.BAN ban)
        {
            POSButtonTable tbl = new POSButtonTable();
            tbl.IsEnabled = true;            
            tbl._UserControlParent = this;
            tbl._Ban = ban;
            tbl._IsEdit = this._IsEdit;
            tbl.TableDraw();
            tbl._ButtonTableStatus = POSButtonTable.POSButtonTableStatus.None;
            tbl.Click += new RoutedEventHandler(tbl_Click);
            gridFloorPlan.Children.Add(tbl);            
        }
        public void removeTable(POSButtonTable ban)
        {
            if (ban._Ban.BanID==0)
            {
                gridFloorPlan.Children.Remove(ban);
            }
            else
            {
                ban._ButtonTableStatus = ControlLibrary.POSButtonTable.POSButtonTableStatus.Delete;
                ban.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        public void reloadTable()
        {
            mTransit.KaraokeEntities.Refresh(System.Data.Objects.RefreshMode.StoreWins, mListBan);
            LoadDataToGui();
        }
        void tbl_Click(object sender, RoutedEventArgs e)
        {
            POSButtonTable tbl = (POSButtonTable)sender;
            if (_OnEventFloorPlan!=null)
            {
                _OnEventFloorPlan(tbl);
            }
        }
    }
}
