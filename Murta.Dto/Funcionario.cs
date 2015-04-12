using Murta.QueryFactory.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Dto
{
    [Table(NameTable="FUNCIONARIOS")]
    public class Funcionario
    {
        [Column(NameColumn = "CODIGO", IsForeignKey = true, ForeignKeyName = "FUNCIONARIO", IsUsedInsertOrUpdateOperation = true)]
        public int Codigo { get; set; }

        [Column(NameColumn="NOME")]
        public string Nome { get; set; }
    }
}
