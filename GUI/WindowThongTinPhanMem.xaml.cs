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
    /// Interaction logic for WindowThongTinPhanMem.xaml
    /// </summary>
    public partial class WindowThongTinPhanMem : Window
    {
        private Data.Transit mTransit = null;
        public WindowThongTinPhanMem(Data.Transit transit)
        {
            InitializeComponent();
            mTransit = transit;
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
