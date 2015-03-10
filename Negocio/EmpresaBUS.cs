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
    public class EmpresaBUS:INegocio<Empresa, string>
    {
        FbConnection _conexao = null;

        public EmpresaBUS( FbConnection conn)
        {
            this._conexao = conn;
        }

        public void Cadastrar(Empresa obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(Empresa obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Empresa obj)
        {
            throw new NotImplementedException();
        }

        public List<Empresa> Listar()
        {
            IRepositorio<Empresa, string> umaEmpresaDAO = new EmpresaDAO(this._conexao);
            return umaEmpresaDAO.Listar("","");
        }

        public List<Empresa> Listar(string empresa)
        {
            IRepositorio<Empresa, string> umaEmpresaDAO = new EmpresaDAO(this._conexao);
            return umaEmpresaDAO.Listar(empresa, "");
        }

        public List<Empresa> Pesquisar(string id)
        {
            throw new NotImplementedException();
        }

        public Empresa Consultar(string id)
        {
            throw new NotImplementedException();
        }
    }
}
