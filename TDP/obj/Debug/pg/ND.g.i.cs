﻿#pragma checksum "..\..\..\pg\ND.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F68F0E7D444E70446CACBFA80816CBBC40AB870479C50E176957049204C62B45"
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
    /// ND
    /// </summary>
    public partial class ND : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\..\pg\ND.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBDN;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\pg\ND.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBDS;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\pg\ND.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TCount;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\pg\ND.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TMass;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\pg\ND.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Badd;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\pg\ND.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LMessage;
        
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
            System.Uri resourceLocater = new System.Uri("/TDP;component/pg/nd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pg\ND.xaml"
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
            this.CBDN = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.CBDS = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.TCount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TMass = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Badd = ((System.Windows.Controls.Button)(target));
            
            #line 119 "..\..\..\pg\ND.xaml"
            this.Badd.Click += new System.Windows.RoutedEventHandler(this.Badd_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LMessage = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

