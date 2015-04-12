using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransferenciaObjetos.Autenticacao;
using Negocio;
using TransferenciaObjetos;
using System.Configuration;
using TRS.Apoio;

namespace Ordem_servico.Tests
{
    [TestClass]
    public class UsuarioTeste
    {
        private void CriaInstancia()
        {
            Conexao.StringConnection = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ToString();
            Conexao.Ativar(true);
        }

        [TestMethod]
        public void Logar()
        {
            string nomeUsuario  = "Administrador";
            string senha = "2008";
            this.CriaInstancia();
           // IUsuario umUsuarioBUS = new UsuarioBUS(Conexao.Instacia);
            //Usuario umUsuario = umUsuarioBUS.Login(nomeUsuario, senha);
        }

        [TestMethod]
        public void Criptografar()
        {
            this.CriaInstancia();
            Empresa emp = new Empresa();
            emp.Codigo = "**";

            Filial fil = new Filial();
            fil.Codigo = "**";
            UsuarioBUS umUsuarioBUS = new UsuarioBUS(Conexao.Instacia, emp, fil);

            //mudar criptografia para public
            string criptografado = Criptografia.Criptografar("2014");
        }
    }
}
