using Murta.OrdemServico.UI.Web.WebForms.SistemaServiceReference;
using Murta.OrdemServico.UI.Web.WebForms.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Murta.OrdemServico.UI.Web.WebForms.OrdemServico
{
    public partial class Index : System.Web.UI.Page
    {
        SistemaClient client = new SistemaClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.FiltrosPesquisa1.Client = this.client;

            if (!IsPostBack)
            {
                PreencherGrid();
            }
        }

        protected void grdOrdensDeServico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdOrdensDeServico.PageIndex = e.NewPageIndex;
            var items = this.client.ListarOrdemServico().ToList();
            if (ViewState["SortExpression"] != null)
            {
                var direcao = (SortDirection)ViewState["SortDirection"];
                var expressao = (string)ViewState["SortExpression"];
                this.OrdenarColecao(direcao, expressao, ref items);
            }
            grdOrdensDeServico.DataSource = items;
            grdOrdensDeServico.DataBind();
        }

        private void PreencherGrid()
        {
            List<OS> ordensServico = new List<OS>();

            if (!this.FiltrosPesquisa1.De.HasValue && !this.FiltrosPesquisa1.Ate.HasValue && this.FiltrosPesquisa1.Funcionario == null && this.FiltrosPesquisa1.Cliente == null)            
            {
                ordensServico = this.client.ListarOrdemServico().ToList();
            }
            else if (this.FiltrosPesquisa1.De.HasValue && this.FiltrosPesquisa1.Ate.HasValue && this.FiltrosPesquisa1.Funcionario != null && this.FiltrosPesquisa1.Cliente != null)
            {
                ordensServico = this.client.ListarPorRangedeDataeFuncionarioeClienteOrdemServico(this.FiltrosPesquisa1.De.Value, this.FiltrosPesquisa1.Ate.Value,
                    this.FiltrosPesquisa1.Cliente, this.FiltrosPesquisa1.Funcionario).ToList();
            }

            this.OrdenarColecao(SortDirection.Descending, "Data", ref ordensServico);
            grdOrdensDeServico.DataSource = ordensServico;
            grdOrdensDeServico.DataBind();
        }

        protected void grdOrdensDeServico_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var indexData = GridViewUtils.PegarIndexPorHeader(grdOrdensDeServico, "Data");
                var indexInicio = GridViewUtils.PegarIndexPorHeader(grdOrdensDeServico, "Início");
                var indexFim = GridViewUtils.PegarIndexPorHeader(grdOrdensDeServico, "Fim");
                var indexTraslado = GridViewUtils.PegarIndexPorHeader(grdOrdensDeServico, "Traslado");

                var data = Convert.ToDateTime(e.Row.Cells[indexData].Text);
                e.Row.Cells[indexData].Text = data.ToString("dd/MM/yyyy");

                var inicio = e.Row.Cells[indexInicio].Text;
                e.Row.Cells[indexInicio].Text = inicio.Insert(2, ":");

                var fim = e.Row.Cells[indexFim].Text;
                e.Row.Cells[indexFim].Text = fim.Insert(2, ":");

                var traslado = e.Row.Cells[indexTraslado].Text;

                if (traslado != "0")
                {
                    e.Row.Cells[indexTraslado].Text = traslado.Insert(2, ":");
                }
            }
        }

        protected void grdOrdensDeServico_Sorting(object sender, GridViewSortEventArgs e)
        {
            var direcao = PegarDirecaoOrdenacao(e.SortDirection);
            var expressao = e.SortExpression;
            var items = this.client.ListarOrdemServico().ToList();
            ViewState["SortExpression"] = expressao;
            this.OrdenarColecao(direcao, expressao, ref items);
            grdOrdensDeServico.DataSource = items;
            grdOrdensDeServico.DataBind();
        }

        private SortDirection PegarDirecaoOrdenacao(SortDirection direcao)
        {

            if (ViewState["SortDirection"] != null)
            {
                direcao = (SortDirection)ViewState["SortDirection"];
                if (direcao == SortDirection.Ascending)
                {
                    direcao = SortDirection.Descending;
                }
                else
                {
                    direcao = SortDirection.Ascending;
                }
            }
            ViewState["SortDirection"] = direcao;
            return direcao;
        }

        private List<OS> OrdenarColecao(SortDirection direcao, string expressao, ref List<OS> items)
        {

            if (direcao == SortDirection.Ascending)
            {
                switch (expressao)
                {
                    case "Codigo":
                        items = (from os in items orderby os.Codigo ascending select os).ToList();
                        break;
                    case "Cliente.Nome":
                        items = (from os in items orderby os.Cliente.Nome ascending select os).ToList();
                        break;
                    case "Funcionario.Codigo":
                        items = (from os in items orderby os.Funcionario.Codigo ascending select os).ToList();
                        break;
                    case "Data":
                        items = (from os in items orderby os.Data ascending select os).ToList();
                        break;
                    case "Inicio":
                        items = (from os in items orderby os.Inicio ascending select os).ToList();
                        break;
                    case "Fim":
                        items = (from os in items orderby os.Fim ascending select os).ToList();
                        break;
                    case "Traslado":
                        items = (from os in items orderby os.Traslado ascending select os).ToList();
                        break;
                    case "Status.Descricao":
                        items = (from os in items orderby os.Status.Descricao ascending select os).ToList();
                        break;
                }
            }
            else
            {
                switch (expressao)
                {
                    case "Codigo":
                        items = (from os in items orderby os.Codigo descending select os).ToList();
                        break;
                    case "Cliente.Nome":
                        items = (from os in items orderby os.Cliente.Nome descending select os).ToList();
                        break;
                    case "Funcionario.Codigo":
                        items = (from os in items orderby os.Funcionario.Codigo descending select os).ToList();
                        break;
                    case "Data":
                        items = (from os in items orderby os.Data descending select os).ToList();
                        break;
                    case "Inicio":
                        items = (from os in items orderby os.Inicio descending select os).ToList();
                        break;
                    case "Fim":
                        items = (from os in items orderby os.Fim descending select os).ToList();
                        break;
                    case "Traslado":
                        items = (from os in items orderby os.Traslado descending select os).ToList();
                        break;
                    case "Status.Descricao":
                        items = (from os in items orderby os.Status.Descricao descending select os).ToList();
                        break;
                }
            }
            return items;
        }        

        protected void grdOrdensDeServico_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            pnlExcluirOS.Visible = true;
        }

        protected void btnExcluirOS_Click(object sender, EventArgs e)
        {
            pnlExcluirOS.Visible = false;
        }

        protected void btnCancelarExclusao_Click(object sender, EventArgs e)
        {
            pnlExcluirOS.Visible = false;
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.PreencherGrid();
        }        
    }
}