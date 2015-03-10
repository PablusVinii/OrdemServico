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
                KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomesParametros[0], id);
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(idParametro);
                return parametros;
            });

            return resultado.Mapper<Filial>().FirstOrDefault();
        }

        public void Cadastrar(Filial objeto)
        {
            this.repository.Execute<Filial>(Databaseoperation.Insert, (List<string> nomesParametro) =>
            {
                KeyValuePair<string, object> empresaParametro = new KeyValuePair<string, object>(nomesParametro[0], objeto.Empresa.Codigo);
                KeyValuePair<string, object> nomeParametro = new KeyValuePair<string, object>(nomesParametro[1], objeto.Reduzido);
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(empresaParametro);
                parametros.Add(nomeParametro);

                return parametros;
            });
        }

        public void Editar(Filial objeto)
        {
            this.repository.Execute<Filial>(Databaseoperation.Update, (List<string> nomesParametro) =>
            {
                KeyValuePair<string, object> upIdParametro = new KeyValuePair<string, object>(nomesParametro[0], objeto.Codigo);
                KeyValuePair<string, object> upNomeParametro = new KeyValuePair<string, object>(nomesParametro[1], objeto.Reduzido);
                KeyValuePair<string, object> upEmpresaParametro = new KeyValuePair<string, object>(nomesParametro[2], objeto.Empresa.Codigo);
                KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomesParametro[3], objeto.Codigo);

                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(upIdParametro);
                parametros.Add(upNomeParametro);
                parametros.Add(upEmpresaParametro);
                parametros.Add(idParametro);

                return parametros;
            });
        }

        public void Excluir(Filial objeto)
        {
            this.repository.Execute<Filial>(Databaseoperation.Delete, (List<string> nomesParametro) =>
            {
                KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomesParametro[0], objeto.Codigo);
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(idParametro);
                return parametros;
            });
        }
    }
}
