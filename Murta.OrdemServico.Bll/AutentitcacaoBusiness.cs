using Murta.Dto;
using Murta.OrdemServico.Dal.Interfaces;
using Murta.OrdemServico.Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Bll
{
    public class AutentitcacaoBusiness
    {
        protected IAutenticacaoRepository autenticacaoRepository = null;

        public AutentitcacaoBusiness(DbConnection db)
        {
            this.autenticacaoRepository = new AutenticacaoRepository(db);
        }

        public Usuario Login(string usuario, string senha)
        {
            return this.autenticacaoRepository.Login(usuario, senha);
        }
    }
}
