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
    public class FuncionarioRepository:IFuncionarioRepository
    {
        protected Repository repository = null;

        public FuncionarioRepository(DbConnection db)
        {
            this.repository = new Repository(db);
        }

        public List<Funcionario> Listar()
        {
            var resultado = this.repository.Query<Murta.Dto.OrdemServico>(Databaseoperation.Select);
            return resultado.Mapper<Funcionario>().ToList();
        }

        public Funcionario Consultar(int id)
        {
            var resultado = this.repository.Query<Murta.Dto.OrdemServico>(Databaseoperation.Filter, (List<string> nomesParametros) =>
            {
                KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomesParametros[0], id);
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(idParametro);
                return parametros;
            });
            return resultado.Mapper<Funcionario>().FirstOrDefault();
        }

        public void Cadastrar(Funcionario objeto)
        {
            this.repository.Execute<Funcionario>(Databaseoperation.Insert, (List<string> nomesParametro) =>
            {
                KeyValuePair<string, object> nomeParametro = new KeyValuePair<string, object>(nomesParametro[0], objeto.Nome);

                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(nomeParametro);

                return parametros;
            });
        }

        public void Editar(Funcionario objeto)
        {
            this.repository.Execute<Funcionario>(Databaseoperation.Update, (List<string> nomesParametro) =>
            {
                KeyValuePair<string, object> upIdParametro = new KeyValuePair<string, object>(nomesParametro[0], objeto.Codigo);
                KeyValuePair<string, object> upNomeParametro = new KeyValuePair<string, object>(nomesParametro[1], objeto.Nome);
                KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomesParametro[2], objeto.Codigo);

                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(upIdParametro);
                parametros.Add(upNomeParametro);
                parametros.Add(idParametro);

                return parametros;
            });
        }

        public void Excluir(Funcionario objeto)
        {
            this.repository.Execute<Funcionario>(Databaseoperation.Delete, (List<string> nomesParametro) =>
            {
                KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomesParametro[0], objeto.Codigo);
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(idParametro);
                return parametros;
            });
        }
    }
}
