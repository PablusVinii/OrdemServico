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
    public class ProjetoRepository : IProjetoRepository
    {
        protected Repository repository = null;

        public ProjetoRepository(DbConnection db)
        {
            this.repository = new Repository(db);
        }

        public List<Projeto> Listar()
        {
            var resultado = this.repository.Query<Projeto>(Databaseoperation.Select);
            return resultado.Mapper<Projeto>().ToList();
        }

        public Projeto Consultar(int id)
        {
            var resultado = this.repository.Query<Projeto>(Databaseoperation.Filter, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });

            return resultado.Mapper<Projeto>().FirstOrDefault();
        }

        public void Cadastrar(Projeto objeto)
        {
            this.repository.Execute<Projeto>(Databaseoperation.Insert, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
        }

        public void Editar(Projeto objeto)
        {
            this.repository.Execute<Projeto>(Databaseoperation.Update, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
        }

        public void Excluir(Projeto objeto)
        {
            this.repository.Execute<Projeto>(Databaseoperation.Delete, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
        }
    }
}
