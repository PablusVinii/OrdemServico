using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Murta.OrdemServico.UI.Web.WebForms.Utils;
using Murta.OrdemServico.UI.Web.WebForms.SistemaServiceReference;

namespace Murta.OrdemServico.UI.Web.WebForms.OrdemServico.UserControls
{
    public partial class Formulario : System.Web.UI.UserControl
    {
        public SistemaClient Service { get; set; }

        public OS OrdemServico { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var clientes = this.Service.ListarClientes().ToList();
                var tipoHora = this.Service.ListarTiposHora().ToList();
                var projetos = this.Service.ListarProjetos().ToList();
                var situacoes = this.Service.ListarStatus().ToList();

                DropDownListUtils.PreencherDropDown<Cliente>("Codigo", "Nome", clientes, ref drpCliente);
                DropDownListUtils.PreencherDropDown<TipoHora>("Codigo", "Descricao", tipoHora, ref drpTipoHora);
                DropDownListUtils.PreencherDropDown<Projeto>("Codigo", "Descricao", projetos, ref drpProjeto);
                DropDownListUtils.PreencherDropDown<Status>("Codigo", "Descricao", situacoes, ref drpSituacao);

                this.CarregarOrdemDeServicoNoFormulario();
            }
        }

        private void CarregarOrdemDeServicoNoFormulario()
        {
            if (this.OrdemServico != null)
            {
                drpTipoHora.SelectedValue = this.OrdemServico.TipoHora.Codigo.ToString();
                drpSituacao.SelectedValue = this.OrdemServico.Status.Codigo.ToString();
                drpCliente.SelectedValue = this.OrdemServico.Cliente.Codigo.ToString();
                drpProjeto.SelectedValue = this.OrdemServico.Projeto.Codigo.ToString();
                txtTraslado.Text = this.OrdemServico.Traslado;
                txtData.Text = this.OrdemServico.Data.ToString("dd/MM/yyyy");
                txtFim.Text = this.OrdemServico.Fim;
                txtInicio.Text = this.OrdemServico.Inicio;
                txtAtividade.Text = this.OrdemServico.Atividade;
                txtObservacao.Text = this.OrdemServico.Observacao;
            }
        }
    }
}