﻿#pragma checksum "..\..\..\Dimenzije.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "12B04B13584C663318DF85395622541D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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
using WPFMatrice.Valid;


namespace WPFMatrice {
    
    
    /// <summary>
    /// Dimenzije
    /// </summary>
    public partial class Dimenzije : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Dimenzije.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Dimenzije.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbVrste;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Dimenzije.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbKolone;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Dimenzije.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Dimenzije.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ok;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Dimenzije.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Nazad;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFMatrice;component/dimenzije.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Dimenzije.xaml"
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
            
            #line 5 "..\..\..\Dimenzije.xaml"
            ((WPFMatrice.Dimenzije)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.tbVrste = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\Dimenzije.xaml"
            this.tbVrste.LostFocus += new System.Windows.RoutedEventHandler(this.tbVrste_LostFocus);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\Dimenzije.xaml"
            this.tbVrste.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tbVrste_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\Dimenzije.xaml"
            this.tbVrste.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.tbVrste_Pasting));
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbKolone = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\Dimenzije.xaml"
            this.tbKolone.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.tbKolone_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\Dimenzije.xaml"
            this.tbKolone.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tbKolone_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 31 "..\..\..\Dimenzije.xaml"
            this.tbKolone.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.tbKolone_Pasting));
            
            #line default
            #line hidden
            
            #line 31 "..\..\..\Dimenzije.xaml"
            this.tbKolone.LostFocus += new System.Windows.RoutedEventHandler(this.tbKolone_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.Ok = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Dimenzije.xaml"
            this.Ok.Click += new System.Windows.RoutedEventHandler(this.Ok_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Nazad = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Dimenzije.xaml"
            this.Nazad.Click += new System.Windows.RoutedEventHandler(this.Nazad_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

