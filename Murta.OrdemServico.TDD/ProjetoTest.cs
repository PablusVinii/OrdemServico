using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Murta.OrdemServico.Tdd.SistemaServiceReference;

namespace Murta.OrdemServico.Tdd
{
    [TestClass]
    public class ProjetoTest
    {
        SistemaClient client = new SistemaClient();

        [TestMethod]
        public void ListarTodosProjetos()
        {
            var projetos = this.client.ListarProjetos();
            Assert.IsTrue(projetos.Length > 0);
        }
    }
}
