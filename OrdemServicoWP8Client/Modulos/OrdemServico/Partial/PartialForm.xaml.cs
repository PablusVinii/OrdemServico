using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OrdemServicoWP8Client.Classes.Enums;
using OrdemServicoWP8Client.Classes.Repository.Interface;
using Dto = OrdemServicoWP8Client.Classes.ObjectDomain;

namespace OrdemServicoWP8Client.Modulos.OrdemServico.Partial
{
    public partial class PartialForm : UserControl
    {
        protected IOrdemServicoRepository ordemServicoRepository = null;

        public ScenarioForm Scenario { get; set; }

        public PartialForm()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            Dto.OrdemServico ordemServico = this.PegarValoresFormulario();

            if (this.Scenario == ScenarioForm.Create)
            {
                this.ordemServicoRepository.Cadastrar(ordemServico);
            }
            else if (this.Scenario == ScenarioForm.Update)
            {
                this.ordemServicoRepository.Editar(ordemServico);
            }
        }

        private Dto.OrdemServico PegarValoresFormulario()
        {
            Dto.OrdemServico ordemServico = new Dto.OrdemServico();
            ordemServico.Atividades = txtAtividade.Text.Trim();
            ordemServico.Cliente = new Dto.Cliente();
            ordemServico.Cliente.Id = Convert.ToInt32(txtCliente.Text.Trim());
            ordemServico.Data = txtData.Value ?? DateTime.Now;
            ordemServico.Faturado = chkfaturado.IsChecked ?? false;
            ordemServico.Remoto = chkRemoto.IsChecked ?? false;
            ordemServico.Inicio = txtInicio.Text.Trim();
            ordemServico.Fim = txtFim.Text.Trim();
            ordemServico.Traslado = txtTraslado.Text.Trim();
            ordemServico.Funcionario = new Dto.Funcionario();
            ordemServico.Funcionario.Id = 0;
            ordemServico.Observacao = txtObservacao.Text;
            ordemServico.Projeto = new Dto.Projeto();
            ordemServico.Projeto.Id = Convert.ToInt32(txtProjeto.Text);
            ordemServico.TipoHora = new Dto.TipoHora();
            ordemServico.TipoHora.Id = Convert.ToInt32(txtTipoHora.Text);

            return ordemServico;
        }
    }
}
