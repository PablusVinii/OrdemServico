using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Murta.OrdemServico.UI.Web.WebForms.SistemaServiceReference;
using Murta.OrdemServico.UI.Web.WebForms.Utils;

namespace Murta.OrdemServico.UI.Web.WebForms.OrdemServico.UserControls
{
    public partial class FiltrosPesquisa : System.Web.UI.UserControl
    {
        public SistemaClient Client { protected get; set; }

        public DateTime? De
        {
            get
            {
                DateTime dataDe = new DateTime();

                if (DateTime.TryParse(txtDataDe.Text, out dataDe))
                {
                    return dataDe;
                }

                return null;
            }
        }

        public DateTime? Ate
        {
            get
            {
                DateTime dataAte = new DateTime();

                if (DateTime.TryParse(txtDataAte.Text, out dataAte))
                {
                    return dataAte;
                }

                return null;
            }
        }

        public Funcionario Funcionario
        {
            get
            {
                if (!string.IsNullOrEmpty(drpFuncionarios.SelectedValue))
                {
                    return new Funcionario
                    {
                        Codigo = Convert.ToInt32(drpFuncionarios.SelectedValue)
                    };
                }

                return null;
            }
        }

        public Cliente Cliente
        {
            get
            {
                if (!string.IsNullOrEmpty(drpClientes.SelectedValue))
                {
                    return new Cliente 
                    { 
                        Codigo = Convert.ToInt32(drpClientes.SelectedValue)
                    };
                }

                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var clientes = this.Client.ListarClientes().ToList();
                DropDownListUtils.PreencherDropDown<Cliente>("Codigo", "Nome", clientes, ref drpClientes);

                var funcionarios = this.Client.ListarFuncionarios().ToList();
                DropDownListUtils.PreencherDropDown<Funcionario>("Codigo", "Nome", funcionarios, ref drpFuncionarios);
            }
        }
    }
}