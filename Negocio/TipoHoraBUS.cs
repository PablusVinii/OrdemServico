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
// Data: 06/06/2014
// ********************************************************************* 
// Entidade TipoHora 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Negocio
{
    public class TipoHoraBUS:ITipoHoraNegocio
    {
        protected FbConnection _conexao = null;
        protected Empresa _empresa = null;
        protected Filial _filial = null;

        public TipoHoraBUS(FbConnection conn, Empresa emp, Filial fil)
        {
            this._conexao = conn;
            this._empresa = emp;
            this._filial = fil;
        }

        public void Cadastrar(TipoHora obj)
        {
            obj = this.ConfigurarCompartilhamentoDeTabelas(obj);
            ITipoHoraRepositorio umTipoHoraDAO = new TipoHoraDAO(this._conexao);
            umTipoHoraDAO.Cadastrar(obj);
        }

        public void Editar(TipoHora obj)
        {
            obj = this.ConfigurarCompartilhamentoDeTabelas(obj);
            ITipoHoraRepositorio umTipoHoraDAO = new TipoHoraDAO(this._conexao);
            umTipoHoraDAO.Editar(obj);
        }

        public void Excluir(TipoHora obj)
        {
            ITipoHoraRepositorio umTipoHoraDAO = new TipoHoraDAO(this._conexao);
            umTipoHoraDAO.Excluir(obj);
        }

        public List<TipoHora> Listar()
        {
            ITipoHoraRepositorio umTipoHoraDAO = new TipoHoraDAO(this._conexao);
            return umTipoHoraDAO.Listar(this._empresa.Codigo, this._filial.Codigo);
        }

        public List<TipoHora> Pesquisar(int id)
        {
            ITipoHoraRepositorio umTipoHoraDAO = new TipoHoraDAO(this._conexao);
            return umTipoHoraDAO.Pesquisar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        public TipoHora Consultar(int id)
        {
            ITipoHoraRepositorio umTipoHoraDAO = new TipoHoraDAO(this._conexao);
            return umTipoHoraDAO.Consultar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        protected TipoHora ConfigurarCompartilhamentoDeTabelas(TipoHora obj)
        {
            bool empresa = false;
            bool filial = false;

            ProprietarioEntidade.VerificaProprietario("TipoHora", this._conexao, ref empresa, ref filial);

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
