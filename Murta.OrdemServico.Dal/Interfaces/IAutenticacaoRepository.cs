using Murta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Dal.Interfaces
{
    public interface IAutenticacaoRepository
    {
        Usuario Login(string usuario, string senha);        
    }
}
