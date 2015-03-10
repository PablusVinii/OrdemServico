using FirebirdSql.Data.FirebirdClient;
using AcessaDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;
using System.Data;
using TransferenciaObjetos.Autenticacao;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 12/05/2014
// ********************************************************************* 
// Entidade OrdemServico
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Negocio
{
    public class OrdemServicoBUS : IOrdemServicoNegocio
    {
        protected FbConnection _conexao = null;
        protected Empresa _empresa = null;
        protected Filial _filial = null;

        public OrdemServicoBUS(FbConnection conn, Empresa empresa, Filial filial)
        {
            this._conexao = conn;
            this._empresa = empresa;
            this._filial = filial;
        }

        public void Cadastrar(OrdemServico obj)
        {
            obj = this.ConfigurarCompartilhamentoDeTabelas(obj);

            IOrdemServicoRepositorio umOrdemServicoDAO = new OrdemServicoDAO(this._conexao);
            umOrdemServicoDAO.Cadastrar(obj);

            IMetaNegocio umaMetaNegocio = new MetaBUS(this._conexao, this._empresa, this._filial);
            List<Meta> lista = umaMetaNegocio.Listar(obj.Projeto);

            DateTime dataOrdemServico = Convert.ToDateTime(obj.Data);

            foreach (var meta in lista)
            {
                umOrdemServicoDAO.AcrescentarNaMeta(
                    ano: dataOrdemServico.Year,
                    mes: dataOrdemServico.Month,
                    meta: meta.Codigo,
                    funcionario: obj.Funcionario.Codigo,
                    indicador: meta.Indicador.Codigo,
                    totalHoras: TimeSpan.Parse(obj.Total).TotalHours);
            }
        }

        public void Editar(OrdemServico obj)
        {
            obj = this.ConfigurarCompartilhamentoDeTabelas(obj);
            IOrdemServicoRepositorio umOrdemServicoDAO = new OrdemServicoDAO(this._conexao);
            OrdemServico objAnterior = umOrdemServicoDAO.Consultar(this._empresa.Codigo, this._filial.Codigo, obj.Codigo);
            umOrdemServicoDAO.Editar(obj);

            if ((obj.Inicio != "00:00") && (obj.Fim != "00:00"))
            {

                IMetaNegocio umaMetaNegocio = new MetaBUS(this._conexao, this._empresa, this._filial);
                List<Meta> lista = umaMetaNegocio.Listar(obj.Projeto);

                DateTime dataOrdemServico = Convert.ToDateTime(obj.Data);

                foreach (var meta in lista)
                {
                    if (meta.Indicador.Codigo == 1)
                    {

                        double totalAtual = TimeSpan.Parse(obj.Total).TotalHours;
                        double totalAnterior = TimeSpan.Parse(objAnterior.Total).TotalHours;

                        if (totalAtual > totalAnterior)
                        {
                            umOrdemServicoDAO.AcrescentarNaMeta
                                (
                                    ano: dataOrdemServico.Year,
                                    mes: dataOrdemServico.Month,
                                    meta: meta.Codigo,
                                    funcionario: obj.Funcionario.Codigo,
                                    indicador: meta.Indicador.Codigo,
                                    totalHoras: totalAtual - totalAnterior
                                );
                        }
                        else
                        {
                            umOrdemServicoDAO.DecrementarNaMeta
                                 (
                                     ano: dataOrdemServico.Year,
                                     mes: dataOrdemServico.Month,
                                     meta: meta.Codigo,
                                     funcionario: obj.Funcionario.Codigo,
                                     indicador: meta.Indicador.Codigo,
                                     totalHoras: totalAnterior - totalAtual
                                 );
                        }
                    }
                }
            }
        }

        public void Excluir(OrdemServico obj)
        {
            IOrdemServicoRepositorio umOrdemServicoDAO = new OrdemServicoDAO(this._conexao);
            obj = umOrdemServicoDAO.Consultar(this._empresa.Codigo, this._filial.Codigo, obj.Codigo);
            umOrdemServicoDAO.Excluir(obj);

            if ((obj.Inicio != "00:00")&&(obj.Fim != "00:00"))
            {
                IMetaNegocio umaMetaNegocio = new MetaBUS(this._conexao, this._empresa, this._filial);
                List<Meta> lista = umaMetaNegocio.Listar(obj.Projeto);

                DateTime dataOrdemServico = Convert.ToDateTime(obj.Data);

                foreach (var meta in lista)
                {
                    umOrdemServicoDAO.DecrementarNaMeta(
                        ano: dataOrdemServico.Year,
                        mes: dataOrdemServico.Month,
                        meta: meta.Codigo,
                        funcionario: obj.Funcionario.Codigo,
                        indicador: meta.Indicador.Codigo,
                        totalHoras: TimeSpan.Parse(obj.Total).TotalHours);
                }
            }
        }

        public List<OrdemServico> Listar()
        {
            IOrdemServicoRepositorio umOrdemServicoDAO = new OrdemServicoDAO(this._conexao);
            return umOrdemServicoDAO.Listar(this._empresa.Codigo, this._filial.Codigo);
        }

        public List<OrdemServico> Listar(string idFuncionario)
        {
            IOrdemServicoRepositorio umOrdemServicoDAO = new OrdemServicoDAO(this._conexao);
            return umOrdemServicoDAO.Listar(this._empresa.Codigo, this._filial.Codigo, idFuncionario);
        }

        public List<OrdemServico> Pesquisar(int id)
        {
            IOrdemServicoRepositorio umOrdemServicoDAO = new OrdemServicoDAO(this._conexao);
            return umOrdemServicoDAO.Pesquisar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        public List<OrdemServico> Pesquisar(OrdemServico os)
        {
            IOrdemServicoRepositorio umaOrdemServicoDAO = new OrdemServicoDAO(this._conexao);
            return umaOrdemServicoDAO.Pesquisar(this._empresa.Codigo, this._filial.Codigo, os);
        }

        public OrdemServico Consultar(int id)
        {
            IOrdemServicoRepositorio umOrdemServicoDAO = new OrdemServicoDAO(this._conexao);
            return umOrdemServicoDAO.Consultar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        public DataTable GerarRelatorio(string query, IEnumerable<FbParameter> parametros)
        {

            IOrdemServicoRepositorio umOrdemServicaoDAO = new OrdemServicoDAO(this._conexao);
            return umOrdemServicaoDAO.GerarRelatorio(query, parametros);
        }

        protected OrdemServico ConfigurarCompartilhamentoDeTabelas(OrdemServico obj)
        {
            bool empresa = false;
            bool filial = false;

            ProprietarioEntidade.VerificaProprietario("OrdemServico", this._conexao, ref empresa, ref filial);

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

        public bool VerificaPrazoEdicao(OrdemServico os, int diasLimite)
        {
            string data = string.Empty;

            if (os.Remoto)
                data = os.DataAte;
            else
                data = os.Data;

            TimeSpan diferenca = DateTime.Now.Date - Convert.ToDateTime(data).Date;
            int d = (int)diferenca.TotalDays;
            return (d <= diasLimite);
        }

        public int UltimoId()
        {
            IOrdemServicoRepositorio umOrdemServicoDAO = new OrdemServicoDAO(this._conexao);
            return umOrdemServicoDAO.UltimoId();
        }
    }
}
