﻿#pragma checksum "..\..\..\pg\VForging.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6CFC197F708410A39345886840367AB432F5E51527B12E817CF295C14D5582B3"
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
    /// VForging
    /// </summary>
    public partial class VForging : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\pg\VForging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox All;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\pg\VForging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Year;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\pg\VForging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Month;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\pg\VForging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label s;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\pg\VForging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label po;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\pg\VForging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date1;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\pg\VForging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date2;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\pg\VForging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView zerg;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\pg\VForging.xaml"
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
            System.Uri resourceLocater = new System.Uri("/TDP;component/pg/vforging.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pg\VForging.xaml"
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
            this.All = ((System.Windows.Controls.ComboBox)(target));
            
            #line 27 "..\..\..\pg\VForging.xaml"
            this.All.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Filter_Changed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Year = ((System.Windows.Controls.ComboBox)(target));
            
            #line 41 "..\..\..\pg\VForging.xaml"
            this.Year.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Year_Changed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Month = ((System.Windows.Controls.ComboBox)(target));
            
            #line 56 "..\..\..\pg\VForging.xaml"
            this.Month.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Month_Changed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.s = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.po = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.Date1 = ((System.Windows.Controls.DatePicker)(target));
            
            #line 94 "..\..\..\pg\VForging.xaml"
            this.Date1.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.Date1_Changed);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Date2 = ((System.Windows.Controls.DatePicker)(target));
            
            #line 103 "..\..\..\pg\VForging.xaml"
            this.Date2.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.Date2_Changed);
            
            #line default
            #line hidden
            return;
            case 8:
            this.zerg = ((System.Windows.Controls.ListView)(target));
            return;
            case 9:
            this.f4 = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

