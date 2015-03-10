using OrdemServicoWP8Client.Classes.Exceptions;
using OrdemServicoWP8Client.Classes.ObjectDomain;
using OrdemServicoWP8Client.Classes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServicoWP8Client.Classes.Repository
{
    public class AutenticacaoRepository:IAutenticacaoRepository
    {        
        protected bool usuarioAutenticado = false;

        public AutenticacaoRepository()
        {

        }

        public Usuario Login(string username, string senha)
        {
            throw new NotImplementedException();
        }

        public void SalvarSenha(bool salvar)
        {
            if (!this.usuarioAutenticado)
                throw new Exception("Não há nenhum usuário autenticado para salvar senha");

            if (salvar)
            {
                // TODO Lembrar Senha
            }
        }

        public void Logoff()
        {
            throw new NotImplementedException();
        }
    }
}
