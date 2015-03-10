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
    public class PeriodoBUS:IPeriodoNegocio
    {
        FbConnection _conexao = null;
        Empresa _empresa = null;
        Filial _filial = null;

        public PeriodoBUS(FbConnection conn, Empresa emp, Filial fil)
        {
            this._conexao = conn;
            this._empresa = emp;
            this._filial = fil;
        }

        public void Cadastrar(Periodo obj)
        {
            IPeriodoRepositorio umPeriodoDAO = new PeriodoDAO(this._conexao);
            obj.Empresa = this._empresa;
            obj.Filial = this._filial;
            umPeriodoDAO.Cadastrar(obj);
        }

        public void Editar(Periodo obj)
        {
            IPeriodoRepositorio umPeriodoDAO = new PeriodoDAO(this._conexao);
            umPeriodoDAO.Editar(obj);
        }

        public void Excluir(Periodo obj)
        {
            IPeriodoRepositorio umPeriodoDAO = new PeriodoDAO(this._conexao);
            umPeriodoDAO.Excluir(obj);
        }

        public List<Periodo> Listar()
        {
            IPeriodoRepositorio umPeriodoDAO = new PeriodoDAO(this._conexao);
            return umPeriodoDAO.Listar(this._empresa.Codigo, this._filial.Codigo);
        }

        public List<Periodo> Pesquisar(int id)
        {
            IPeriodoRepositorio umPeriodoDAO = new PeriodoDAO(this._conexao);
            return umPeriodoDAO.Pesquisar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        public Periodo Consultar(int id)
        {
            IPeriodoRepositorio umPeriodoDAO = new PeriodoDAO(this._conexao);
            return umPeriodoDAO.Consultar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        public Periodo Consultar(int ano, int mes, int meta, int funcionario)
        {
            IPeriodoRepositorio umPeriodoDAO = new PeriodoDAO(this._conexao);
            return umPeriodoDAO.Consultar(this._empresa.Codigo, this._filial.Codigo, ano, mes, meta, funcionario);
        }
    }
}
