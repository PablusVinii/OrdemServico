using Murta.QueryFactor.Annotations;
using Murta.QueryFactory.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Dto
{
    [Table(NameTable = "SYS_BRANCH")]
    public class Filial
    {
        private Empresa empresa = new Empresa();

        [Column(NameColumn = "FILIAL", IsForeignKey = true, ForeignKeyName = "FILIAL", IsUsedInsertOrUpdateOperation = true)]
        [WhereClause(NameColumn = "FILIAL")]
        public string Codigo { get; set; }

        [Column(NameColumn = "REDUZIDO")]
        public string Reduzido { get; set; }       
    }
}
