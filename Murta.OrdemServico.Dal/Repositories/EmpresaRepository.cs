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
                KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomesParametro[0], id);
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(idParametro);
                return parametros;
            });

            return resultado.Mapper<Empresa>().FirstOrDefault();
        }

        public void Cadastrar(Empresa objeto)
        {
            this.repository.Execute<Empresa>(Databaseoperation.Insert, (List<string> nomesParametro) =>
            {
                KeyValuePair<string, object> nomeParametro = new KeyValuePair<string, object>(nomesParametro[0], objeto.Nome);

                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(nomeParametro);

                return parametros;
            });
        }

        public void Editar(Empresa objeto)
        {
            this.repository.Execute<Empresa>(Databaseoperation.Update, (List<string> nomesParametro) =>
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

        public void Excluir(Empresa objeto)
        {
            this.repository.Execute<Empresa>(Databaseoperation.Delete, (List<string> nomesParametro) =>
            {
                KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomesParametro[0], objeto.Codigo);
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(idParametro);
                return parametros;
            });
        }
    }
}
