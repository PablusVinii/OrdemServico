using Murta.OrdemServico.Dal.Exceptions;
using Murta.QueryFactory;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Dal.Repositories
{
    public class Repository
    {
        protected DbConnection connection = null;

        public delegate IDictionary<string,object> SetParameters(List<string> parametersName);        

        public Repository(DbConnection db)
        {
            if (db == null)
                throw new InvalidDatabaseInstanceException();

            this.connection = db;
        }

        public void Execute<TModel>(Databaseoperation operation, SetParameters callback = null)
        {
            var nomeParametros = new List<string>();
            var query = Factory.GetQuery<TModel>(operation, ref nomeParametros);

            if (callback != null)
            {
                IDictionary<string, object> parametros = callback(nomeParametros);
                this.connection.Execute(query, parametros);
            }
            else
            {
                this.connection.Execute(query);
            }
        }

        public IEnumerable<dynamic> Query<TModel>(Databaseoperation operation, SetParameters callback = null)
        {
            var parametersName = new List<string>();
            var query = string.Empty;

            if (operation == Databaseoperation.Select)
                query = Factory.GetQuery<TModel>(operation);
            else
                query = Factory.GetQuery<TModel>(operation, ref parametersName);

            IDictionary<string, object> parameters = new Dictionary<string, object>();

            if (callback != null)
                parameters = callback(parametersName);

            IEnumerable<dynamic> resultado = null;

            if (parameters.Count == 0)
                resultado = this.connection.Query(query);
            else
                resultado = this.connection.Query(query, parameters);

            return resultado;
        }
    }
}
