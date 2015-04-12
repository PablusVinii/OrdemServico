using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Murta.OrdemServico.Tdd.SistemaServiceReference;

namespace Murta.OrdemServico.Tdd
{
    [TestClass]
    public class ClienteTest
    {
        protected SistemaClient client = new SistemaClient();

        [TestMethod]
        public void ListarTodosClientes()
        {
            var clientes = this.client.ListarClientes();
            Assert.IsTrue(clientes.Length > 0);
        }
    }
}
