﻿#pragma checksum "..\..\..\View\CreateProduct.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DE1068394FC1537101CFBF8418E692A372B9BCF0"
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
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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
    /// CreateProduct
    /// </summary>
    public partial class CreateProduct : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\View\CreateProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ID;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\View\CreateProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Ten;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\View\CreateProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Category;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\View\CreateProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SoLuong;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\View\CreateProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Gia;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\View\CreateProduct.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Management_Project;component/view/createproduct.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\CreateProduct.xaml"
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
            
            #line 23 "..\..\..\View\CreateProduct.xaml"
            this.ID.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ID_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Ten = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\View\CreateProduct.xaml"
            this.Ten.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Ten_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Category = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\..\View\CreateProduct.xaml"
            this.Category.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Category_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SoLuong = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\View\CreateProduct.xaml"
            this.SoLuong.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SoLuong_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Gia = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\View\CreateProduct.xaml"
            this.Gia.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Gia_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\View\CreateProduct.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.ADD_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

