using AcessaDados;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;
using TransferenciaObjetos.Autenticacao;
using TRS.Apoio;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 14/05/2014
// ********************************************************************* 
// Entidade Usuario
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Negocio
{
    public class UsuarioBUS:INegocio<Usuario, string>
    {
        FbConnection _conexao = null;
        Empresa _empresa = null;
        Filial _filial = null;

        public UsuarioBUS(FbConnection conn, Empresa empresa, Filial filial)
        {
            this._conexao = conn;
            this._empresa = empresa;
            this._filial = filial;
        }

        public void Cadastrar(Usuario obj)
        {
            IUsuarioRepositorio umUsuarioDAO = new UsuarioDAO(this._conexao);
            umUsuarioDAO.Cadastrar(obj);
        }

        public void Editar(Usuario obj)
        {
            IUsuarioRepositorio umUsuarioDAO = new UsuarioDAO(this._conexao);
            umUsuarioDAO.Editar(obj);
        }

        public void Excluir(Usuario obj)
        {
            IUsuarioRepositorio umUsuarioDAO = new UsuarioDAO(this._conexao);
            umUsuarioDAO.Excluir(obj);
        }

        public void AlterarSenha(Usuario novosValores, Usuario usuarioCorrente)
        {
            Usuario usu = this.Login(usuarioCorrente.NomeUsuario, usuarioCorrente.Senha);

            if (usu != null)
            {
                usu.NomeUsuario = Criptografia.Criptografar(novosValores.NomeUsuario);
                usu.Senha = Criptografia.Criptografar(novosValores.Senha);
                IUsuarioRepositorio umUsuarioDAO = new UsuarioDAO(this._conexao);
                umUsuarioDAO.AlterarSenha(usu);
            }
        }

        public List<Usuario> Listar()
        {
            IUsuarioRepositorio umUsuarioDAO = new UsuarioDAO(this._conexao);
            return umUsuarioDAO.Listar(this._empresa.Codigo, this._filial.Codigo);
        }

        public List<Usuario> Pesquisar(string id)
        {
            IUsuarioRepositorio umUsuarioDAO = new UsuarioDAO(this._conexao);
            return umUsuarioDAO.Pesquisar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        public Usuario Consultar(string id)
        {
            IUsuarioRepositorio umUsuarioDAO = new UsuarioDAO(this._conexao);
            return umUsuarioDAO.Consultar(this._empresa.Codigo, this._filial.Codigo, id);
        }

        public Usuario Login(string nomeUsuario, string senha)
        {
            IUsuarioRepositorio umUsuarioDAO = new UsuarioDAO(this._conexao);
            Usuario umUsuario = umUsuarioDAO.Login(Criptografia.Criptografar(nomeUsuario), Criptografia.Criptografar(senha));
            if (umUsuario != null)
            {
                umUsuario.NomeUsuario = nomeUsuario;
                umUsuario.Senha = senha;
                return umUsuario;
            }
            else
            {
                return null;
            }
        }
    }
}
