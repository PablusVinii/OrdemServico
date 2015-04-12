using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using TransferenciaObjetos;
using System.Configuration;

namespace Ordem_servico.Tests
{
    [TestClass]
    public class StatusTeste
    {
        private void CriaInstancia()
        {
            Conexao.StringConnection = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ToString();
            Conexao.Ativar(true);
        }

        [TestMethod]
        public void ListarStatus()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "**";
            Filial fil = new Filial();
            fil.Codigo = "**";
            IStatusNegocio umStatusBus = new StatusBUS(Conexao.Instacia, emp, fil);
            umStatusBus.Listar();
        }
    }
}
