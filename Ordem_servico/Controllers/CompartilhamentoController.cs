using Negocio;
using Ordem_servico.App_Start;
using Ordem_servico.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
// Data: 21/05/2014
// ********************************************************************* 
// Entidade Funcionario
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Ordem_servico.Controllers
{
    [SessionAuthorize]
    public class CompartilhamentoController : Controller
    {
        //
        // GET: /Compartilhamento/

        public ActionResult Pegar()
        {
            try
            {
                ViewBag.Title = "Pegar - Compartilhamento";
                Compartilhamento umCompartilhamento = new Compartilhamento();
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                umCompartilhamento.Empresas = new EmpresaBUS(Conexao.Instacia).Listar(umUsuario.Funcionario.Empresa.Codigo);
                umCompartilhamento.Filiais = new List<Filial>();
                return View(umCompartilhamento);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        [HttpPost]
        public ActionResult Pegar(Compartilhamento comp)
        {
            try
            {
                if ((comp.FilialId == 0)||(comp.EmpresaId != comp.FilialId))
                {
                    Conexao.Ativar(true);
                    ViewBag.Title = "Pegar - Compartilhamento";
                    Compartilhamento umCompartilhamento = new Compartilhamento();
                    Conexao.Ativar(true);
                    Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                    umCompartilhamento.Empresas = new EmpresaBUS(Conexao.Instacia).Listar(umUsuario.Funcionario.Empresa.Codigo);
                    umCompartilhamento.Filiais = new FilialBUS(Conexao.Instacia).Listar(comp.EmpresaId.ToString());
                    return View(umCompartilhamento);
                }
                else
                {
                    Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                    umUsuario.Funcionario.Empresa.Codigo = comp.EmpresaId.ToString();
                    umUsuario.Funcionario.Filial.Codigo = comp.FilialId.ToString();
                    Session["UsuarioLogado"] = umUsuario;

                    if(Request.Cookies["trs-osmng"] != null)
                    {
                        HttpCookie cookie = Request.Cookies["trs-osmng"];
                        cookie.Value += "."+ umUsuario.Funcionario.Empresa.Codigo + "." + umUsuario.Funcionario.Filial.Codigo;
                        Response.Cookies.Set(cookie);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }
    }
}
