using Murta.QueryFactory.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Dto
{
    [Table(NameTable="PROJETOS")]
    public class Projeto
    {
        [Column(NameColumn = "CODIGO", IsForeignKey = true, ForeignKeyName = "PROJETO", IsUsedInsertOrUpdateOperation = true)]
        public int Codigo { get; set; }

        [Column(NameColumn="DESCRICAO")]
        public string Descricao { get; set; }
    }
}
