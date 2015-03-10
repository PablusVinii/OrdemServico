using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRS.Apoio;

namespace Ordem_servico.Tests
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void EnviaEmail()
        {
            Email umEmail = new Email("jhonny.ramos@trssistemas.com.br", 
                                      "souzamurtaj@gmail.com, philipe.pompeu@trssistemas.com.br", 
                                      "Recado Importante", 
                                      "Te amo meu ");
           
            var enviado = umEmail.Enviar();
            Assert.IsTrue(enviado);
        }
    }
}
