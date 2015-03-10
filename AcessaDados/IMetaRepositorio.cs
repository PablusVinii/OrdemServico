using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TransferenciaObjetos;

namespace AcessaDados
{
    public interface IMetaRepositorio :IRepositorio<Meta, int>
    {
        List<Meta> Listar(string empresa, string filial, int funcionario);
        List<Meta> Listar(string empresa, string filial, Projeto projeto);
        DataTable GerarRelatorio(string query, IEnumerable<FbParameter> parametros);
        int UltimoId();
    }
}
