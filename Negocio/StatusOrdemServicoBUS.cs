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
    // ********************************************************************* 
    //
    // TRS Sistemas - Runtime Library Functions }
    //
    // Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
    //
    // Author: Júlio César Souza Murta
    // Data: 06/06/2014
    // ********************************************************************* 
    // Entidade StatusOS 
    //
    // ********************************************************************* 
    // Data última alteração: 
    // Últimas alterações: 
    //
    // ********************************************************************* 

    public class StatusOrdemServicoBUS:IStatusOrdemServicoNegocio
    {
        FbConnection _conexao = null;
        Empresa _empresa = null;
        Filial _filial = null;

        public StatusOrdemServicoBUS(FbConnection conn, Empresa emp, Filial fil)
        {
            this._conexao = conn;
            this._empresa = emp;
            this._filial = fil;
        }

        public void Cadastrar(StatusOS obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(StatusOS obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(StatusOS obj)
        {
            throw new NotImplementedException();
        }

        public List<StatusOS> Listar()
        {
            ISituacaoOrdemServicoRepositorio umStatusOrdemServicoDao = new StatusOrdemServicoDAO(this._conexao);
            return umStatusOrdemServicoDao.Listar(this._empresa.Codigo, this._filial.Codigo);
        }

        public List<StatusOS> Pesquisar(int id)
        {
            throw new NotImplementedException();
        }

        public StatusOS Consultar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
