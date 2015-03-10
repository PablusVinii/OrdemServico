using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServicoWP8Client.Classes.ObjectDomain
{
    [Table]
    public class TipoHora
    {
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(CanBeNull = false)] 
        public string Descricao { get; set; }
    }
}
