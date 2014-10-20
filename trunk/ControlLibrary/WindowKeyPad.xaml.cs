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

namespace ControlLibrary
{
    /// <summary>
    /// Interaction logic for WindowKeyPad.xaml
    /// </summary>
    public partial class WindowKeyPad : Window
    {        
        public WindowKeyPad()
        {
            _TextBox = null;
            InitializeComponent();
        }

        public TextBox _TextBox { get; set; }
        public TypeKeyPad _TypeKeyPad { get; set; }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            if (_TextBox != null)
            {
                Button btn = (Button)sender;
                string input = btn.Content.ToString();
                switch (input)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        _TextBox.Text += btn;
                        break;
                    case ".":
                        if (_TypeKeyPad == TypeKeyPad.Decimal)
                            if (_TextBox.Text.Length == 0)

                                _TextBox.Text += "0.";

                            else if (!_TextBox.Text.Contains('.'))
                                _TextBox.Text += ".";
                        break;
                }
            }
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
