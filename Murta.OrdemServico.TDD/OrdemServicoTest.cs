using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Murta.OrdemServico.Tdd.SistemaServiceReference;

namespace Murta.OrdemServico.Tdd
{
    [TestClass]
    public class OrdemServicoTest
    {
        protected SistemaClient client = new SistemaClient();

        [TestMethod]
        public void ListarTodasOrdemDeServico()
        {
            var ordensServico = this.client.ListarOrdemServico();
            Assert.IsTrue(ordensServico != null && ordensServico.Length != 0);
        }

        [TestMethod]
        public void ConsultarOrdemDeServico()
        {
            var ordemServico = this.client.ConsultarOrdemServico(23);
            Assert.IsTrue(ordemServico != null);
        }

        [TestMethod]
        public void CadastrarOrdemDeServico()
        {
            try
            {
                OS ordemServico = CarregarObjeto();

                this.client.CadastrarOrdemServico(ordemServico);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void EditarOrdemServico()
        {
            try
            {
                var ordemServico = this.client.ConsultarOrdemServico(873);
                ordemServico.Atividade = "Editado";
                this.client.EditarOrdemServico(ordemServico);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void ExcluirOrdemServico()
        {
            try
            {
                OS ordemServico = new OS { Codigo = 43 };
                this.client.ExcluirOrdemServico(ordemServico);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        private static OS CarregarObjeto()
        {
            OS ordemServico = new OS();
            ordemServico.Status = new Status { Codigo = 1 };
            ordemServico.Cliente = new Cliente { Codigo = 1 };
            ordemServico.Empresa = new Empresa { Codigo = "99" };
            ordemServico.Filial = new Filial { Codigo = "99" };
            ordemServico.Projeto = new Projeto { Codigo = 2 };
            ordemServico.TipoHora = new TipoHora { Codigo = 1 };
            ordemServico.Funcionario = new Funcionario { Codigo = 1 };
            ordemServico.Faturado = "2";
            ordemServico.Data = DateTime.Now;
            ordemServico.Inicio = "0800";
            ordemServico.Fim = "1800";
            ordemServico.Traslado = "0100";
            ordemServico.Atividade = "test";
            ordemServico.Observacao = "test";
            return ordemServico;
        }
    }
}
