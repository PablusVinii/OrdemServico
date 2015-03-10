using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransferenciaObjetos;
using TransferenciaObjetos.Autenticacao;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 14/05/2014
// ********************************************************************* 
// Controlador para acesso ao sistema
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Ordem_servico.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Entrar()
        {
            Usuario umUsuario = this.ConsultarUsuario();

            if (umUsuario != null)
            {
                Session["UsuarioLogado"] = umUsuario;
                return RedirectToAction("Index", "Home");
            }
            else
            { 
                ViewBag.Title = "Entrar - TRS Sistemas";
                umUsuario = new Usuario();
                umUsuario.Data = DateTime.Now.ToString("dd/MM/yyyy");
                return View(umUsuario);
            }
        }

        [HttpPost]
        public ActionResult Entrar(Usuario usr)
        {
            try
            {
                if (usr.NomeUsuario != null && usr.NomeUsuario.Length > 4 && usr.Senha != null && usr.Senha.Length > 3)
                {
                    Conexao.Ativar(true);
                    UsuarioBUS umUsuarioBUS = new UsuarioBUS(Conexao.Instacia, null, null);
                    Usuario usuarioAutenticado = umUsuarioBUS.Login(usr.NomeUsuario, usr.Senha);

                    if ((usuarioAutenticado != null) &&
                        (usuarioAutenticado.NomeUsuario == usr.NomeUsuario) &&
                        (usuarioAutenticado.Senha == usr.Senha))
                    {
                        if (usr.LembrarSenha)
                        {
                            GravarCookie(usuarioAutenticado);
                        }

                        Session["UsuarioLogado"] = usuarioAutenticado;
                        return RedirectToAction("Pegar", "Compartilhamento");
                    }

                    return RedirectToAction("Entrar", new { st = "ne" });
                }

                return RedirectToAction("Entrar", new { st = "iv" });
            }
            catch(Exception ex)
            {
                return RedirectToAction("Entrar", new { st = "er" });
            }
            finally
            {
                Conexao.Ativar(false);
            }
        }

        public ActionResult AlterarSenha()
        {
            ViewBag.Title = "Usuarios - Alterar Senha";

            try
            {
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                return View(umUsuario);
            }
            catch (Exception ex)
            {
                return RedirectToAction("AlterarSenha", new { st = "er" });
            }
        }

        [HttpPost]
        public ActionResult AlterarSenha(Usuario usr)
        {   
            Conexao.Ativar(true);

            try
            {
                if ((usr.NomeUsuario != string.Empty) && (usr.NomeUsuario.Length > 4 ) &&(usr.Senha != string.Empty)&&(usr.Senha.Length > 3))
                {
                    Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                    UsuarioBUS umUsuarioBUS = new UsuarioBUS(Conexao.Instacia, null, null);
                    umUsuarioBUS.AlterarSenha(usr, umUsuario); 
                    return RedirectToAction("AlterarSenha", new { st = "ok" });
                }
                else
                {
                    return RedirectToAction("AlterarSenha", new { st = "iv" });
                }

            }
            catch(Exception ex)
            {
                return RedirectToAction("AlterarSenha", new { st = "er" });
            }
            finally
            {
                Conexao.Ativar(false);
            }
        }

        public ActionResult Sair()
        {
            this.ApagarCookie();
            Session["UsuarioLogado"] = null;
            Session["IdFuncionario"] = null;
            return RedirectToAction("Entrar");
        }

        private Usuario ConsultarUsuario()
        {
            HttpCookie cookie = Request.Cookies["trs-osmng"];

            if (cookie != null)
            {
                string[] informacoes = cookie.Value.Split('.');
                Conexao.Ativar(true);
                UsuarioBUS umUsuarioBUS = new UsuarioBUS(Conexao.Instacia, null, null);
                Usuario umUsuario = umUsuarioBUS.Login(informacoes[1], informacoes[2]);
                umUsuario.Funcionario.Empresa.Codigo = informacoes[3];
                umUsuario.Funcionario.Filial.Codigo = informacoes[4];
                return umUsuario;
            }

            return null;
        }

        private void ApagarCookie()
        {
            if (Request.Cookies["trs-osmng"] != null)
            {
                HttpCookie cookie = new HttpCookie("trs-osmng");
                cookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookie);
            }
        }

        private void GravarCookie(Usuario usuarioAutenticado)
        {
           HttpCookie cookie = new HttpCookie("trs-osmng");
           cookie.Value = usuarioAutenticado.Data +"."+ usuarioAutenticado.NomeUsuario + "." + usuarioAutenticado.Senha;
           cookie.Expires = DateTime.Now.AddDays(3);
           Response.Cookies.Add(cookie);
        }
    }
}
