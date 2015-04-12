using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransferenciaObjetos;
using Negocio;
using System.Configuration;
using System.Collections.Generic;
using TransferenciaObjetos.Pessoas;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 12/05/2014
// ********************************************************************* 
// Entidade Teste unitários de OrdemServico
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Ordem_servico.Tests.Teste
{
    [TestClass]
    public class OrdemServicoTeste
    {

        private OrdemServicoBUS CriaInstancia()
        {
            Conexao.StringConnection = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ToString();
            Conexao.Ativar(true);
            OrdemServicoBUS osBUS = null;//new OrdemServicoBUS(Conexao.Instacia);
            return osBUS;
        }

        private void PreencherObjeto( out OrdemServico umaOrdemServico)
        {
            umaOrdemServico = new OrdemServico();
            umaOrdemServico.Empresa = new Empresa();
            umaOrdemServico.Empresa.Codigo = "99";
            umaOrdemServico.Empresa.Nome = "Teste";
            umaOrdemServico.Filial = new Filial();
            umaOrdemServico.Filial.Codigo = "99";
            umaOrdemServico.Filial.Nome = "Teste";
            umaOrdemServico.Cliente = new Cliente();
            umaOrdemServico.Cliente.Codigo = 1;
            umaOrdemServico.Funcionario = new Funcionario();
            umaOrdemServico.Funcionario.Empresa = new Empresa();
            umaOrdemServico.Funcionario.Empresa.Codigo = "99";
            umaOrdemServico.Funcionario.Empresa.Nome = "Teste";
            umaOrdemServico.Funcionario.Filial = new Filial();
            umaOrdemServico.Funcionario.Filial.Codigo = "99";
            umaOrdemServico.Funcionario.Filial.Nome = "Teste";
            umaOrdemServico.Funcionario.Codigo = 21;
            umaOrdemServico.Traslado = "0500";
            umaOrdemServico.Atividade = "nonononononon";
            umaOrdemServico.Data = DateTime.Now.ToString("dd/MM/yyyy");
            umaOrdemServico.Fim = "0400";
            umaOrdemServico.Inicio = "1800"; 
        }

        [TestMethod]
        public void TesteConexao()
        {
            this.CriaInstancia();
            Assert.IsNotNull(Conexao.Instacia);
        }

        [TestMethod]
        public void TestaListagemOS()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            List<OrdemServico> lista = new OrdemServicoBUS(Conexao.Instacia, emp, fil).Listar();
            Assert.AreNotEqual(0, lista.Count);
        }

        [TestMethod]
        public void TestaListagemPorFuncionario()
        {
            this.CriaInstancia();
            Empresa e = new Empresa();
            e.Codigo = "98";
            Filial f = new Filial();
            f.Codigo = "98";
            IOrdemServicoNegocio umaOSBUS = new OrdemServicoBUS(Conexao.Instacia, e, f);
            List<OrdemServico> lista = umaOSBUS.Listar("2");
        }

        [TestMethod]
        public void TestaPesquisaOS()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            List<OrdemServico> lista = new OrdemServicoBUS(Conexao.Instacia, emp, fil).Pesquisar(5);
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void TestaConsultaOS()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            OrdemServico os = new OrdemServicoBUS(Conexao.Instacia, emp, fil).Consultar(50);
            Assert.IsNotNull(os);
        }

        [TestMethod]
        public void TestaCadastroOS()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            INegocio<OrdemServico, int> umaOrdemServicoBUS = new OrdemServicoBUS(Conexao.Instacia, emp, fil);
            OrdemServico umaOrdemServico;
            this.PreencherObjeto(out umaOrdemServico);
            umaOrdemServicoBUS.Cadastrar(umaOrdemServico);
        }

        [TestMethod]
        public void TestaEdicaoOS()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            INegocio<OrdemServico, int> umaOrdemServicoBUS = new OrdemServicoBUS(Conexao.Instacia, emp, fil);
            OrdemServico umaOrdemServico;
            this.PreencherObjeto(out umaOrdemServico);
            umaOrdemServico.Codigo = 54;
            umaOrdemServicoBUS.Editar(umaOrdemServico);
        }

        [TestMethod]
        public void TestaExcluirOS()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            OrdemServico os = new OrdemServico();
            os.Codigo = 43;
            INegocio<OrdemServico, int> osBus = new OrdemServicoBUS(Conexao.Instacia, emp, fil);
            osBus.Excluir(os);
        }

        [TestMethod]
        public void TestaRelatorio()
        {
            string query = "SELECT O.CLIENTE, O.FUNCIONARIO, O.DATA, O.INICIO, O.FIM, O.TRANSLADO, O.ATIVIDADE, " +
                                         "C.CODIGO AS CODIGOCLIENTE, C.NOME AS NOMECLIENTE, F.NOME AS NOMEFUNCIONARIO, " +
                                         "F.CODIGO AS CODIGOFUNCIONARIO, F.DATACADASTRO, O.CODIGO AS CODIGOOS " +
                                         "FROM (\"ORDEM_SERVICO\" O INNER JOIN \"CLIENTES\" C ON O.CLIENTE = C.CODIGO " +
                                         ") INNER JOIN \"FUNCIONARIOS\" F ON O.FUNCIONARIO = F.CODIGO " +
                                        "WHERE O.CODIGO=@CODIGO";

            FbParameter[] parametros = new FbParameter[1];
            parametros[0] = new FbParameter();
            parametros[0].ParameterName = "@CODIGO";
            parametros[0].Value = 46;     
        }
    }
}
