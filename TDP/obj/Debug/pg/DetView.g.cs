﻿#pragma checksum "..\..\..\pg\DetView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "10A4B624585FAA0A44F1ACA3373337312893E09AC052AC6D80137124D1A3DC62"
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
    /// DetView
    /// </summary>
    public partial class DetView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\pg\DetView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label allstring;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\pg\DetView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbsort;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\pg\DetView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton newdetail;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\pg\DetView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid zerg;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\pg\DetView.xaml"
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
            System.Uri resourceLocater = new System.Uri("/TDP;component/pg/detview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pg\DetView.xaml"
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
            
            #line 8 "..\..\..\pg\DetView.xaml"
            ((TDP.pg.DetView)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.unvis);
            
            #line default
            #line hidden
            return;
            case 2:
            this.allstring = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.cbsort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 36 "..\..\..\pg\DetView.xaml"
            this.cbsort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbsorting);
            
            #line default
            #line hidden
            return;
            case 4:
            this.newdetail = ((System.Windows.Controls.RadioButton)(target));
            
            #line 51 "..\..\..\pg\DetView.xaml"
            this.newdetail.Click += new System.Windows.RoutedEventHandler(this.newdetail_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.zerg = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.f4 = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

