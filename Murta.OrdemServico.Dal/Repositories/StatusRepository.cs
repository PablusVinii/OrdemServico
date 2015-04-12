using Murta.OrdemServico.Dal.Interfaces;
using Murta.OrdemServico.Dto;
using Murta.QueryFactory;
using Murta.QueryFactory.Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Dal.Repositories
{
    public class StatusRepository:IStatusRepository
    {
        protected Repository repository = null;

        public StatusRepository(DbConnection db)
        {
            this.repository = new Repository(db);
        }

        public List<Status> Listar()
        {
            var resultado = this.repository.Query<Status>(Databaseoperation.Select);
            return resultado.Mapper<Status>().ToList();
        }

        public Status Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Status objeto)
        {
            throw new NotImplementedException();
        }

        public void Editar(Status objeto)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Status objeto)
        {
            throw new NotImplementedException();
        }
    }
}
