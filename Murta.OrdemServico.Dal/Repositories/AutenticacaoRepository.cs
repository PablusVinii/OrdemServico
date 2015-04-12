using Murta.Dto;
using Murta.OrdemServico.Dal.Interfaces;
using Murta.QueryFactory;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Murta.QueryFactory.Dapper;
using Murta.Apoio;

namespace Murta.OrdemServico.Dal.Repositories
{
    public class AutenticacaoRepository:IAutenticacaoRepository
    {
        protected Repository repository = null;

        public AutenticacaoRepository(DbConnection db)
        {
            this.repository = new Repository(db);
        }

        public Murta.Dto.Usuario Login(string usuario, string senha)
        {
            var resultado = this.repository.Query<Usuario>(Databaseoperation.Filter, (List<string> nomesParametros) =>
            {
                KeyValuePair<string, object> usuarioParametro = new KeyValuePair<string, object>(nomesParametros[0], Criptografia.Criptografar(usuario));
                KeyValuePair<string, object> senhaParametro = new KeyValuePair<string, object>(nomesParametros[1], Criptografia.Criptografar(senha));
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(usuarioParametro);
                parametros.Add(senhaParametro);
                return parametros;
            });
            return resultado.Mapper<Usuario>().FirstOrDefault();
        }
    }
}
