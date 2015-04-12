using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using TransferenciaObjetos;
using System.Configuration;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 06/06/2014
// ********************************************************************* 
// Entidade StatusOS 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Ordem_servico.Tests
{
    [TestClass]
    public class StatusOSTeste
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
        public void ListarStatusOSTeste()
        {
            this.CriaInstancia();

            Empresa umaEmpresa = new Empresa();
            umaEmpresa.Codigo = "99";

            Filial umaFilial = new Filial();
            umaFilial.Codigo = "99";

            IStatusOrdemServicoNegocio umStatusNegocioBUS = new StatusOrdemServicoBUS(Conexao.Instacia, umaEmpresa, umaFilial);
            umStatusNegocioBUS.Listar();
        }
    }
}
