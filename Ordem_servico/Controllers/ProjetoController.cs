using Negocio;
using Ordem_servico.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransferenciaObjetos;
using TransferenciaObjetos.Autenticacao;

namespace Ordem_servico.Controllers
{
    [SessionAuthorize]
    public class ProjetoController : Controller
    {
        //
        // GET: /Projeto/

        public ActionResult Index()
        {
            ViewBag.Title = "Projeto - Pesquisa de Projetos";
            return View();
        }

        //
        // GET: /Projeto/Details/5

        public ActionResult Details(int id)
        {
            try
            {
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                ViewBag.Title = "Projeto - Detalhes";
                Projeto umProjeto = new ProjetoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Consultar(id);
                return View(umProjeto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexao.Ativar(false);
            }
        }

        //
        // GET: /Projeto/Create

        public ActionResult Create()
        {

            try
            {
                ViewBag.Title = "Projeto - Cadastro";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                List<Cliente> lista = new ClienteBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                List<SelectListItem> listaClientes = new List<SelectListItem>();
                listaClientes.Add(new SelectListItem { Value = "0", Text = "Selecione um cliente" });
                foreach (Cliente cliente in lista)
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = cliente.Codigo.ToString();
                    item.Text = cliente.Nome;
                    listaClientes.Add(item);
                }
                ViewBag.Clientes = listaClientes;

                List<Meta> listaM = new MetaBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                List<SelectListItem> listaMetas = new List<SelectListItem>();
                listaMetas.Add(new SelectListItem { Value = "0", Text = "Selecione uma Meta" });
                foreach (Meta meta in listaM)
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = meta.Codigo.ToString();
                    item.Text = meta.Descricao;
                    listaMetas.Add(item);
                }

                ViewBag.Metas = listaMetas;
                return View();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexao.Ativar(false);
            }
        }

        //
        // POST: /Projeto/Create

        [HttpPost]
        public ActionResult Create(Projeto projeto)
        {
            try
            {
                Conexao.Ativar(true);

                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                IProjetoNegocio umProjetoBUS = new ProjetoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                projeto.Empresa = umUsuario.Funcionario.Empresa;
                projeto.Filial = umUsuario.Funcionario.Filial;
                umProjetoBUS.Cadastrar(projeto);
                return RedirectToAction("Index", new { st = "ok" });
            }
            catch
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                Conexao.Ativar(false);
            }
        }

        //
        // GET: /Projeto/Edit/5

        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Title = "Projeto - Edição";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                Projeto umProjeto = new ProjetoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Consultar(id);

                List<Cliente> lista = new ClienteBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                List<SelectListItem> listaClientes = new List<SelectListItem>();
                listaClientes.Add(new SelectListItem { Value = "0", Text = "Selecione um cliente" });
                foreach (Cliente cliente in lista)
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = cliente.Codigo.ToString();
                    item.Text = cliente.Nome;

                    if (cliente.Codigo == umProjeto.Cliente.Codigo)
                    {
                        item.Selected = true;
                    }

                    listaClientes.Add(item);
                }

                ViewBag.Clientes = listaClientes;

                List<Meta> listaM = new MetaBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                List<SelectListItem> listaMetas = new List<SelectListItem>();
                listaMetas.Add(new SelectListItem { Value = "0", Text = "Selecione uma Meta" });
                foreach (Meta meta in listaM)
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = meta.Codigo.ToString();
                    item.Text = meta.Descricao;

                    if ((umProjeto.Meta != null) && (umProjeto.Meta.Codigo != 0) && (umProjeto.Meta.Codigo == meta.Codigo))
                    {
                        item.Selected = true;
                    }

                    listaMetas.Add(item);
                }

                ViewBag.Metas = listaMetas;

                return View(umProjeto);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                Conexao.Ativar(false);
            }
        }

        //
        // POST: /Projeto/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Projeto projeto)
        {
            try
            {
                Conexao.Ativar(true);

                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                IProjetoNegocio umProjetoBUS = new ProjetoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                projeto.Empresa = umUsuario.Funcionario.Empresa;
                projeto.Filial = umUsuario.Funcionario.Filial;
                projeto.Codigo = id;
                umProjetoBUS.Editar(projeto);
                return RedirectToAction("Index", new { st = "ok" });
            }
            catch
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                Conexao.Ativar(false);
            }
        }

        //
        // GET: /Projeto/Delete/5

        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Projeto - Exclusão";

            try
            {
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                ViewBag.Title = "Projeto - Detalhes";
                Projeto umProjeto = new ProjetoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Consultar(id);
                return View(umProjeto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexao.Ativar(false);
            }
        }

        //
        // POST: /Projeto/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Projeto projeto)
        {
            try
            {
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                IProjetoNegocio umProjetoNegocio = new ProjetoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                projeto.Empresa = umUsuario.Funcionario.Empresa;
                projeto.Filial = umUsuario.Funcionario.Filial;
                projeto.Codigo = id;
                umProjetoNegocio.Excluir(projeto);
                return RedirectToAction("Index", new { st = "ok" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                Conexao.Ativar(false);
            }
        }

        [HttpPost]
        public ActionResult Find(string nome = "")
        {
            try
            {
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                List<Projeto> lista = new ProjetoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Pesquisar(nome);
                return PartialView("ViewProjetos", lista);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                Conexao.Ativar(false);
            }
        }

        protected override void HandleUnknownAction(string actionName)
        {
            try
            {
                this.View(actionName).ExecuteResult(this.ControllerContext);
            }
            catch (InvalidOperationException)
            {

            }
        }
    }
}
