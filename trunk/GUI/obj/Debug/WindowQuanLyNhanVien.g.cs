﻿#pragma checksum "..\..\WindowQuanLyNhanVien.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "ACD2A7EDAE48D8C1860DA5E6F4B6248F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ControlLibrary;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GUI {
    
    
    /// <summary>
    /// WindowQuanLyNhanVien
    /// </summary>
    public partial class WindowQuanLyNhanVien : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\WindowQuanLyNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTenNhanVien;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\WindowQuanLyNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbLoaiNhanVien;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\WindowQuanLyNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTenDangNhap;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\WindowQuanLyNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtMatKhau;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\WindowQuanLyNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lbStatus;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\WindowQuanLyNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ControlLibrary.POSButtonIconHorizontal btnMoi;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\WindowQuanLyNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ControlLibrary.POSButtonIconHorizontal btnThem;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\WindowQuanLyNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ControlLibrary.POSButtonIconHorizontal btnXoa;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\WindowQuanLyNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvNhanVien;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\WindowQuanLyNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ControlLibrary.POSButtonIconHorizontal btnThoat;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GUI;component/windowquanlynhanvien.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowQuanLyNhanVien.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\WindowQuanLyNhanVien.xaml"
            ((GUI.WindowQuanLyNhanVien)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtTenNhanVien = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cbbLoaiNhanVien = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.txtTenDangNhap = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtMatKhau = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.lbStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.btnMoi = ((ControlLibrary.POSButtonIconHorizontal)(target));
            
            #line 30 "..\..\WindowQuanLyNhanVien.xaml"
            this.btnMoi.Click += new System.Windows.RoutedEventHandler(this.btnMoi_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnThem = ((ControlLibrary.POSButtonIconHorizontal)(target));
            
            #line 31 "..\..\WindowQuanLyNhanVien.xaml"
            this.btnThem.Click += new System.Windows.RoutedEventHandler(this.btnThem_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnXoa = ((ControlLibrary.POSButtonIconHorizontal)(target));
            
            #line 32 "..\..\WindowQuanLyNhanVien.xaml"
            this.btnXoa.Click += new System.Windows.RoutedEventHandler(this.btnXoa_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.lvNhanVien = ((System.Windows.Controls.ListView)(target));
            
            #line 34 "..\..\WindowQuanLyNhanVien.xaml"
            this.lvNhanVien.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvNhanVien_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnThoat = ((ControlLibrary.POSButtonIconHorizontal)(target));
            
            #line 43 "..\..\WindowQuanLyNhanVien.xaml"
            this.btnThoat.Click += new System.Windows.RoutedEventHandler(this.btnThoat_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
