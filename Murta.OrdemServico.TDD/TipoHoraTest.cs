using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Murta.OrdemServico.Tdd.SistemaServiceReference;

namespace Murta.OrdemServico.Tdd
{
    [TestClass]
    public class TipoHoraTest
    {
        SistemaClient client = new SistemaClient();

        [TestMethod]
        public void ListarTiposDeHora()
        {
            var tiposhora = this.client.ListarTiposHora();
            Assert.IsTrue(tiposhora.Length > 0);
        }
    }
}
