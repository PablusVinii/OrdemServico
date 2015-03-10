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
// Data: 26/05/2014
// ********************************************************************* 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Negocio
{
    public class AgendamentoBUS:IAgendamentoNegocio
    {
        protected FbConnection _conexao = null;
        protected Empresa _empresa = null;
        protected Filial _filial = null;

        public AgendamentoBUS(FbConnection conn, Empresa emp, Filial fil)
        {
            this._conexao = conn;
            this._empresa = emp;
            this._filial = fil;
        }

        public void Cadastrar(Agendamento obj)
        {
            obj = this.ConfigurarCompartilhamentoDeTabelas(obj);
            IAgendamentoRepositorio umAgendamentoDAO = new AgendamentoDAO(this._conexao);
            umAgendamentoDAO.Cadastrar(obj);
        }

        public void Editar(Agendamento obj)
        {
            obj = this.ConfigurarCompartilhamentoDeTabelas(obj);
            IAgendamentoRepositorio umAgendamnetoDAO = new AgendamentoDAO(this._conexao);
            umAgendamnetoDAO.Editar(obj);
        }

        public void Excluir(Agendamento obj)
        {
            IAgendamentoRepositorio umAgendamentoRepositorio = new AgendamentoDAO(this._conexao);
            umAgendamentoRepositorio.Excluir(obj);
        }

        public List<Agendamento> Listar()
        {
            IAgendamentoRepositorio umAgendamentoRepositorio = new AgendamentoDAO(this._conexao);
            return umAgendamentoRepositorio.Listar(this._empresa.Codigo, this._filial.Codigo);
        }

        public List<Agendamento> Listar(int IdFuncionario)
        {
            IAgendamentoRepositorio umAgendamentoRepositorio = new AgendamentoDAO(this._conexao);
            return umAgendamentoRepositorio.Listar(this._empresa.Codigo, this._filial.Codigo, IdFuncionario);
        }

        public List<Agendamento> Pesquisar(int id)
        {
            IAgendamentoRepositorio umAgendamentoRepositorio = new AgendamentoDAO(this._conexao);
            return umAgendamentoRepositorio.Pesquisar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        public Agendamento Consultar(int id)
        {
            IAgendamentoRepositorio umAgendamentoRepositorio = new AgendamentoDAO(this._conexao);
            return umAgendamentoRepositorio.Consultar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        protected Agendamento ConfigurarCompartilhamentoDeTabelas(Agendamento obj)
        {
            bool empresa = false;
            bool filial = false;

            ProprietarioEntidade.VerificaProprietario("Agendamento", this._conexao, ref empresa, ref filial);

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
