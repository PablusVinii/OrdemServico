﻿using Murta.QueryFactory.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.Dto
{
    [Table(NameTable="CLIENTES")]
    public class Cliente
    {
        [Column(NameColumn="CODIGO", IsSerial=true)]
        [WhereClause(NameColumn = "CODIGO")]
        public int Codigo { get; set; }

        [Column(NameColumn="NOME")]
        public string Nome { get; set; }
    }
}
