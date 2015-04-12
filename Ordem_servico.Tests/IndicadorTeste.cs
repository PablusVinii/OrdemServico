using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransferenciaObjetos;
using System.Configuration;

namespace Ordem_servico.Tests
{
    [TestClass]
    public class IndicadorTeste
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
    }
}
