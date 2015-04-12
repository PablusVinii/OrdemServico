using Murta.Utils.Dal.Exceptions;
using Murta.OrdemServico.Dal.Interfaces;
using Murta.QueryFactory;
using Murta.QueryFactory.Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Murta.OrdemServico.Dto;

namespace Murta.OrdemServico.Dal.Repositories
{
    public class FuncionarioRepository:IFuncionarioRepository
    {
        protected Repository repository = null;

        public FuncionarioRepository(DbConnection db)
        {
            this.repository = new Repository(db);
        }

        public List<Funcionario> Listar()
        {
            var resultado = this.repository.Query<Funcionario>(Databaseoperation.Select);
            return resultado.Mapper<Funcionario>().ToList();
        }

        public Funcionario Consultar(int id)
        {
            var resultado = this.repository.Query<Murta.OrdemServico.Dto.OS>(Databaseoperation.Filter, (List<string> nomesParametros) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
            return resultado.Mapper<Funcionario>().FirstOrDefault();
        }

        public void Cadastrar(Funcionario objeto)
        {
            this.repository.Execute<Funcionario>(Databaseoperation.Insert, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
        }

        public void Editar(Funcionario objeto)
        {
            this.repository.Execute<Funcionario>(Databaseoperation.Update, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
        }

        public void Excluir(Funcionario objeto)
        {
            this.repository.Execute<Funcionario>(Databaseoperation.Delete, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
        }
    }
}
