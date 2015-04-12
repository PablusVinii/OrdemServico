using Murta.OrdemServico.UI.Web.WebForms.SistemaServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Murta.OrdemServico.UI.Web.WebForms.OrdemServico
{
    public partial class Cadastrar : System.Web.UI.Page
    {
        SistemaClient client = new SistemaClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Formulario1.Service = this.client;
            }
        }
    }
}