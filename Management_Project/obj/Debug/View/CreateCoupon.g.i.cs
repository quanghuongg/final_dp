﻿#pragma checksum "..\..\..\View\CreateCoupon.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C8AF4663F8CAAB6BE8387DB4880D55B7155B379C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Management_Project;
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


namespace Management_Project {
    
    
    /// <summary>
    /// CreateCoupon
    /// </summary>
    public partial class CreateCoupon : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\View\CreateCoupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ID;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\View\CreateCoupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhanTram;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\View\CreateCoupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SoLuong;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\View\CreateCoupon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
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
            System.Uri resourceLocater = new System.Uri("/Management_Project;component/view/createcoupon.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\CreateCoupon.xaml"
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
            this.ID = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\View\CreateCoupon.xaml"
            this.ID.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ID_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PhanTram = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\..\View\CreateCoupon.xaml"
            this.PhanTram.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SoLuong_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SoLuong = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\View\CreateCoupon.xaml"
            this.SoLuong.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PhanTram_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\View\CreateCoupon.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

