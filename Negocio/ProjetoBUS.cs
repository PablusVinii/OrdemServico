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
// Data: 20/06/2014
// ********************************************************************* 
// Entidade Projeto 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Negocio
{
    public class ProjetoBUS:IProjetoNegocio
    {
        protected FbConnection _conexao = null;
        protected Empresa _empresa = null;
        protected Filial _filial = null;

        public ProjetoBUS(FbConnection conn, Empresa emp, Filial fil)
        {
            this._conexao = conn;
            this._empresa = emp;
            this._filial = fil;
        }

        public void Cadastrar(Projeto obj)
        {
            obj = this.ConfigurarCompartilhamentoDeTabelas(obj);
            IProjetoRepositorio umProjetoDAO = new ProjetoDAO(this._conexao);
            umProjetoDAO.Cadastrar(obj);
        }

        public void Editar(Projeto obj)
        {
            obj = this.ConfigurarCompartilhamentoDeTabelas(obj);
            IProjetoRepositorio umProjetoDAO = new ProjetoDAO(this._conexao);
            umProjetoDAO.Editar(obj);

            if (obj.Meta != null)
            {
                int i = 0;
                IMetaNegocio umaMetaBus = new MetaBUS(this._conexao, this._empresa, this._filial);
                IPeriodoNegocio umPeriodoNegocio = new PeriodoBUS(Conexao.Instacia, this._empresa, this._filial);
                Meta umaMeta = umaMetaBus.Consultar(obj.Meta.Codigo);

                foreach (var periodo in umaMeta.Periodos)
                {
                    periodo.Meta = umaMeta;
                    periodo.Realizado = umaMetaBus.ApurarMetasPorMes(periodo.Ano, periodo.Mes, umaMeta.Funcionario, obj, umaMeta.Indicador);
                    umPeriodoNegocio.Editar(periodo);
                }
            }
        }

        public void Excluir(Projeto obj)
        {
            IProjetoRepositorio umProjetoDAO = new ProjetoDAO(this._conexao);
            umProjetoDAO.Excluir(obj);
        }

        public List<Projeto> Listar()
        {
            IProjetoRepositorio umProjetoDAO = new ProjetoDAO(this._conexao);
            return umProjetoDAO.Listar(this._empresa.Codigo, this._filial.Codigo);
        }

        public List<Projeto> Pesquisar(int id)
        {
            IProjetoRepositorio umProjetoDAO = new ProjetoDAO(this._conexao);
            return umProjetoDAO.Pesquisar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        public List<Projeto> Pesquisar(string descricao)
        {
            IProjetoRepositorio umProjetoDAO = new ProjetoDAO(this._conexao);
            return umProjetoDAO.Pesquisar(this._empresa.Codigo, this._filial.Codigo, descricao);
        }

        public Projeto Consultar(int id)
        {
            IProjetoRepositorio umProjetoDAO = new ProjetoDAO(this._conexao);
            return umProjetoDAO.Consultar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        protected Projeto ConfigurarCompartilhamentoDeTabelas(Projeto obj)
        {
            bool empresa = false;
            bool filial = false;

            ProprietarioEntidade.VerificaProprietario("Projeto", this._conexao, ref empresa, ref filial);

            obj.Empresa = new Empresa();
            obj.Empresa.Codigo = "**";

            if (empresa)
            {
                obj.Empresa.Codigo = this._empresa.Codigo;
            }

            obj.Filial = new Filial();
            obj.Filial.Codigo = "**";

            if (filial)
            {
                obj.Filial.Codigo = this._filial.Codigo;
            }

            return obj;
        }
    }
}
