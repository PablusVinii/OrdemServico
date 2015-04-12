using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransferenciaObjetos;
using System.Configuration;
using System.Collections.Generic;
using Negocio;

namespace Ordem_servico.Tests
{
    [TestClass]
    public class TipoHoraTeste
    {

        private void CriaInstancia()
        {
            Conexao.StringConnection = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ToString();
            Conexao.Ativar(true);
        }

        [TestMethod]
        public void TesteListarTipoHora()
        {
            this.CriaInstancia();

            Empresa emp = new Empresa();
            emp.Codigo = "**";

            Filial fil = new Filial();
            fil.Codigo = "**";

            ITipoHoraNegocio umtipoHoraBUS = new TipoHoraBUS(Conexao.Instacia, emp, fil);
            List<TipoHora> lista = umtipoHoraBUS.Listar();
        }

        [TestMethod]
        public void TesteConsultarTipoHora()
        {
            this.CriaInstancia();

            Empresa emp = new Empresa();
            emp.Codigo = "**";

            Filial fil = new Filial();
            fil.Codigo = "**";

            ITipoHoraNegocio umTipoHoraBUS = new TipoHoraBUS(Conexao.Instacia, emp, fil);
            TipoHora tipoHora = umTipoHoraBUS.Consultar(2);
        }
    }
}
