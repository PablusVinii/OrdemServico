using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using TransferenciaObjetos;
using System.Configuration;
using TransferenciaObjetos.Pessoas;
using System.Collections.Generic;

namespace Ordem_servico.Tests
{
    [TestClass]
    public class OSRemotoTeste
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

        private OrdemServicoRemoto PreencherObjeto()
        {
            OrdemServico umaOrdemServico = new OrdemServico();
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
            umaOrdemServico.Projeto = new Projeto();
            umaOrdemServico.Projeto.Codigo = 1;
            umaOrdemServico.TipoHora = new TipoHora();
            umaOrdemServico.TipoHora.Codigo = 1;
            umaOrdemServico.Traslado = "0500";
            umaOrdemServico.Atividade = "editando";
            umaOrdemServico.Data = "01/01/1900";
            umaOrdemServico.Fim = "0400";
            umaOrdemServico.Inicio = "1800";
            umaOrdemServico.Status = new StatusOS();
            umaOrdemServico.Status.Codigo = 1;
            umaOrdemServico.Observacao = string.Empty;

            OrdemServicoRemoto umaOrdemServicoRemoto = new OrdemServicoRemoto();
            umaOrdemServicoRemoto.OrdemServico = umaOrdemServico;
            umaOrdemServicoRemoto.DataFim = Convert.ToDateTime("01/01/1900");
            umaOrdemServicoRemoto.DataInicio = Convert.ToDateTime("01/03/1985");

            return umaOrdemServicoRemoto;
        }

        [TestMethod]
        public void TestaCadastroOsRemota()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            IOrdemServicoRemotoNegocio umaOsRemotaBUs = new OrdemServicoRemotoBUS(Conexao.Instacia, emp, fil);
            OrdemServicoRemoto osr = PreencherObjeto();
            umaOsRemotaBUs.Cadastrar(osr);
        }


        [TestMethod]
        public void TestaEdicaoOsRemota()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            IOrdemServicoRemotoNegocio umaOsRemotaBUs = new OrdemServicoRemotoBUS(Conexao.Instacia, emp, fil);
            OrdemServicoRemoto umaOsREmota = PreencherObjeto();
            umaOsREmota.OrdemServico.Codigo = 50;
            umaOsRemotaBUs.Editar(umaOsREmota);
        }


        [TestMethod]
        public void TestaExclusaoOsRemota()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            IOrdemServicoRemotoNegocio umaOsRemotaBUs = new OrdemServicoRemotoBUS(Conexao.Instacia, emp, fil);
            OrdemServicoRemoto umaOsREmota = new OrdemServicoRemoto { OrdemServico = new OrdemServico { Codigo = 38 } };
            umaOsRemotaBUs.Excluir(umaOsREmota);
        }


        [TestMethod]
        public void TestaListagemOsRemota()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            IOrdemServicoRemotoNegocio umaOsRemotaBUs = new OrdemServicoRemotoBUS(Conexao.Instacia, emp, fil);
            List<OrdemServicoRemoto> lista = umaOsRemotaBUs.Listar();
        }

        [TestMethod]
        public void TestaListagemPorFuncionarioOsRemota()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            IOrdemServicoRemotoNegocio umaOsRemotaBUs = new OrdemServicoRemotoBUS(Conexao.Instacia, emp, fil);
            List<OrdemServicoRemoto> lista = umaOsRemotaBUs.Listar("4");
        }

        [TestMethod]
        public void TestaPesquisaOsRemota()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            IOrdemServicoRemotoNegocio umaOsRemotaBUs = new OrdemServicoRemotoBUS(Conexao.Instacia, emp, fil);
            List<OrdemServicoRemoto> lista = umaOsRemotaBUs.Pesquisar(1);
        }

        [TestMethod]
        public void TestaPesquisaPorOrdemDeServicoRemotaOsRemota()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "99";
            Filial fil = new Filial();
            fil.Codigo = "99";
            IOrdemServicoRemotoNegocio umaOsRemotaBUs = new OrdemServicoRemotoBUS(Conexao.Instacia, emp, fil);
            OrdemServicoRemoto osr = new OrdemServicoRemoto();
            osr.OrdemServico = new OrdemServico();
            osr.OrdemServico.Codigo = 1;
            osr.OrdemServico.Projeto = new Projeto();
            osr.OrdemServico.Cliente = new Cliente();
            osr.OrdemServico.Funcionario = new Funcionario();
            List<OrdemServicoRemoto> lista = umaOsRemotaBUs.Pesquisar(osr);

        }
    }
}
