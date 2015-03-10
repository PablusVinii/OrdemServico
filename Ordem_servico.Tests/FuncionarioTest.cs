using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransferenciaObjetos.Pessoas;
using TransferenciaObjetos;
using FirebirdSql.Data.FirebirdClient;
using System.Configuration;
using Negocio;
using System.Collections.Generic;

namespace Ordem_servico.Tests
{
    [TestClass]
    public class FuncionarioTest
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
        public void TestaConsultaFuncionario()
        {
            this.CriaInstancia();
            Empresa umaEmpresa = new Empresa();
            umaEmpresa.Codigo = "99";
            Filial umaFilial = new Filial();
            umaFilial.Codigo = "99";
            INegocio<Funcionario, int> func = new FuncionarioBUS(Conexao.Instacia, umaEmpresa, umaFilial);
            Funcionario f = func.Consultar(2);
            Assert.IsNotNull(f);

            Conexao.Ativar(false);
        }

        [TestMethod]
        public void TestaListagemFuncionario()
        {
            this.CriaInstancia();
            List<Funcionario> lista = new List<Funcionario>();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            lista = new FuncionarioBUS(Conexao.Instacia, emp, fil).Listar();
            Assert.AreNotEqual(0, lista.Count);
        }

        [TestMethod]
        public void TestaPesquisaFucnionario()
        {
            this.CriaInstancia();
            List<Funcionario> lista = new List<Funcionario>();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            lista = new FuncionarioBUS(Conexao.Instacia, emp, fil).Pesquisar(2);
            Assert.IsNotNull(lista);
        }
    }
}
