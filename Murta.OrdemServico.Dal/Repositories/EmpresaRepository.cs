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
    public class EmpresaRepository : IEmpresaRepository
    {
        protected Repository repository = null;

        public EmpresaRepository(DbConnection db)
        {
            this.repository = new Repository(db);
        }

        public List<Empresa> Listar()
        {
            var resultado = this.repository.Query<Empresa>(Databaseoperation.Select);
            return resultado.Mapper<Empresa>().ToList();
        }

        public Empresa Consultar(string id)
        {
            var resultado = this.repository.Query<Empresa>(Databaseoperation.Filter, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });

            return resultado.Mapper<Empresa>().FirstOrDefault();
        }

        public void Cadastrar(Empresa objeto)
        {
            this.repository.Execute<Empresa>(Databaseoperation.Insert, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
        }

        public void Editar(Empresa objeto)
        {
            this.repository.Execute<Empresa>(Databaseoperation.Update, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
        }

        public void Excluir(Empresa objeto)
        {
            this.repository.Execute<Empresa>(Databaseoperation.Delete, (List<string> nomesParametro) => {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
        }
    }
}
