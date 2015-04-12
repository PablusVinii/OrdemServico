using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Murta.OrdemServico.Tdd.SistemaServiceReference;

namespace Murta.OrdemServico.Tdd
{
    [TestClass]
    public class StatusTest
    {
        SistemaClient client = new SistemaClient();

        [TestMethod]
        public void ListarTodosStatus()
        {
            var status = this.client.ListarStatus();
            Assert.IsTrue(status.Length > 0);
        }
    }
}
