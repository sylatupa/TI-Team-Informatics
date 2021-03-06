﻿#pragma checksum "..\..\introduction.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D55960C3574C997D8987FAC57B948342"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
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
using System.Windows.Controls.Ribbon;
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


namespace Working_Memory_Battery_and_Sensor_Input {
    
    
    /// <summary>
    /// Introduction
    /// </summary>
    public partial class Introduction : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\introduction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid cp_introduction;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\introduction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel cp_pregame_intro;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\introduction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_intro_next;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\introduction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_slide1;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\introduction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_slide2;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\introduction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_slide3;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\introduction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_slide4;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\introduction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel cp_pregame_select_user;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\introduction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ddl;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\introduction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_user_next;
        
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
            System.Uri resourceLocater = new System.Uri("/Working_Memory_Battery_and_Sensor_Input;component/introduction.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\introduction.xaml"
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
            this.cp_introduction = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.cp_pregame_intro = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.button_intro_next = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\introduction.xaml"
            this.button_intro_next.Click += new System.Windows.RoutedEventHandler(this.button_click_pre_game_next);
            
            #line default
            #line hidden
            return;
            case 4:
            this.image_slide1 = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.image_slide2 = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.image_slide3 = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.image_slide4 = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.cp_pregame_select_user = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.ddl = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.button_user_next = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\introduction.xaml"
            this.button_user_next.Click += new System.Windows.RoutedEventHandler(this.button_click_user_next);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

