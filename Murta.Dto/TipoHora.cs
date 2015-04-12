using Murta.QueryFactory.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Dto
{
    [Table(NameTable="TIPOHORAS")]
    public class TipoHora
    {
        [Column(NameColumn = "CODIGO", IsForeignKey = true, ForeignKeyName = "TIPOHORA", IsUsedInsertOrUpdateOperation = true)]
        public int Codigo { get; set; }

        [Column(NameColumn = "DESCRICAO")]
        public string Descricao { get; set; }
    }
}
