﻿#pragma checksum "C:\Users\JulioCésar\Desktop\Projetos\OrdemServicoWP8Client\OrdemServicoWP8Client\Modulos\OrdemServico\Details.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "800616452ED1767020FE6CEC062EB13A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OrdemServicoWP8Client.Modulos.OrdemServico.Partial;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace OrdemServicoWP8Client.Modulos.OrdemServico {
    
    
    public partial class Details : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal OrdemServicoWP8Client.Modulos.OrdemServico.Partial.PartialDetails myPartialDetails;
        
        internal Microsoft.Phone.Shell.ApplicationBar apButtons;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/OrdemServicoWP8Client;component/Modulos/OrdemServico/Details.xaml", System.UriKind.Relative));
            this.myPartialDetails = ((OrdemServicoWP8Client.Modulos.OrdemServico.Partial.PartialDetails)(this.FindName("myPartialDetails")));
            this.apButtons = ((Microsoft.Phone.Shell.ApplicationBar)(this.FindName("apButtons")));
        }
    }
}

