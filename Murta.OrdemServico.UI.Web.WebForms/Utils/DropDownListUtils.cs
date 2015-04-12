using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Murta.OrdemServico.UI.Web.WebForms.Utils
{
    public class DropDownListUtils
    {
        public static void PreencherDropDown<T>(string value, string description, List<T> colecao, ref DropDownList dropDownList, bool generateDefaultItem = true)
        {
            if (string.IsNullOrEmpty(value) && string.IsNullOrEmpty(description))
                throw new Exception("Chave e/ou valores inválidos");

            if (colecao == null && colecao.Count < 0)
                throw new Exception("Coleção inválida");

            if (dropDownList == null)
                throw new Exception("DropDownList não pôde ser identificado");          

            dropDownList.DataTextField = description;
            dropDownList.DataValueField = value;
            dropDownList.DataSource = colecao;
            dropDownList.DataBind();

            if (generateDefaultItem)
            {
                var defaultItem = new ListItem("Selecione um item", string.Empty);
                defaultItem.Selected = true;                     
                dropDownList.Items.Insert(0, defaultItem);
            }
        }
    }
}
