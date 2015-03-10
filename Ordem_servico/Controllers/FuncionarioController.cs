using Negocio;
using Ordem_servico.App_Start;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransferenciaObjetos;
using TransferenciaObjetos.Autenticacao;
using TransferenciaObjetos.Pessoas;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 14/05/2014
// ********************************************************************* 
// Controlador da entidade Funcioanrio
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Ordem_servico.Controllers
{
    [SessionAuthorize]
    public class FuncionarioController : Controller
    {
        //
        // GET: /Funcionario/

        public ActionResult Index()
        {
            try
            {
                ViewBag.Title = "Listar - Recursos";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                INegocio<Funcionario, int> umFuncBUS = new FuncionarioBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                List<Funcionario> lista = new List<Funcionario>();

                if (umUsuario.IsAdministrador)
                {
                    lista.AddRange(umFuncBUS.Listar());
                }
                else
                {
                    Funcionario umFuncionario = umFuncBUS.Consultar(umUsuario.Funcionario.Codigo);
                    lista.Add(umFuncionario);
                }

                return View(lista);
            }
            catch(Exception ex)
            {
                return View();
            }
            finally
            {
                if(Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // GET: /Funcionario/Details/5

        public ActionResult Details(int id)
        {
            try
            {
                ViewBag.Title = "Detalhes - Recursos";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                INegocio<Funcionario, int> umFuncBUS = new FuncionarioBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                Funcionario umFuncionario = null;

                if (umUsuario.IsAdministrador)
                {
                    umFuncionario = umFuncBUS.Consultar(id);
                }
                else
                {
                    if (umUsuario.Funcionario.Codigo == id)
                    {
                        umFuncionario = umFuncBUS.Consultar(id);
                    }
                }

                if(umFuncionario != null)
                {
                    return View(umFuncionario);
                }

                return RedirectToAction("Index", new { st = "er" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if(Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // GET: /Funcionario/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Funcionario/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Funcionario/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Funcionario/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Funcionario/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Funcionario/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
