﻿#pragma checksum "C:\Users\JulioCésar\Desktop\Projetos\OrdemServico\OrdemServicoWP8Client\Modulos\OrdemServico\PivotOrdemServico.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E105F333114E5837B974D5AA64E7E84F"
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
    
    
    public partial class PivotOrdemServico : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal OrdemServicoWP8Client.Modulos.OrdemServico.Partial.PartialForm myPartialForm;
        
        internal System.Windows.Controls.Grid SearchGrid;
        
        internal System.Windows.Controls.Grid ContentPanelSearch;
        
        internal Microsoft.Phone.Controls.DatePicker txtDataDe;
        
        internal Microsoft.Phone.Controls.DatePicker txtDataAte;
        
        internal Microsoft.Phone.Controls.AutoCompleteBox txtClientes;
        
        internal Microsoft.Phone.Controls.AutoCompleteBox txtFuncionarios;
        
        internal System.Windows.Controls.Button btnPesquisar;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/OrdemServicoWP8Client;component/Modulos/OrdemServico/PivotOrdemServico.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.myPartialForm = ((OrdemServicoWP8Client.Modulos.OrdemServico.Partial.PartialForm)(this.FindName("myPartialForm")));
            this.SearchGrid = ((System.Windows.Controls.Grid)(this.FindName("SearchGrid")));
            this.ContentPanelSearch = ((System.Windows.Controls.Grid)(this.FindName("ContentPanelSearch")));
            this.txtDataDe = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("txtDataDe")));
            this.txtDataAte = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("txtDataAte")));
            this.txtClientes = ((Microsoft.Phone.Controls.AutoCompleteBox)(this.FindName("txtClientes")));
            this.txtFuncionarios = ((Microsoft.Phone.Controls.AutoCompleteBox)(this.FindName("txtFuncionarios")));
            this.btnPesquisar = ((System.Windows.Controls.Button)(this.FindName("btnPesquisar")));
        }
    }
}

