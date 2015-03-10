using AcessaDados;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransferenciaObjetos;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 28/07/2014
// ********************************************************************* 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Negocio
{
    public class IndicadorBUS:IIndicadorNegocio
    {
        FbConnection _conexao = null;
        Empresa _empresa = null;
        Filial _filial = null;

        public IndicadorBUS(FbConnection conn, Empresa emp, Filial fil)
        {
            this._conexao = conn;
            this._empresa = emp;
            this._filial = fil;
        }

        public void Cadastrar(Indicador obj)
        {
            IIndicadorRepositorio umIndicadorDAO = new IndicadorDAO(this._conexao);
            umIndicadorDAO.Cadastrar(obj);
        }

        public void Editar(Indicador obj)
        {
            IIndicadorRepositorio umIndicadorDAO = new IndicadorDAO(this._conexao);
            umIndicadorDAO.Editar(obj);
        }

        public void Excluir(Indicador obj)
        {
            IIndicadorRepositorio umIndicadorDAO = new IndicadorDAO(this._conexao);
            umIndicadorDAO.Excluir(obj);
        }

        public List<Indicador> Listar()
        {
            IIndicadorRepositorio umIndicadorDAO = new IndicadorDAO(this._conexao);
            return umIndicadorDAO.Listar(this._empresa.Codigo, this._filial.Codigo);
        }

        public List<Indicador> Pesquisar(int id)
        {
            IIndicadorRepositorio umIndicadorDAO = new IndicadorDAO(this._conexao);
            return umIndicadorDAO.Pesquisar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        public Indicador Consultar(int id)
        {
            IIndicadorRepositorio umIndicadorDAO = new IndicadorDAO(this._conexao);
            return umIndicadorDAO.Consultar(this._empresa.Codigo, this._filial.Codigo, id);
        }
    }
}
