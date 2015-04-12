using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Murta.OrdemServico.UI.Web.WebForms.Utils
{
    public class GridViewUtils
    {
        public static int PegarIndexPorHeader(GridView grid, string nome)
        {
            foreach (DataControlField coluna in grid.Columns)
            {
                if (coluna.HeaderText == nome)
                {
                    return grid.Columns.IndexOf(coluna);
                }
            }
            return -1;
        }        
    }
}
