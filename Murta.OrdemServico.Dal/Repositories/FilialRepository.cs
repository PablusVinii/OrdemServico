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
    public class FilialRepository:IFilialRepository
    {
        protected Repository repository = null;

        public FilialRepository(DbConnection db)
        {
            this.repository = new Repository(db);
        }

        public List<Filial> Listar()
        {
            var resultado = this.repository.Query<Filial>(Databaseoperation.Select);
            return resultado.Mapper<Filial>().ToList();
        }

        public Filial Consultar(string id)
        {
            var resultado = this.repository.Query<Filial>(Databaseoperation.Select, (List<string> nomesParametros) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
            return resultado.Mapper<Filial>().FirstOrDefault();
        }

        public void Cadastrar(Filial objeto)
        {
            this.repository.Execute<Filial>(Databaseoperation.Insert, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
        }

        public void Editar(Filial objeto)
        {
            this.repository.Execute<Filial>(Databaseoperation.Update, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
        }

        public void Excluir(Filial objeto)
        {
            this.repository.Execute<Filial>(Databaseoperation.Delete, (List<string> nomesParametro) =>
            {
                // TODO Preencher parâmetros desta query
                throw new NotImplementedException();
            });
        }
    }
}
