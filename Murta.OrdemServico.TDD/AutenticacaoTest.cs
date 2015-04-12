using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Murta.OrdemServico.Tdd.SistemaServiceReference;

namespace Murta.OrdemServico.Tdd
{
    [TestClass]
    public class AutenticacaoTest
    {
        protected SistemaClient client = new SistemaClient();

        [TestMethod]
        public void Login()
        {
            string usuario = "Julio";
            string senha = "24054790";
            Usuario usuarioLogado = this.client.Login(usuario, senha);
            Assert.IsNotNull(usuarioLogado);
        }
    }
}
