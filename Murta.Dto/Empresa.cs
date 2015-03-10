using Murta.QueryFactory.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.Dto
{
    [Table(NameTable="SYS_COMPANY")]
    public class Empresa
    {        
        [Column(NameColumn="EMPRESA")]
        public string Codigo { get; set; }

        [Column(NameColumn="NOME")]
        public string Nome { get; set; }
    }
}
