using Murta.QueryFactory.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.Dto
{
    [Table(NameTable="FUNCIONARIOS")]
    public class Funcionario
    {
        [Column(NameColumn="CODIGO")]
        public int Codigo { get; set; }

        [Column(NameColumn="NOME")]
        public string Nome { get; set; }
    }
}
