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
    public class MetaTest
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
        public void ListarMetasTest()
        {
            this.CriaInstancia();
            Empresa umaEmpresa = new Empresa();
            umaEmpresa.Codigo = "99";
            Filial umaFilial = new Filial();
            umaFilial.Codigo = "99";
            IMetaNegocio umaMetaBUS = new MetaBUS(Conexao.Instacia, umaEmpresa, umaFilial);
            List<Meta> lista = new List<Meta>();
            lista = umaMetaBUS.Listar();
        }


        [TestMethod]
        public void ConsultarMetasTest()
        {
            this.CriaInstancia();
            Empresa umaEmpresa = new Empresa();
            umaEmpresa.Codigo = "99";
            Filial umaFilial = new Filial();
            umaFilial.Codigo = "99";
            IMetaNegocio umaMetaBUS = new MetaBUS(Conexao.Instacia, umaEmpresa, umaFilial);
            Meta umaMeta = umaMetaBUS.Consultar(4);
        }

        [TestMethod]
        public void PesquisarMetasTest()
        {
            this.CriaInstancia();
            Empresa umaEmpresa = new Empresa();
            umaEmpresa.Codigo = "99";
            Filial umaFilial = new Filial();
            umaFilial.Codigo = "99";
            IMetaNegocio umaMetaBUS = new MetaBUS(Conexao.Instacia, umaEmpresa, umaFilial);
            List<Meta> lista = umaMetaBUS.Pesquisar(1);
        }

        [TestMethod]
        public void CadastrarMetasTest()
        {
            this.CriaInstancia();
            Empresa umaEmpresa = new Empresa();
            umaEmpresa.Codigo = "99";
            Filial umaFilial = new Filial();
            umaFilial.Codigo = "99";
            IMetaNegocio umaMetaBUS = new MetaBUS(Conexao.Instacia, umaEmpresa, umaFilial);
            Meta umaMeta = new Meta();
            umaMeta.Empresa = umaEmpresa;
            umaMeta.Filial = umaFilial;
            umaMeta.Descricao = "sasdsadsadasd";
            umaMeta.Indicador = new Indicador { Codigo = 1 };
            umaMeta.Funcionario = new Funcionario { Codigo = 2 };
            umaMeta.DataCadastro = DateTime.Now;
            umaMetaBUS.Cadastrar(umaMeta);
        }

        [TestMethod]
        public void EditarMetasTest()
        {
            this.CriaInstancia();
            Empresa umaEmpresa = new Empresa();
            umaEmpresa.Codigo = "99";
            Filial umaFilial = new Filial();
            umaFilial.Codigo = "99";
            IMetaNegocio umaMetaBUS = new MetaBUS(Conexao.Instacia, umaEmpresa, umaFilial); 
            Meta umaMeta = new Meta();
            umaMeta.Codigo = 1;
            umaMeta.Empresa = umaEmpresa;
            umaMeta.Filial = umaFilial;
            umaMeta.Descricao = "editadoooooo";
            umaMeta.Indicador = new Indicador { Codigo = 1 };
            umaMeta.Funcionario = new Funcionario { Codigo = 2 };
            umaMeta.DataCadastro = DateTime.Now;
            umaMetaBUS.Editar(umaMeta);
        }

        [TestMethod]
        public void ExcluirMetasTest()
        {
            this.CriaInstancia();
            Empresa umaEmpresa = new Empresa();
            umaEmpresa.Codigo = "99";
            Filial umaFilial = new Filial();
            umaFilial.Codigo = "99";
            IMetaNegocio umaMetaBUS = new MetaBUS(Conexao.Instacia, umaEmpresa, umaFilial); 
            Meta umaMeta = new Meta();
            umaMeta.Empresa = umaEmpresa;
            umaMeta.Filial = umaFilial;
            umaMeta.Codigo = 2;
            umaMetaBUS.Excluir(umaMeta);
        }
    }
}
