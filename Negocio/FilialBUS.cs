using AcessaDados;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;
using AcessaDados;

namespace Negocio
{
    public class FilialBUS:IFilialNegocio 
    {
        FbConnection _conexao = null;

        public FilialBUS(FbConnection conn)
        {
            this._conexao = conn;
        }

        public void Cadastrar(Filial obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(Filial obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Filial obj)
        {
            throw new NotImplementedException();
        }

        public List<Filial> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Filial> Pesquisar(string id)
        {
            throw new NotImplementedException();
        }

        public Filial Consultar(string id)
        {
            throw new NotImplementedException();
        }

        public List<Filial> Listar(string empresa)
        {
            IRepositorio<Filial, string> umaFilialDAO = new FilialDAO(this._conexao);
            return umaFilialDAO.Listar(empresa,"");
        }
    }
}
