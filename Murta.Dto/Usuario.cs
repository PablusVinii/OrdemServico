using Murta.QueryFactory.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.Dto
{
    [Table(NameTable = "SYS_USERS")]
    public class Usuario
    {
        [Column(NameColumn = "USUARIOWEB")]
        [WhereClause(NameColumn = "USUARIOWEB")]
        public string UserName { get; set; }

        [Column(NameColumn = "SENHAWEB")]
        [WhereClause(NameColumn = "SENHAWEB")]
        public string Password { get; set; }
    }
}
