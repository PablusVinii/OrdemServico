using Murta.QueryFactory.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.Dto
{
    [Table(NameTable="TIPOHORAS")]
    public class TipoHora
    {
        [Column(NameColumn="CODIGO")]
        public int Codigo { get; set; }

        [Column(NameColumn = "DESCRICAO")]
        public string Descricao { get; set; }
    }
}
