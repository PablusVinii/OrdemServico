using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Dto = OrdemServicoWP8Client.Classes.ObjectDomain;

namespace OrdemServicoWP8Client.Modulos.OrdemServico.Partial
{
    public partial class PartialDetails : UserControl
    {
        private Dto.OrdemServico ordemservico;

        public Dto.OrdemServico OrdemServico
        {
            get 
            { 
                return ordemservico; 
            }
            set 
            { 
                ordemservico = value;
                LoadDetails();               
            }
        }

        public PartialDetails()
        {
            InitializeComponent();
        }    

        protected void LoadDetails()
        {
            tbActivity.Text = this.ordemservico.Atividades;
            tbAdditionalInformation.Text = this.ordemservico.Observacao;
            tbBegin.Text = this.ordemservico.Inicio;
            tbBilled.Text = this.ordemservico.Faturado.ToString();
            tbCustomer.Text = this.ordemservico.Cliente.NomeReduzido;
            tbDate.Text = this.ordemservico.Data.ToString("dd/MM/yyyy");
            tbEnd.Text = this.ordemservico.Fim;
            tbHourType.Text = this.ordemservico.TipoHora.Descricao;
            tbProject.Text = this.ordemservico.Projeto.Descricao;
            tbRemote.Text = this.ordemservico.Remoto.ToString();
            tbShuttle.Text = this.ordemservico.Traslado;
            tbSituacao.Text = this.ordemservico.Situacao.ToString();
        }                          
    }
}
