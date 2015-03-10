using Murta.Dto;
using Murta.OrdemServico.Dal.Exceptions;
using Murta.OrdemServico.Dal.Interfaces;
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
    public class OrdemServicoRepository : IOrdemServicoRepository
    {
        protected Repository repository = null;

        public OrdemServicoRepository(DbConnection db)
        {
            this.repository = new Repository(db);
        }

        public List<Dto.OrdemServico> Listar()
        {
            var resultado = this.repository.Query<Dto.OrdemServico>(Databaseoperation.Select);
            return resultado.Mapper<Dto.OrdemServico>().ToList();
        }

        public Dto.OrdemServico Consultar(int id)
        {
            var resultado = this.repository.Query<Dto.OrdemServico>(Databaseoperation.Filter, (List<string> nomesParametros) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
            return resultado.Mapper<Dto.OrdemServico>().FirstOrDefault();
        }

        public void Cadastrar(Dto.OrdemServico objeto)
        {
            this.repository.Execute<Dto.OrdemServico>(Databaseoperation.Insert, (List<string> nomesParametro) =>
                {
                    // TODO Preencher parâmetros desta query
                    throw new NotImplementedException();
                });
        }

        public void Editar(Dto.OrdemServico objeto)
        {
            this.repository.Execute<Dto.OrdemServico>(Databaseoperation.Update, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
        }

        public void Excluir(Dto.OrdemServico objeto)
        {
            this.repository.Execute<Dto.OrdemServico>(Databaseoperation.Delete, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
        }
    }
}
