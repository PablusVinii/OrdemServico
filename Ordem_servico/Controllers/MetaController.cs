using FastReport.Web;
using FirebirdSql.Data.FirebirdClient;
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
using TRS.Apoio;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 05/08/2014
// ********************************************************************* 
// Controlador da entidade Metas
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Ordem_servico.Controllers
{
    [SessionAuthorize]
    public class MetaController : Controller
    {
        //
        // GET: /Meta/

        public ActionResult Index()
        {
            try
            {
                ViewBag.Title = "Listar - Metas";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                IMetaNegocio umaMetaBUS = new MetaBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                List<Meta> lista = new List<Meta>();

                if (umUsuario.IsAdministrador)
                {
                    lista.AddRange(umaMetaBUS.Listar());
                }
                else
                {
                    lista.AddRange(umaMetaBUS.Listar(umUsuario.Funcionario.Codigo));
                }

                return View(lista);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // GET: /Meta/Details/5

        public ActionResult Details(int id)
        {
            try
            {
                ViewBag.Title = "Detalhes - Metas";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                IMetaNegocio umaMetaBUS = new MetaBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                Meta umaMeta = null;

                if (umUsuario.IsAdministrador)
                {
                    umaMeta = umaMetaBUS.Consultar(id);
                    Session["Meta"] = umaMeta;
                    return View(umaMeta);
                }
                else
                {
                    umaMeta = umaMetaBUS.Consultar(id);

                    if (umUsuario.Funcionario.Codigo == umaMeta.Funcionario.Codigo)
                    {
                        return View(umaMeta);
                    }                       
                }

                return RedirectToAction("Index", new { st = "er" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // GET: /Meta/Create

        public ActionResult Create()
        {
            ViewBag.Title = "Cadastro - Metas";

            try 
	        {	        		     
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];

                if (umUsuario.IsAdministrador)
                {
                    this.CarregarIndicadores(umUsuario);
                    this.CarregarFuncionarios(umUsuario);
                    Meta umaMeta = new Meta();
                    return View(umaMeta);
                }
                else
                {
                    return RedirectToAction("Index", new { st = "er" });
                }
	        }           
	        catch (Exception)
	        {		
		        return RedirectToAction("Index", new { st = "er" });
	        }
            finally
            {
                if (Conexao.Instacia.State == System.Data.ConnectionState.Open)
	            {
		            Conexao.Ativar(false);
	            }
            }
        }

        //
        // POST: /Meta/Create

        [HttpPost]
        public ActionResult Create(Meta meta)        
        {
            try
             {
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                IMetaNegocio umaMetaBUS = new MetaBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                meta.DataCadastro = DateTime.Now;
                umaMetaBUS.Cadastrar(meta);
                return RedirectToAction("Index", new { st = "ok" });
            }
            catch
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // GET: /Meta/Edit/5

        public ActionResult Edit(int id)
        {
            try
            {

                ViewBag.Title = "Edição - Metas";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];

                if (umUsuario.IsAdministrador)
                {
                    this.CarregarIndicadores(umUsuario);
                    this.CarregarFuncionarios(umUsuario);

                    IMetaNegocio umaMetaBUS = new MetaBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);

                    if (umUsuario.IsAdministrador)
                    {
                        Meta umaMeta = umaMetaBUS.Consultar(id);
                        Session["Func"] = umaMeta.Funcionario;
                        return View(umaMeta);
                    }

                    return RedirectToAction("Index", new { st = "er" });
                }
                else
                {
                    return RedirectToAction("Index", new { st = "er" });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // POST: /Meta/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Meta meta)
        {
            try
            {
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                IMetaNegocio umaMetaBUS = new MetaBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                meta.Codigo = id;
                meta.Funcionario = (Funcionario)Session["Func"];
                umaMetaBUS.Editar(meta);
                return RedirectToAction("Index", new { st = "ok" });
            }
            catch
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // GET: /Meta/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                ViewBag.Title = "Detalhes - Metas";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];

                IMetaNegocio umaMetaBUS = new MetaBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);

                if (umUsuario.IsAdministrador)
                {
                    Meta umaMeta = umaMetaBUS.Consultar(id);
                    Session["Func"] = umaMeta.Funcionario;
                    return View(umaMeta);
                }

                return RedirectToAction("Index", new { st = "er" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // POST: /Meta/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Meta meta)
        {
            try
            {
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                IMetaNegocio umaMetaBus = new MetaBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                meta.Codigo = id;
                meta.Funcionario = (Funcionario)Session["Func"];
                umaMetaBus.Excluir(meta);
                return RedirectToAction("Index", new { st = "ok" });
            }
            catch
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == System.Data.ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        public ActionResult RelatorioDeApuracaoDeMetas()
        {
            try
            {
                ViewBag.Title = "Relatório de Apuração de Metas - Metas";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];

                if (umUsuario.IsAdministrador)
                {
                    IMetaNegocio umaMetaBUS = new MetaBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                    string query = "SELECT META.EMPRESA, META.FILIAL, META.CODIGO, META.DESCRICAO, META.DATACADASTRO, "+
                        "INDICADOR.CODIGO AS CODINDICADOR, INDICADOR.DESCRICAO AS DESCINDICADOR, "+
                        "FUNCIONARIOS.CODIGO AS CODFUNC, FUNCIONARIOS.NOME AS NOMEFUNC, "+
                        "PERIODO.ANO, PERIODO.MES, PERIODO.ESPERADO, 'Esperado' AS DESCESPERADO, "+
                        "PERIODO.REALIZADO, 'Realizado' AS DESCREALIZADO "+
                        "FROM PERIODO "+
                        "INNER JOIN META ON PERIODO.META = META.CODIGO "+
                        "INNER JOIN INDICADOR ON INDICADOR.CODIGO = META.INDICADOR "+
                        "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = META.FUNCIONARIO "+
                        "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = META.EMPRESA "+
                        "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = META.FILIAL "+
                        "WHERE META.FUNCIONARIO = @FUNCIONARIO";

                    Meta umaMeta = (Meta)Session["Meta"];

                    FbParameter[] parameters = new FbParameter[1];
                    parameters[0] = new FbParameter();
                    parameters[0].ParameterName = "@FUNCIONARIO";
                    parameters[0].Value = umaMeta.Funcionario.Codigo;

                    DataTable dtRelatorio = umaMetaBUS.GerarRelatorio(query, parameters);

                    if (dtRelatorio.Rows.Count != 0)
                    {
                        WebReport relatorio = Relatorio.GerarRelatorioMetas("~/Relatorios/ApuracaoMetas.frx", dtRelatorio);
                        relatorio.Width = 800;
                        relatorio.Height = 1200;
                        ViewBag.Relatorio = relatorio;
                    }
                    else
                    {
                        ViewBag.Relatorio = null;
                    }

                    return View();
                }

                return RedirectToAction("Index", new { st = "er" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                Conexao.Ativar(false);
            }

            return View();
        }

        protected void CarregarIndicadores(Usuario umUsuario)
        {
            List<Indicador> lista = new IndicadorBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
            List<SelectListItem> itensSelecionaveis = new List<SelectListItem>();

            itensSelecionaveis.Add(new SelectListItem { Value = "0", Text = "Selecione um Indicador", Selected = true });

            foreach (var indicador in lista)
            {
                SelectListItem item = new SelectListItem();
                item.Text = indicador.Descricao;
                item.Value = indicador.Codigo.ToString();
                itensSelecionaveis.Add(item);
            }

            ViewBag.Indicadores = itensSelecionaveis;
        }

        public void CarregarFuncionarios(Usuario umUsuario)
        {
            List<Funcionario> lista = new FuncionarioBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
            List<SelectListItem> itensSelecionaveis = new List<SelectListItem>();

            itensSelecionaveis.Add(new SelectListItem { Value = null, Text = "Selecione um Recurso", Selected = true });

            foreach (var funcionario in lista)
            {
                SelectListItem item = new SelectListItem();
                item.Text = funcionario.Nome;
                item.Value = funcionario.Codigo.ToString();
                itensSelecionaveis.Add(item);
            }

            ViewBag.Funcionarios = itensSelecionaveis;
        }        
    }
}
