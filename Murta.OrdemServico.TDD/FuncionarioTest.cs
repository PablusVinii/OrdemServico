using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Murta.OrdemServico.Tdd.SistemaServiceReference;

namespace Murta.OrdemServico.Tdd
{
    [TestClass]
    public class FuncionarioTest
    {
        SistemaClient client = new SistemaClient();

        [TestMethod]
        public void ListarTodosFuncionarios()
        {
            var funcionarios = this.client.ListarFuncionarios();
            Assert.IsTrue(funcionarios.Length > 0);
        }
    }
}
