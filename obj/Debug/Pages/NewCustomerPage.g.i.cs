﻿#pragma checksum "..\..\..\Pages\NewCustomerPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4D9F9485DFAE68B987A94E8CC3D97321E60A371ED863A7F5DC41ABEBBC7894D0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using TimeTrackerUI;


namespace TimeTrackerUI {
    
    
    /// <summary>
    /// NewCustomerPage
    /// </summary>
    public partial class NewCustomerPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\..\Pages\NewCustomerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox customerNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\NewCustomerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox customerPhoneNumberTextBox;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Pages\NewCustomerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox customerAddressTextBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Pages\NewCustomerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox customerEmailTextBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Pages\NewCustomerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox customerCvrTextBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Pages\NewCustomerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createCustomerButton;
        
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
            System.Uri resourceLocater = new System.Uri("/TimeTrackerUI;component/pages/newcustomerpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\NewCustomerPage.xaml"
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
            this.customerNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.customerPhoneNumberTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.customerAddressTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.customerEmailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.customerCvrTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.createCustomerButton = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\Pages\NewCustomerPage.xaml"
            this.createCustomerButton.Click += new System.Windows.RoutedEventHandler(this.createCustomerButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

