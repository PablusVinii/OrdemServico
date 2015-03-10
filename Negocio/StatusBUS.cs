using AcessaDados;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;

namespace Negocio
{
    public class StatusBUS:IStatusNegocio
    {
        FbConnection _conexao = null;
        Empresa _empresa = null;
        Filial _filial = null;

        public StatusBUS(FbConnection conn, Empresa emp, Filial fil)
        {
            this._conexao = conn;
            this._empresa = emp;
            this._filial = fil;
        }

        public void Cadastrar(Status obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(Status obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Status obj)
        {
            throw new NotImplementedException();
        }

        public List<Status> Listar()
        {
            IStatusRepositorio umStatusRepositorio = new StatusDAO(this._conexao);
            return umStatusRepositorio.Listar(this._empresa.Codigo, this._filial.Codigo);
        }

        public List<Status> Pesquisar(int id)
        {
            throw new NotImplementedException();
        }

        public Status Consultar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
