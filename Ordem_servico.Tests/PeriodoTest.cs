using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransferenciaObjetos;
using System.Configuration;
using Negocio;
using System.Collections.Generic;
using TransferenciaObjetos.Pessoas;

namespace Ordem_servico.Tests
{
    [TestClass]
    public class PeriodoTest
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
        public void TestaListagemPeriodo()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "**";
            Filial fil = new Filial();
            fil.Codigo = "**";

            IPeriodoNegocio umPeriodo = new PeriodoBUS(Conexao.Instacia, emp, fil);
            List<Periodo> lista = umPeriodo.Listar();
        }

        [TestMethod]
        public void TestaConsultarPeriodo()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "**";
            Filial fil = new Filial();
            fil.Codigo = "**";

            IPeriodoNegocio umPeriodoBUS = new PeriodoBUS(Conexao.Instacia, emp, fil);
            Periodo umPeriodo = umPeriodoBUS.Consultar(2014, 1, 1, 1);
        }

        [TestMethod]
        public void TestaCadastrarPeriodo()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "**";
            Filial fil = new Filial();
            fil.Codigo = "**";

            Periodo umPeriodo = new Periodo();
            umPeriodo.Empresa = emp;
            umPeriodo.Filial = fil;
            umPeriodo.Meta = new Meta();
            umPeriodo.Meta.Codigo = 1;
            umPeriodo.Ano = 2014;
            umPeriodo.Mes = 5;
            umPeriodo.Realizado = 15;
            umPeriodo.Esperado = 7;

            IPeriodoNegocio umPeriodoBUS = new PeriodoBUS(Conexao.Instacia, emp, fil);
            umPeriodoBUS.Cadastrar(umPeriodo);
        }

        [TestMethod]
        public void TestaEditarPeriodo()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "**";
            Filial fil = new Filial();
            fil.Codigo = "**";

            Periodo umPeriodo = new Periodo();
            umPeriodo.Empresa = emp;
            umPeriodo.Filial = fil;
            umPeriodo.Meta = new Meta();
            umPeriodo.Meta.Codigo = 1;
            umPeriodo.Ano = 2014;
            umPeriodo.Mes = 5;
            umPeriodo.Realizado = 20;
            umPeriodo.Esperado = 10;

            IPeriodoNegocio umPeriodoBUS = new PeriodoBUS(Conexao.Instacia, emp, fil);
            umPeriodoBUS.Editar(umPeriodo);
        }

        [TestMethod]
        public void TestaexcluirPeriodo()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "**";
            Filial fil = new Filial();
            fil.Codigo = "**";

            Periodo umPeriodo = new Periodo();
            umPeriodo.Empresa = emp;
            umPeriodo.Filial = fil;
            umPeriodo.Meta = new Meta();
            umPeriodo.Meta.Codigo = 1;
            umPeriodo.Ano = 2014;
            umPeriodo.Mes = 5;

            IPeriodoNegocio umPeriodoBUS = new PeriodoBUS(Conexao.Instacia, emp, fil);
            umPeriodoBUS.Excluir(umPeriodo);
        }
    }
}
