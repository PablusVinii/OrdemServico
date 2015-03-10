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
    public class ClienteRepository:IClienteRepository
    {
        protected Repository repository = null;

        public ClienteRepository(DbConnection db)
        {
            this.repository = new Repository(db);
        }

        public List<Cliente> Listar()
        {
            var resultado = this.repository.Query<Cliente>(Databaseoperation.Select);
            return resultado.Mapper<Cliente>().ToList();
        }

        public Cliente Consultar(int id)
        {
            var resultado = this.repository.Query<Cliente>(Databaseoperation.Filter, (List<string> nomeParametros) =>
                {
                    KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomeParametros[0], id);
                    IDictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add(idParametro);
                    return parametros;
                });
            return resultado.Mapper<Cliente>().FirstOrDefault();
        }

        public void Cadastrar(Cliente objeto)
        {
            this.repository.Execute<Cliente>(Databaseoperation.Insert, (List<string> nomeParametros) =>
                {
                    KeyValuePair<string, object> nomeParametro = new KeyValuePair<string, object>(nomeParametros[0], objeto.Nome);

                    IDictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add(nomeParametro);

                    return parametros;
                });
        }        

        public void Editar(Cliente objeto)
        {
            this.repository.Execute<Cliente>(Databaseoperation.Update, (List<string> nomeParametros) =>
                {
                    KeyValuePair<string, object> upIdParametro = new KeyValuePair<string, object>(nomeParametros[0], objeto.Codigo);
                    KeyValuePair<string, object> upNomeParametro = new KeyValuePair<string, object>(nomeParametros[1], objeto.Nome);
                    KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomeParametros[2], objeto.Codigo);

                    IDictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add(upIdParametro);
                    parametros.Add(upNomeParametro);
                    parametros.Add(idParametro);

                    return parametros;
                });
        }

        public void Excluir(Cliente objeto)
        {
            this.repository.Execute<Cliente>(Databaseoperation.Delete, (List<string> nomeParametros) =>
                {
                    KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomeParametros[0], objeto.Codigo);
                    IDictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add(idParametro);
                    return parametros;
                });
        }
    }
}
