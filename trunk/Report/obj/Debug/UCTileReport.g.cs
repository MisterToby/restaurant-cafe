﻿#pragma checksum "..\..\UCTileReport.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "850318CF9658772580A098342E539DF3"
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
using System.Windows.Forms.Integration;
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


namespace Report {
    
    
    /// <summary>
    /// UCTileReport
    /// </summary>
    public partial class UCTileReport : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\UCTileReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ControlLibrary.POSButtonImageClick btnBack;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\UCTileReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbPage;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\UCTileReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ControlLibrary.POSButtonImageClick btnForward;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\UCTileReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ControlLibrary.POSButtonImageClick btnPrint;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\UCTileReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ControlLibrary.POSButtonImageClick btnPDF;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\UCTileReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ControlLibrary.POSButtonImageClick btnDong;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\UCTileReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpChonNgay;
        
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
            System.Uri resourceLocater = new System.Uri("/Report;component/uctilereport.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UCTileReport.xaml"
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
            this.btnBack = ((ControlLibrary.POSButtonImageClick)(target));
            
            #line 38 "..\..\UCTileReport.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lbPage = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btnForward = ((ControlLibrary.POSButtonImageClick)(target));
            
            #line 40 "..\..\UCTileReport.xaml"
            this.btnForward.Click += new System.Windows.RoutedEventHandler(this.btnForward_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnPrint = ((ControlLibrary.POSButtonImageClick)(target));
            
            #line 41 "..\..\UCTileReport.xaml"
            this.btnPrint.Click += new System.Windows.RoutedEventHandler(this.btnPrint_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnPDF = ((ControlLibrary.POSButtonImageClick)(target));
            
            #line 42 "..\..\UCTileReport.xaml"
            this.btnPDF.Click += new System.Windows.RoutedEventHandler(this.btnPDF_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnDong = ((ControlLibrary.POSButtonImageClick)(target));
            
            #line 43 "..\..\UCTileReport.xaml"
            this.btnDong.Click += new System.Windows.RoutedEventHandler(this.btnDong_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dtpChonNgay = ((System.Windows.Controls.DatePicker)(target));
            
            #line 44 "..\..\UCTileReport.xaml"
            this.dtpChonNgay.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.dtpChonNgay_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
