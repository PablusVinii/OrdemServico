using Murta.QueryFactor.Annotations;
using Murta.QueryFactory.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.Dto
{
    [Table(NameTable = "SYS_BRANCH")]
    public class Filial
    {
        private Empresa empresa = new Empresa();

        [Column(NameColumn = "FILIAL")]
        [WhereClause(NameColumn = "FILIAL")]
        public string Codigo { get; set; }

        [Column(NameColumn = "REDUZIDO")]
        public string Reduzido { get; set; }
                        
        [Join(TypeJoin = "INNER JOIN", TableA = "SYS_BRANCH", FieldA = "EMPRESA", TableB = "SYS_COMPANY", FieldB = "EMPRESA")]
        [Column(IsObject = true, Type = typeof(Empresa), NameObjectProperty = "Empresa", NameColumn="EMPRESA")]
        public Empresa Empresa { 
            get 
            {
                return this.empresa;
            }
            set 
            {
                this.empresa = value;
            }
        }
    }
}
