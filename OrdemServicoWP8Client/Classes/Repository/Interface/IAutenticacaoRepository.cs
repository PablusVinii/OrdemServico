using OrdemServicoWP8Client.Classes.ObjectDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServicoWP8Client.Classes.Repository.Interface
{
    public interface IAutenticacaoRepository
    {
        Usuario Login(string username, string senha);
        void SalvarSenha(bool salvar);
        void Logoff();
    }
}
