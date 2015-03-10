using AcessaDados;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TransferenciaObjetos;
using TransferenciaObjetos.Pessoas;

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
    public class MetaBUS : IMetaNegocio
    {
        FbConnection _conexao = null;
        Empresa _empresa = null;
        Filial _filial = null;

        public MetaBUS(FbConnection conn, Empresa emp, Filial fil)
        {
            this._conexao = conn;
            this._empresa = emp;
            this._filial = fil;
        }

        public void Cadastrar(Meta obj)
        {
            IMetaRepositorio umaMetaRepositorio = new MetaDAO(this._conexao);
            obj.Empresa = this._empresa;
            obj.Filial = this._filial;
            umaMetaRepositorio.Cadastrar(obj);

            IPeriodoNegocio umPeriodoNegocio = new PeriodoBUS(Conexao.Instacia, this._empresa, this._filial);

            int codigo = umaMetaRepositorio.UltimoId();
            int i = 0;

            foreach (var periodo in obj.Periodos)
            {
                periodo.Meta = obj;
                periodo.Mes = ++i;
                periodo.Meta.Codigo = codigo;
                periodo.Ano = DateTime.Now.Year;
                periodo.Realizado = 0;
                umPeriodoNegocio.Cadastrar(periodo);
            }
        }

        public void Editar(Meta obj)
        {
            IMetaRepositorio umaMetaRepositorio = new MetaDAO(this._conexao);
            obj.Empresa = this._empresa;
            obj.Filial = this._filial;
            umaMetaRepositorio.Editar(obj);

            List<Periodo> periodos = obj.Periodos;
            obj = umaMetaRepositorio.Consultar(this._empresa.Codigo, this._filial.Codigo, obj.Codigo);

            for (int x = 0; x < periodos.Count - 1; x++)
            {
                periodos[x].Realizado = obj.Periodos[x].Realizado;
            }

            IPeriodoNegocio umPeriodoNegocio = new PeriodoBUS(Conexao.Instacia, this._empresa, this._filial);

            int i = 0;
            foreach (var periodo in periodos)
            {
                periodo.Meta = obj;
                periodo.Mes = ++i;
                periodo.Meta.Codigo = obj.Codigo;
                periodo.Ano = DateTime.Now.Year;
                periodo.Empresa = this._empresa;
                periodo.Filial = this._filial;
                umPeriodoNegocio.Editar(periodo);
            }
        }

        public void Excluir(Meta obj)
        {
            IMetaRepositorio umaMetaRepositorio = new MetaDAO(this._conexao);
            umaMetaRepositorio.Excluir(obj);

            IPeriodoNegocio umPeriodoNegocio = new PeriodoBUS(this._conexao, this._empresa, this._filial);

            for (int i = 1; i <= 12; i++)
            {
                Periodo umPeriodo = new Periodo();
                umPeriodo.Meta = new Meta();
                umPeriodo.Meta.Codigo = obj.Codigo;
                umPeriodo.Meta.Funcionario = obj.Funcionario;
                umPeriodo.Ano = DateTime.Now.Year;
                umPeriodo.Mes = i;
                umPeriodoNegocio.Excluir(umPeriodo);
            } 
        }

        public List<Meta> Listar()
        {
            IMetaRepositorio umaMetaRepositorio = new MetaDAO(this._conexao);
            return umaMetaRepositorio.Listar(this._empresa.Codigo, this._filial.Codigo);
        }

        public List<Meta> Listar(int funcionario)
        {
            IMetaRepositorio umaMetaRepositorio = new MetaDAO(this._conexao);
            return umaMetaRepositorio.Listar(this._empresa.Codigo, this._filial.Codigo, funcionario);
        }

        public List<Meta> Listar(Projeto projeto)
        {
            IMetaRepositorio umaMetaRepositorio = new MetaDAO(this._conexao);
            return umaMetaRepositorio.Listar(this._empresa.Codigo, this._filial.Codigo, projeto);
        }

        public List<Meta> Pesquisar(int id)
        {
            IMetaRepositorio umaMetaRepositorio = new MetaDAO(this._conexao);
            return umaMetaRepositorio.Pesquisar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        public Meta Consultar(int id)
        {
            IMetaRepositorio umaMetaRepositorio = new MetaDAO(this._conexao);
            return umaMetaRepositorio.Consultar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        public double ApurarMetasPorMes(int ano, int mes, Funcionario funcionario, Projeto projeto, Indicador indicador)
        {
            OrdemServico ordemFiltro = new OrdemServico();
            ordemFiltro.DataDe = "01/" + mes + "/" + ano;
            ordemFiltro.DataAte = new DateTime(ano, mes, DateTime.DaysInMonth(ano, mes)).ToString("dd/MM/yyy");
            ordemFiltro.Projeto = projeto;
            ordemFiltro.Funcionario = funcionario;
            ordemFiltro.Cliente = new Cliente();

            OrdemServicoBUS umaOrdemServicoBUS = new OrdemServicoBUS(this._conexao, this._empresa, this._filial);
            List<OrdemServico> listaOrdens = umaOrdemServicoBUS.Pesquisar(ordemFiltro);

            double total = 0;

            switch (indicador.Codigo)
            {
                case 1: //HORA
                    foreach (var os in listaOrdens)
                    {
                        double horas = 0;

                        if ((os.Inicio == "00:00") && (os.Fim == "00:00"))
                        {
                            OrdemServicoRemoto osr = new OrdemServicoRemotoBUS(this._conexao, this._empresa, this._filial).Consultar(os.Codigo);
                            DateTime horasAcimaDeCem = new DateTime();
                            horasAcimaDeCem = horasAcimaDeCem.AddHours(Convert.ToInt32(osr.Total.Split(':')[0]));
                            horasAcimaDeCem = horasAcimaDeCem.AddMinutes(Convert.ToInt32(osr.Total.Split(':')[1]));
                            TimeSpan ticks = new TimeSpan(horasAcimaDeCem.Ticks);
                            total += ticks.TotalHours;
                        }
                        else
                        {
                            horas = TimeSpan.Parse(os.Total).TotalHours;
                        }
                        total += horas;
                    }
                    break;
                case 2: //PROSPECÇÕES                              
                    total = listaOrdens.Count;
                    break;
            }

            return total;
        }

        public DataTable GerarRelatorio(string query, IEnumerable<FbParameter> parametros)
        {
            IMetaRepositorio umaMetaDAO = new MetaDAO(this._conexao);
            return umaMetaDAO.GerarRelatorio(query, parametros);
        }
    }
}
