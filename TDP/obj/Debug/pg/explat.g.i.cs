﻿#pragma checksum "..\..\..\pg\explat.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2C73F2820A12FEED66E0DF6922349461C28BADDAD0BADEB4F28D4B37EEAF633C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using TDP.pg;


namespace TDP.pg {
    
    
    /// <summary>
    /// explat
    /// </summary>
    public partial class explat : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\pg\explat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox All;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\pg\explat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Year;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\pg\explat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Month;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\pg\explat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label s;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\pg\explat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label po;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\pg\explat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date1;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\pg\explat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date2;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\pg\explat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label allstring;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\pg\explat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbsort;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\pg\explat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton newdetail;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\..\pg\explat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView zerg;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\pg\explat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame f4;
        
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
            System.Uri resourceLocater = new System.Uri("/TDP;component/pg/explat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pg\explat.xaml"
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
            
            #line 8 "..\..\..\pg\explat.xaml"
            ((TDP.pg.explat)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.unvis);
            
            #line default
            #line hidden
            return;
            case 2:
            this.All = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\..\pg\explat.xaml"
            this.All.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Filter_Changed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Year = ((System.Windows.Controls.ComboBox)(target));
            
            #line 43 "..\..\..\pg\explat.xaml"
            this.Year.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Year_Changed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Month = ((System.Windows.Controls.ComboBox)(target));
            
            #line 58 "..\..\..\pg\explat.xaml"
            this.Month.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Month_Changed);
            
            #line default
            #line hidden
            return;
            case 5:
            this.s = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.po = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Date1 = ((System.Windows.Controls.DatePicker)(target));
            
            #line 97 "..\..\..\pg\explat.xaml"
            this.Date1.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.Date1_Changed);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Date2 = ((System.Windows.Controls.DatePicker)(target));
            
            #line 106 "..\..\..\pg\explat.xaml"
            this.Date2.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.Date2_Changed);
            
            #line default
            #line hidden
            return;
            case 9:
            this.allstring = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.cbsort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 121 "..\..\..\pg\explat.xaml"
            this.cbsort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbsorting);
            
            #line default
            #line hidden
            return;
            case 11:
            this.newdetail = ((System.Windows.Controls.RadioButton)(target));
            
            #line 136 "..\..\..\pg\explat.xaml"
            this.newdetail.Click += new System.Windows.RoutedEventHandler(this.newdetail_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.zerg = ((System.Windows.Controls.ListView)(target));
            
            #line 172 "..\..\..\pg\explat.xaml"
            this.zerg.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.sel);
            
            #line default
            #line hidden
            return;
            case 13:
            this.f4 = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

