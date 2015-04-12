using Murta.OrdemServico.UI.Web.WebForms.SistemaServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Murta.OrdemServico.UI.Web.WebForms.OrdemServico
{
    public partial class Editar : System.Web.UI.Page
    {
        SistemaClient client = new SistemaClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    int id;
                    if (Int32.TryParse(Request.QueryString["Id"], out id))
                    {
                        this.Formulario1.OrdemServico = this.client.ConsultarOrdemServico(id);
                        this.Formulario1.Service = this.client;
                    }
                    else
                    {
                        Response.Redirect("");//Voltar
                    }
                }
            }
        }
    }
}