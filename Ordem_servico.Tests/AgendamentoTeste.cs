using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using TransferenciaObjetos;
using TransferenciaObjetos.Pessoas;
using System.Configuration;
using System.Collections.Generic;
// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 26/05/2014
// ********************************************************************* 
// Entidade AgendamentoTeste
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
namespace Ordem_servico.Tests
{
    [TestClass]
    public class AgendamentoTeste
    {

        private void CriaInstancia()
        {
            Conexao.StringConnection = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ToString();
            Conexao.Ativar(true);

            try
            {

                Assert.IsTrue(Conexao.Instacia.State == System.Data.ConnectionState.Open);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexao.Ativar(false);
            }
        }

        [TestMethod]
        public void TesteCadastroAgendamento()
        {
           this.CriaInstancia();

            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            Cliente cli = new Cliente();
            cli.Codigo = 1;
            Funcionario func = new Funcionario();
            func.Codigo = 1;
            Status st = new Status();
            st.Codigo = 1;

            Agendamento umAgendamento = new Agendamento();
            umAgendamento.Cliente = cli;
            umAgendamento.Funcionario = func;
            umAgendamento.Empresa = emp;
            umAgendamento.Filial = fil;
            umAgendamento.Status = st;
            umAgendamento.DataPrevista = DateTime.Now.ToString("dd/MM/yyyy");
            umAgendamento.InicioPrevisto = "04:00";
            umAgendamento.FimPrevisto = "16:00";
            umAgendamento.TrasladoPrevisto = "01:00";
            IAgendamentoNegocio umAgendamentoBUS = new AgendamentoBUS(Conexao.Instacia, emp, fil);
            umAgendamentoBUS.Cadastrar(umAgendamento);
        }

        [TestMethod]
        public void TesteEditarAgendamento()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            Cliente cli = new Cliente();
            cli.Codigo = 1;
            Funcionario func = new Funcionario();
            func.Codigo = 1;
            Status st = new Status();
            st.Codigo = 2;

            Agendamento umAgendamento = new Agendamento();
            umAgendamento.Codigo = 1;
            umAgendamento.Cliente = cli;
            umAgendamento.Funcionario = func;
            umAgendamento.Empresa = emp;
            umAgendamento.Filial = fil;
            umAgendamento.Status = st;
            umAgendamento.DataPrevista = DateTime.Now.ToString("dd/MM/yyyy");
            umAgendamento.InicioPrevisto = "04:00";
            umAgendamento.FimPrevisto = "16:00";
            umAgendamento.TrasladoPrevisto = "01:00";
            umAgendamento.DataConclusao = DateTime.Now.ToString("dd/MM/yyyy");
            umAgendamento.InicioConclusao = "06:00";
            umAgendamento.FimConclusao = "15:00";
            umAgendamento.TrasladoConclusao = "02:00";
            IAgendamentoNegocio umAgendamentoBUS = new AgendamentoBUS(Conexao.Instacia, emp, fil);
            umAgendamentoBUS.Editar(umAgendamento);
        }

        [TestMethod]
        public void TesteExcluirAgendamento()
        {
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";

            Agendamento umAgendamento = new Agendamento();
            umAgendamento.Codigo = 2;
            umAgendamento.Empresa = emp;
            umAgendamento.Filial = fil;

            IAgendamentoNegocio umAgendamentoBUS = new AgendamentoBUS(Conexao.Instacia, emp, fil);
            umAgendamentoBUS.Excluir(umAgendamento);
        }

        [TestMethod]
        public void TesteListarAgendamento()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";

            IAgendamentoNegocio umAgendamentoBUS = new AgendamentoBUS(Conexao.Instacia, emp, fil);
            List<Agendamento> lista = umAgendamentoBUS.Listar();
        }

        [TestMethod]
        public void TesteListarAgendamentoPorFuncionario()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";

            IAgendamentoNegocio umAgendamentoBUS = new AgendamentoBUS(Conexao.Instacia, emp, fil);
            List<Agendamento> lista = umAgendamentoBUS.Listar(2);
        }

        [TestMethod]
        public void TestePesquisarAgendamento()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";

            IAgendamentoNegocio umAgendamentoBUS = new AgendamentoBUS(Conexao.Instacia, emp, fil);
            List<Agendamento> lista = umAgendamentoBUS.Pesquisar(1);
        }

        [TestMethod]
        public void TesteConsultarAgendamento()
        {

            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";

            IAgendamentoNegocio umAgendamentoBUS = new AgendamentoBUS(Conexao.Instacia, emp, fil);
            Agendamento ag = umAgendamentoBUS.Consultar(1);
        }
    }
}
