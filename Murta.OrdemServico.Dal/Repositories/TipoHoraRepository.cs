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
    public class TipoHoraRepository:ITipoHoraRepository
    {
        protected Repository repository = null;

        public TipoHoraRepository(DbConnection db)
        {
            this.repository = new Repository(db);
        }

        public List<TipoHora> Listar()
        {
            var resultado = this.repository.Query<TipoHora>(Databaseoperation.Select);
            return resultado.Mapper<TipoHora>().ToList();
        }

        public TipoHora Consultar(int id)
        {
            var resultado = this.repository.Query<TipoHora>(Databaseoperation.Filter, (List<string> nomesParametro) =>
            {
                KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomesParametro[0], id);
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(idParametro);
                return parametros;
            });

            return resultado.Mapper<TipoHora>().FirstOrDefault();
        }

        public void Cadastrar(TipoHora objeto)
        {
            this.repository.Execute<TipoHora>(Databaseoperation.Insert, (List<string> nomesParametro) =>
            {
                KeyValuePair<string, object> nomeParametro = new KeyValuePair<string, object>(nomesParametro[0], objeto.Descricao);

                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(nomeParametro);

                return parametros;
            });
        }

        public void Editar(TipoHora objeto)
        {
            this.repository.Execute<TipoHora>(Databaseoperation.Update, (List<string> nomesParametro) =>
            {
                KeyValuePair<string, object> upIdParametro = new KeyValuePair<string, object>(nomesParametro[0], objeto.Codigo);
                KeyValuePair<string, object> upNomeParametro = new KeyValuePair<string, object>(nomesParametro[1], objeto.Descricao);
                KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomesParametro[2], objeto.Codigo);

                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(upIdParametro);
                parametros.Add(upNomeParametro);
                parametros.Add(idParametro);

                return parametros;
            });
        }

        public void Excluir(TipoHora objeto)
        {
            this.repository.Execute<TipoHora>(Databaseoperation.Delete, (List<string> nomesParametro) =>
            {
                KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomesParametro[0], objeto.Codigo);
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(idParametro);
                return parametros;
            });
        }
    }
}
