using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServicoWP8Client.Classes.ObjectDomain
{    
    public class Usuario
    {        
        public int Id { get; set; }
        
        public string Nome { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
       
        public DateTime DataLogin { get; set; }
    }
}
