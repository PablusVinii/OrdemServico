using AcessaDados;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;


// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 20/05/2014
// ********************************************************************* 
// Entidade Cliente
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Negocio
{
    public class ClienteBUS:INegocio<Cliente, int>
    {
        FbConnection _conexao = null;
        Empresa _empresa = null;
        Filial _filial = null;

        public ClienteBUS(FbConnection conn, Empresa emp, Filial fil)
        {
            this._conexao = conn;
            this._empresa = emp;
            this._filial = fil;
        }

        public void Cadastrar(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> Listar()
        {
            IRepositorio<Cliente, int> umClienteDAO = new ClienteDAO(this._conexao);
            return umClienteDAO.Listar(this._empresa.Codigo, this._filial.Codigo);
        }

        public List<Cliente> Pesquisar(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente Consultar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
