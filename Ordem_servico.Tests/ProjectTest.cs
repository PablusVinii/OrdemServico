using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransferenciaObjetos;
using System.Configuration;
using Negocio;
using System.Collections.Generic;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 23/06/2014
// ********************************************************************* 
// Entidade Projeto 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//

namespace Ordem_servico.Tests
{
    [TestClass]
    public class ProjectTest
    {
        private void CriaInstancia()
        {
            Conexao.StringConnection = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ToString();
            Conexao.Ativar(true);
        }

        [TestMethod]
        public void TestaListarProjeto()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "**";
            Filial fil = new Filial();
            fil.Codigo = "**";
            IProjetoNegocio umProjetoNegocio = new ProjetoBUS(Conexao.Instacia, emp, fil);
            List<Projeto> lista =  umProjetoNegocio.Listar();
        }

        [TestMethod]
        public void TestaPesquisaProjeto()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "**";
            Filial fil = new Filial();
            fil.Codigo = "**";
            IProjetoNegocio umProjetoNegocio = new ProjetoBUS(Conexao.Instacia, emp, fil);
            List<Projeto> lista = umProjetoNegocio.Pesquisar(1);
        }

        [TestMethod]
        public void TestaConsultaProjeto()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "**";
            Filial fil = new Filial();
            fil.Codigo = "**";
            IProjetoNegocio umProjetoNegocio = new ProjetoBUS(Conexao.Instacia, emp, fil);
            Projeto umProjeto = umProjetoNegocio.Consultar(1);
        }

        [TestMethod]
        public void TestaCadastroProjeto()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "**";
            Filial fil = new Filial();
            fil.Codigo = "**";
            IProjetoNegocio umProjetoNegocio = new ProjetoBUS(Conexao.Instacia, emp, fil);
            Projeto umProjeto = new Projeto();
            umProjeto.Empresa = emp;
            umProjeto.Filial = fil;
            umProjeto.Cliente = new Cliente();
            umProjeto.Cliente.Codigo = 1;
            umProjeto.HorasConsultor = "100";
            umProjeto.HorasCoordenador = "100";
            umProjeto.HorasGerente = "100";
            umProjeto.Meta = new Meta();
            umProjeto.Meta.Codigo = 4;
            umProjetoNegocio.Cadastrar(umProjeto);
        }

        [TestMethod]
        public void TestaEdicaoProjeto()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "**";
            Filial fil = new Filial();
            fil.Codigo = "**";
            IProjetoNegocio umProjetoNegocio = new ProjetoBUS(Conexao.Instacia, emp, fil);
            Projeto umProjeto = new Projeto();
            umProjeto.Codigo = 8;
            umProjeto.Empresa = emp;
            umProjeto.Filial = fil;
            umProjeto.Cliente = new Cliente { Codigo = 1 };
            umProjeto.HorasConsultor = "2000";
            umProjeto.HorasCoordenador = "2000";
            umProjeto.HorasGerente = "2000";
            umProjeto.Meta = new Meta();
            umProjeto.Meta.Codigo = 4;
            umProjetoNegocio.Editar(umProjeto);
        }

        [TestMethod]
        public void TestaExclusaoProjeto()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "**";
            Filial fil = new Filial();
            fil.Codigo = "**";
            IProjetoNegocio umProjetoNegocio = new ProjetoBUS(Conexao.Instacia, emp, fil);
            Projeto umProjeto = new Projeto();
            umProjeto.Empresa = emp;
            umProjeto.Filial = fil;
            umProjeto.Codigo = 1;
            umProjetoNegocio.Excluir(umProjeto);
        }
    }
}
