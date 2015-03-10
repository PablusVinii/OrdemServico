using AcessaDados;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;
using TransferenciaObjetos.Pessoas;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 14/05/2014
// ********************************************************************* 
// Entidade Funcionario
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Negocio
{
    public class FuncionarioBUS:INegocio<Funcionario, int>
    {
        FbConnection _conexao = null;
        Empresa _empresa = null;
        Filial _filial = null;

        public FuncionarioBUS(FbConnection conn, Empresa empresa, Filial filial)
        {
            this._conexao = conn;
            this._empresa = empresa;
            this._filial = filial;
        }

        public void Cadastrar(Funcionario obj)
        {
            IRepositorio<Funcionario, int> umFuncionarioDAO = new FuncionarioDAO(this._conexao);
            umFuncionarioDAO.Cadastrar(obj);
        }

        public void Editar(Funcionario obj)
        {
            IRepositorio<Funcionario, int> umFucnionarioDAO = new FuncionarioDAO(this._conexao);
            umFucnionarioDAO.Editar(obj);
        }

        public void Excluir(Funcionario obj)
        {
            IRepositorio<Funcionario, int> umFuncionarioDAO = new FuncionarioDAO(this._conexao);
            umFuncionarioDAO.Excluir(obj);
        }

        public List<Funcionario> Listar()
        {
            IRepositorio<Funcionario, int> umFuncionarioDAO = new FuncionarioDAO(this._conexao);
            return umFuncionarioDAO.Listar(this._empresa.Codigo, this._filial.Codigo);
        }

        public List<Funcionario> Pesquisar(int id)
        {
            IRepositorio<Funcionario, int> umFunconarioDAO = new FuncionarioDAO(this._conexao);
            return umFunconarioDAO.Pesquisar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        public Funcionario Consultar(int id)
        {
            IRepositorio<Funcionario, int> umFucnionarioDAO = new FuncionarioDAO(this._conexao);
            return umFucnionarioDAO.Consultar(this._empresa.Codigo, this._filial.Codigo, id);
        }
    }
}
