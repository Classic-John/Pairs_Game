﻿#pragma checksum "..\..\theGame.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B3CD9D6255109472C2B798AA69F2FE05B138690D6C86955C07741F2A6DDABB04"
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
using Tema1;


namespace Tema1 {
    
    
    /// <summary>
    /// theGame
    /// </summary>
    public partial class theGame : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\theGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button New_Game;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\theGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Open_Game;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\theGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save_Game;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\theGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Statistics;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\theGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\theGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button About;
        
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
            System.Uri resourceLocater = new System.Uri("/Tema1;component/thegame.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\theGame.xaml"
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
            this.New_Game = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\theGame.xaml"
            this.New_Game.Click += new System.Windows.RoutedEventHandler(this.New_Game_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Open_Game = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\theGame.xaml"
            this.Open_Game.Click += new System.Windows.RoutedEventHandler(this.Open_Game_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Save_Game = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\theGame.xaml"
            this.Save_Game.Click += new System.Windows.RoutedEventHandler(this.Save_Game_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Statistics = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\theGame.xaml"
            this.Statistics.Click += new System.Windows.RoutedEventHandler(this.Statistics_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Exit = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\theGame.xaml"
            this.Exit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.About = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\theGame.xaml"
            this.About.Click += new System.Windows.RoutedEventHandler(this.About_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
