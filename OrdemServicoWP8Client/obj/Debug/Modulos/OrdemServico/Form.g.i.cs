﻿#pragma checksum "C:\Users\JulioCésar\Desktop\Projetos\OrdemServicoWP8Client\OrdemServicoWP8Client\Modulos\OrdemServico\Form.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D6BBFAD5FB39BA8690C1842955293CA8"
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
    
    
    public partial class Form : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock txtContext;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.CheckBox chkRemoto;
        
        internal System.Windows.Controls.CheckBox chkfaturado;
        
        internal Microsoft.Phone.Controls.AutoCompleteBox txtSituacao;
        
        internal Microsoft.Phone.Controls.AutoCompleteBox txtCliente;
        
        internal Microsoft.Phone.Controls.AutoCompleteBox txtProjeto;
        
        internal Microsoft.Phone.Controls.AutoCompleteBox txtTipoHora;
        
        internal Microsoft.Phone.Controls.DatePicker txtData;
        
        internal System.Windows.Controls.TextBox txtInicio;
        
        internal System.Windows.Controls.TextBox txtFim;
        
        internal System.Windows.Controls.TextBox txtTraslado;
        
        internal System.Windows.Controls.TextBox txtAtividade;
        
        internal System.Windows.Controls.TextBox txtObservacao;
        
        internal System.Windows.Controls.Button btnEnviar;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/OrdemServicoWP8Client;component/Modulos/OrdemServico/Form.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.txtContext = ((System.Windows.Controls.TextBlock)(this.FindName("txtContext")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.chkRemoto = ((System.Windows.Controls.CheckBox)(this.FindName("chkRemoto")));
            this.chkfaturado = ((System.Windows.Controls.CheckBox)(this.FindName("chkfaturado")));
            this.txtSituacao = ((Microsoft.Phone.Controls.AutoCompleteBox)(this.FindName("txtSituacao")));
            this.txtCliente = ((Microsoft.Phone.Controls.AutoCompleteBox)(this.FindName("txtCliente")));
            this.txtProjeto = ((Microsoft.Phone.Controls.AutoCompleteBox)(this.FindName("txtProjeto")));
            this.txtTipoHora = ((Microsoft.Phone.Controls.AutoCompleteBox)(this.FindName("txtTipoHora")));
            this.txtData = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("txtData")));
            this.txtInicio = ((System.Windows.Controls.TextBox)(this.FindName("txtInicio")));
            this.txtFim = ((System.Windows.Controls.TextBox)(this.FindName("txtFim")));
            this.txtTraslado = ((System.Windows.Controls.TextBox)(this.FindName("txtTraslado")));
            this.txtAtividade = ((System.Windows.Controls.TextBox)(this.FindName("txtAtividade")));
            this.txtObservacao = ((System.Windows.Controls.TextBox)(this.FindName("txtObservacao")));
            this.btnEnviar = ((System.Windows.Controls.Button)(this.FindName("btnEnviar")));
        }
    }
}

