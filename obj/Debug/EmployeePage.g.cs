﻿#pragma checksum "..\..\EmployeePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EA65BF998BEB346BE809B7F2F542B1FF47306B682147ED3C419643DEFF504A79"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using PetShop7;
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


namespace PetShop7 {
    
    
    /// <summary>
    /// EmployeePage
    /// </summary>
    public partial class EmployeePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid EmployeeDataGrid;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastnameTextBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MiddlenameTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox WorkingHoursCombo;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RoleCombo;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ProductCombo;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CheckCombo;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateButton;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteButton;
        
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
            System.Uri resourceLocater = new System.Uri("/PetShop7;component/employeepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EmployeePage.xaml"
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
            
            #line 8 "..\..\EmployeePage.xaml"
            ((PetShop7.EmployeePage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.EmployeeDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 20 "..\..\EmployeePage.xaml"
            this.EmployeeDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.EmployeeDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LastnameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.NameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.MiddlenameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.WorkingHoursCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.RoleCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.ProductCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.CheckCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\EmployeePage.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.UpdateButton = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\EmployeePage.xaml"
            this.UpdateButton.Click += new System.Windows.RoutedEventHandler(this.UpdateButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.DeleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\EmployeePage.xaml"
            this.DeleteButton.Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
