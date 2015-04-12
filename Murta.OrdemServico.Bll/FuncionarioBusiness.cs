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
    public class FuncionarioBusiness
    {
        IFuncionarioRepository funcionarioRepository = null;

        public FuncionarioBusiness(DbConnection db)
        {
            if (db == null)
                throw new InvalidDatabaseInstanceException();

            this.funcionarioRepository = new FuncionarioRepository(db);
        }

        public List<Funcionario> Listar()
        {
            return this.funcionarioRepository.Listar();
        }
    }
}
