using Murta.OrdemServico.Dal.Interfaces;
using Murta.OrdemServico.Dal.Repositories;
using Murta.OrdemServico.Dto;
using Murta.Utils.Dal.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Bll
{
    public class ProjetoBusiness 
    {
        protected IProjetoRepository projetoBusiness = null;

        public ProjetoBusiness(DbConnection db)
        {
            if (db == null)
                throw new InvalidDatabaseInstanceException();

            this.projetoBusiness = new ProjetoRepository(db);
        }

        public List<Projeto> Listar()
        {
            return this.projetoBusiness.Listar();
        }
    }
}
