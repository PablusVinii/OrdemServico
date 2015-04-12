using Murta.QueryFactory.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Dto
{
    [Table(NameTable="SYS_COMPANY")]
    public class Empresa
    {
        [Column(NameColumn = "EMPRESA", IsForeignKey = true, ForeignKeyName = "EMPRESA", IsUsedInsertOrUpdateOperation = true)]
        public string Codigo { get; set; }

        [Column(NameColumn="NOME")]
        public string Nome { get; set; }
    }
}
