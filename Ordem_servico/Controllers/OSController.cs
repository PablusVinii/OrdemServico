using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using TransferenciaObjetos;
using TransferenciaObjetos.Pessoas;
using Ordem_servico.App_Start;
using TransferenciaObjetos.Autenticacao;
using FastReport.Web;
using FirebirdSql.Data.FirebirdClient;
using TRS.Apoio;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 13/05/2014
// ********************************************************************* 
// Controlador da entidade OrdemServico
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: Criação da Action Filter
//
// ********************************************************************* 

namespace Ordem_servico.Controllers
{
    [SessionAuthorize]
    public class OSController : Controller
    {
        private int _limiteDiasEdicao = 3;

        //
        // GET: /OS/

        public ActionResult Index()
        {
            try
            {
                if (Session["OsFiltrada"] != null)
                {
                    ViewBag.Title = "Listar - Ordens de Serviço";
                    List<OrdemServico> lista = (List<OrdemServico>)Session["OsFiltrada"];                    
                    return View(lista);
                }
                else
                {
                    return RedirectToAction("Filter");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            finally
            {
                if (Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // GET: /OS/Details/5

        public ActionResult Details(int id)
        {
            try
            {
                ViewBag.Title = "Detalhes - Ordens de Serviço";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                INegocio<OrdemServico, int> umaOSBUS = new OrdemServicoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                OrdemServico umaOS = umaOSBUS.Consultar(id);

                this.VerificaOsRemota(ref umaOS, umUsuario);

                if (umaOS != null)
                {
                    if (umUsuario.IsAdministrador)
                    {
                        return View(umaOS);
                    }
                    else
                    {
                        if (umUsuario.Funcionario.Codigo == umaOS.Funcionario.Codigo)
                        {
                            return View(umaOS);
                        }
                        else
                        {
                            return RedirectToAction("Index", new { st = "er" });
                        }
                    }
                }
                else
                {
                    return RedirectToAction("Index", new { st = "iv" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        private void VerificaOsRemota(ref OrdemServico umaOS, Usuario usuario)
        {
            if (umaOS.Inicio.Equals("00:00") && umaOS.Fim.Equals("00:00"))
            {
                IOrdemServicoRemotoNegocio umaOrdemServicoRemotaBus = new OrdemServicoRemotoBUS(Conexao.Instacia, usuario.Funcionario.Empresa, usuario.Funcionario.Filial);
                OrdemServicoRemoto umaOsRemota = umaOrdemServicoRemotaBus.Consultar(umaOS.Codigo);
                umaOS.DataDe = umaOsRemota.DataInicio.ToString("dd/MM/yyyy");
                umaOS.DataAte = umaOsRemota.DataFim.ToString("dd/MM/yyyy");
                umaOS.Total = umaOsRemota.Total;
                umaOS.Remoto = true;
            }
        }

        //
        // GET: /OS/Create

        public ActionResult Create()
        {
            try
            {
                ViewBag.Title = "Cadastro - Ordens de Serviço";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["Usuariologado"];
                OrdemServico umaOS = new OrdemServico();
                umaOS.Clientes = new ClienteBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                umaOS.Cliente = new Cliente();
                umaOS.Situacoes = new StatusOrdemServicoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                umaOS.TipoHoras = new TipoHoraBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                umaOS.TipoHora = new TipoHora();
                umaOS.Status = new StatusOS();
                umaOS.Projeto = new Projeto();
                return View(umaOS);
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

        //
        // POST: /OS/Create

        [HttpPost]
        public ActionResult Create(OrdemServico os)
        {
            try
            {
                Usuario usu = (Usuario)Session["UsuarioLogado"];
                Conexao.Ativar(true);

                if (Session["FuncAgendamento"] != null)
                {
                    os.Funcionario = (Funcionario)Session["FuncAgendamento"];
                    Session["FuncAgendamento"] = null;
                }
                else
                {
                    os.Funcionario = usu.Funcionario;
                }

                if (os.Remoto)
                {
                    IOrdemServicoRemotoNegocio umaOrdemServicoRemotoBUS;
                    OrdemServicoRemoto umaOrdemServicoRemota;
                    PrepararOsRemota(os, usu, out umaOrdemServicoRemotoBUS, out umaOrdemServicoRemota);
                    umaOrdemServicoRemotoBUS.Cadastrar(umaOrdemServicoRemota);
                }
                else
                {
                    OrdemServicoBUS umaOSBUS = new OrdemServicoBUS(Conexao.Instacia, usu.Funcionario.Empresa, usu.Funcionario.Filial);
                    umaOSBUS.Cadastrar(os);
                }

                AtualizarOS(usu, os.Data);

                return RedirectToAction("Index", new { st = "ok" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // GET: /OS/Edit/5

        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Title = "Edição - Ordens de Serviço";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                OrdemServicoBUS umaOSBUS = new OrdemServicoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);

                OrdemServico umaOS = umaOSBUS.Consultar(id);

                this.VerificaOsRemota(ref umaOS, umUsuario);

                if (umaOSBUS.VerificaPrazoEdicao(umaOS, this._limiteDiasEdicao))
                {
                    umaOS.Clientes = new ClienteBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                    umaOS.Situacoes = new StatusOrdemServicoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                    umaOS.Projetos = new ProjetoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Pesquisar(umaOS.Cliente.Codigo);
                    umaOS.TipoHoras = new TipoHoraBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();

                    if (umUsuario.IsAdministrador)
                    {
                        return View(umaOS);
                    }
                    else
                    {
                        if (umUsuario.Funcionario.Codigo == umaOS.Funcionario.Codigo)
                        {
                            return View(umaOS);
                        }
                        else
                        {
                            return RedirectToAction("Index", new { st = "er" });
                        }
                    }
                }
                else
                {
                    return RedirectToAction("Index", new { st = "tf" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // POST: /OS/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, OrdemServico os)
        {
            try
            {
                Conexao.Ativar(true);
                Usuario usu = (Usuario)Session["UsuarioLogado"];
                os.Codigo = id;
                os.Funcionario = usu.Funcionario;
                if (os.Remoto)
                {
                    IOrdemServicoRemotoNegocio umaOrdemServicoRemotoBUS;
                    OrdemServicoRemoto umaOrdemServicoRemota;
                    PrepararOsRemota(os, usu, out umaOrdemServicoRemotoBUS, out umaOrdemServicoRemota);
                    umaOrdemServicoRemotoBUS.Editar(umaOrdemServicoRemota);
                }
                else
                {
                    OrdemServicoBUS umaOSBUS = new OrdemServicoBUS(Conexao.Instacia, usu.Funcionario.Empresa, usu.Funcionario.Filial);
                    umaOSBUS.Editar(os);
                }
                AtualizarOS(usu, os.Data);
                return RedirectToAction("Index", new { st = "ok" });

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // GET: /OS/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                ViewBag.Title = "Exclusão - Ordens de Serviço";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                OrdemServicoBUS umaOSBUS = new OrdemServicoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                OrdemServico umaOS = umaOSBUS.Consultar(id);
                this.VerificaOsRemota(ref umaOS, umUsuario);

                if (umUsuario.IsAdministrador)
                {
                    return View(umaOS);
                }
                else
                {
                    if (umUsuario.Funcionario.Codigo == umaOS.Funcionario.Codigo)
                    {
                        return View(umaOS);
                    }
                    else
                    {
                        return RedirectToAction("Index", new { st = "er" });
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // POST: /OS/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, OrdemServico os)
        {
            try
            {
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"]; 
                INegocio<OrdemServico, int> umaOSBUS = new OrdemServicoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                os = umaOSBUS.Consultar(id);
                this.VerificaOsRemota(ref os, umUsuario);

                if (os.Remoto)
                {
                    IOrdemServicoRemotoNegocio umaOrdemServicoRemotoBUS;
                    OrdemServicoRemoto umaOrdemServicoRemota;
                    PrepararOsRemota(os, umUsuario, out umaOrdemServicoRemotoBUS, out umaOrdemServicoRemota);
                    umaOrdemServicoRemotoBUS.Excluir(umaOrdemServicoRemota);
                }
                else
                {                    
                    umaOSBUS.Excluir(os);
                }

                AtualizarOS(umUsuario, os.Data);
                return RedirectToAction("Index", new { st = "ok" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // /OS/ViewReport/5

        public ActionResult ViewReport(int id)
        {
            try
            {
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                OrdemServicoBUS umOrdemServicoBUS = new OrdemServicoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                OrdemServico umaOS = umOrdemServicoBUS.Consultar(id);
                this.VerificaOsRemota(ref umaOS, umUsuario);

                string query = string.Empty;
                string pathRelatorio = string.Empty;

                if (umaOS.Remoto)
                {
                    query = "SELECT O.CLIENTE, O.FUNCIONARIO, OSR.INICIO AS DATADE, OSR.FIM AS DATAATE, "+
                            "O.INICIO, O.FIM, O.TRANSLADO, OSR.TOTAL, O.ATIVIDADE, C.CODIGO AS CODIGOCLIENTE, "+
                            "C.NOME AS NOMECLIENTE, F.NOME AS NOMEFUNCIONARIO, "+
                            "F.CODIGO AS CODIGOFUNCIONARIO, F.DATACADASTRO, O.CODIGO AS CODIGOOS "+
                            "FROM (ORDEM_SERVICO O INNER JOIN CLIENTES C ON O.CLIENTE = C.CODIGO) "+
                            "INNER JOIN FUNCIONARIOS F ON O.FUNCIONARIO = F.CODIGO "+
                            "INNER JOIN ORDEM_SERVICO_REMOTO OSR ON O.CODIGO = OSR.ORDEMSERVICO "+
                            "WHERE O.CODIGO=@CODIGO";

                    pathRelatorio = "~/Relatorios/OrdensDeServicoRemoto.frx";
                }
                else
                {
                    query = "SELECT O.CLIENTE, O.FUNCIONARIO, O.DATA, O.INICIO, O.FIM, O.TRANSLADO, O.ATIVIDADE, " +
                            "C.CODIGO AS CODIGOCLIENTE, C.NOME AS NOMECLIENTE, F.NOME AS NOMEFUNCIONARIO, " +
                            "F.CODIGO AS CODIGOFUNCIONARIO, F.DATACADASTRO, O.CODIGO AS CODIGOOS " +
                            "FROM (\"ORDEM_SERVICO\" O INNER JOIN \"CLIENTES\" C ON O.CLIENTE = C.CODIGO " +
                            ") INNER JOIN \"FUNCIONARIOS\" F ON O.FUNCIONARIO = F.CODIGO " +
                            "WHERE O.CODIGO=@CODIGO";

                    pathRelatorio = "~/Relatorios/OrdensDeServico.frx";
                }

                FbParameter[] parametros = new FbParameter[1];
                parametros[0] = new FbParameter();
                parametros[0].ParameterName = "@CODIGO";

                if (umUsuario.IsAdministrador)
                {
                    GerarRelatorioOS(id, umOrdemServicoBUS, query, pathRelatorio, parametros);
                    return View();
                }
                else
                {
                    if (umUsuario.Funcionario.Codigo == umaOS.Funcionario.Codigo)
                    {
                        GerarRelatorioOS(id, umOrdemServicoBUS, query, pathRelatorio, parametros);
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Index", new { st = "er" });
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        //
        // /OS/Filter
        public ActionResult Filter()
        {
            try
            {
                ViewBag.Title = "Filtrar - Ordens de Serviço";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                OrdemServico umaOrdemServico = new OrdemServico();
                List<Cliente> listaCliente = new ClienteBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                List<Funcionario> listaFuncionarios = new FuncionarioBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                umaOrdemServico.Funcionario = new Funcionario();
                umaOrdemServico.Cliente = new Cliente();

                List<SelectListItem> listaSelectCliente = new List<SelectListItem>();
                listaSelectCliente.Add(new SelectListItem { Text = "Selecione um Cliente", Value = "0", Selected = true });

                foreach (var cli in listaCliente)
                {
                    SelectListItem itemSelecionavel = new SelectListItem();
                    itemSelecionavel.Text = cli.Nome;
                    itemSelecionavel.Value = cli.Codigo.ToString();
                    listaSelectCliente.Add(itemSelecionavel);
                }

                ViewBag.Clientes = listaSelectCliente;

                if (umUsuario.IsAdministrador)
                {
                    List<SelectListItem> listaSelectFuncionario = new List<SelectListItem>();
                    listaSelectFuncionario.Add(new SelectListItem { Text = "Selecione um Recurso", Value = "0", Selected = true });

                    foreach (var func in listaFuncionarios)
                    {
                        SelectListItem itemSelecionavel = new SelectListItem();
                        itemSelecionavel.Text = func.Nome;
                        itemSelecionavel.Value = func.Codigo.ToString();
                        listaSelectFuncionario.Add(itemSelecionavel);
                    }

                    ViewBag.Funcionarios = listaSelectFuncionario;
                }

                return View(umaOrdemServico);
            }
            catch (Exception)
            {
                return RedirectToAction("Filter", new { st = "er" });
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
        public ActionResult Filter(OrdemServico os)
        {
            try
            {
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];

                if (!umUsuario.IsAdministrador)
                {
                    os.Funcionario = umUsuario.Funcionario;
                }

                Session["FiltroOS"] = os;
                Session["OsFiltrada"] = new OrdemServicoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Pesquisar(os);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
                //return RedirectToAction("Index", new { st = ex.Message });
            }
            finally
            {
                if (Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }

            return View();
        }

        public ActionResult PegarProjetos(int id)
        {
            try
            {
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                List<Projeto> listaProjetos = new ProjetoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Pesquisar(id);

                var jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(listaProjetos);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        public ActionResult RelatorioListagemOS()
        {
            try
            {
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];

                if (umUsuario.IsAdministrador)
                {
                    Conexao.Ativar(true);
                    OrdemServicoBUS umaOrdemServicoBUS = new OrdemServicoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);

                    OrdemServico os = (OrdemServico)Session["FiltroOS"];

                    string query = "SELECT ORDEM_SERVICO.CODIGO, ORDEM_SERVICO.DATA, ORDEM_SERVICO.INICIO, "+
                                        "ORDEM_SERVICO.OBSERVACAO, ORDEM_SERVICO_REMOTO.INICIO AS DATADE, ORDEM_SERVICO_REMOTO.FIM AS DATAATE, "+
                                        "ORDEM_SERVICO_REMOTO.TOTAL, "+
                                        "ORDEM_SERVICO.FIM, ORDEM_SERVICO.TRANSLADO, ORDEM_SERVICO.ATIVIDADE, ORDEM_SERVICO.FATURADO, "+
                                        "SYS_COMPANY.EMPRESA AS CODEMPRESA, SYS_COMPANY.NOME AS NOMEEMPRESA, "+
                                        "SYS_BRANCH.FILIAL AS CODFILIAL, SYS_BRANCH.NOME AS NOMEFILIAL, "+
                                        "CLIENTES.CODIGO AS CODCLIENTE, CLIENTES.REDUZIDO AS NOMECLIENTE, "+
                                        "FUNCIONARIOS.CODIGO AS CODFUNCIONARIO, FUNCIONARIOS.NOME AS NOMEFUNCIONARIO, "+
                                        "SITUACAO_OS.CODIGO AS CODSITUACAO, SITUACAO_OS.DESCRICAO AS NOMESITUACAO "+
                                        "FROM ORDEM_SERVICO INNER JOIN CLIENTES ON CLIENTES.CODIGO = ORDEM_SERVICO.CLIENTE "+
                                        "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = ORDEM_SERVICO.FUNCIONARIO "+
                                        "INNER JOIN SITUACAO_OS ON SITUACAO_OS.CODIGO = ORDEM_SERVICO.STATUS "+
                                        "LEFT JOIN ORDEM_SERVICO_REMOTO ON ORDEM_SERVICO_REMOTO.ORDEMSERVICO = ORDEM_SERVICO.CODIGO "+
                                        "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = ORDEM_SERVICO.EMPRESA "+
                                        "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = ORDEM_SERVICO.FILIAL "+
                                        "WHERE ((ORDEM_SERVICO.EMPRESA = @EMPRESA) OR (ORDEM_SERVICO.EMPRESA = '**')) " +
                                        "AND ((ORDEM_SERVICO.FILIAL = @FILIAL) OR (ORDEM_SERVICO.FILIAL = '**')) " +
                                        "AND (ORDEM_SERVICO.DATA >= @DATADE AND ORDEM_SERVICO.DATA <= @DATAATE)";

                    FbParameter[] parametros = new FbParameter[6];
                    parametros[0] = new FbParameter();
                    parametros[0].ParameterName = "@EMPRESA";
                    parametros[0].Value = umUsuario.Funcionario.Empresa.Codigo;
                    parametros[1] = new FbParameter();
                    parametros[1].ParameterName = "@FILIAL";
                    parametros[1].Value = umUsuario.Funcionario.Filial.Codigo;
                    parametros[2] = new FbParameter();
                    parametros[2].ParameterName = "@DATADE";
                    parametros[2].Value = Convert.ToDateTime(os.DataDe);
                    parametros[3] = new FbParameter();
                    parametros[3].ParameterName = "@DATAATE";
                    parametros[3].Value = Convert.ToDateTime(os.DataAte);

                    if (os.Cliente.Codigo != 0)
                    {
                        parametros[4] = new FbParameter();
                        parametros[4].ParameterName = "@CLIENTE";
                        parametros[4].Value = os.Cliente.Codigo;
                        query += "AND ORDEM_SERVICO.CLIENTE = @CLIENTE ";
                    }

                    if (os.Funcionario.Codigo != 0)
                    {
                        parametros[5] = new FbParameter();
                        parametros[5].ParameterName = "@FUNCIONARIO";
                        parametros[5].Value = os.Funcionario.Codigo;
                        query += "AND ORDEM_SERVICO.FUNCIONARIO = @FUNCIONARIO ";
                    }

                    query += "ORDER BY ORDEM_SERVICO.DATA ASC ";

                    DataTable dtRelatorio = umaOrdemServicoBUS.GerarRelatorio(query, parametros);

                    ViewBag.Title = "Consulta Ordens de Serviço - Ordens de Serviço";

                    if (dtRelatorio.Rows.Count != 0)
                    {
                        WebReport relatorio = Relatorio.GerarRelatorioListagemOS(this.Server.MapPath("~/Relatorios/ListagemOS.frx"), dtRelatorio, parametros);
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
                else
                {
                    return RedirectToAction("Index", new { st = "er" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                if (Conexao.Instacia.State == ConnectionState.Open)
                {
                    Conexao.Ativar(false);
                }
            }
        }

        public ActionResult RelatorioDeConsultaDeHorasConsumidas()
        {
            try
            {
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                OrdemServicoBUS umaOrdemServicoBUS = new OrdemServicoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                string query = "SELECT PROJETOS.DESCRICAO AS NOMEPROJETO, CLIENTES.NOME AS NOMECLIENTE, PROJETOS.HORASGERENTE, " +
                                "PROJETOS.HORASCOORDENADOR, PROJETOS.HORASCONSULTOR, ORDEM_SERVICO.INICIO, ORDEM_SERVICO.FIM, ORDEM_SERVICO.TRANSLADO, " +
                                "SUM( ( CAST(ORDEM_SERVICO.FIM AS INTEGER) - CAST(ORDEM_SERVICO.INICIO AS INTEGER) ) + ORDEM_SERVICO.TRANSLADO) AS HORASCONSUMIDAS,  " +
                                "TIPOHORAS.DESCRICAO AS TIPOHORA, FUNCIONARIOS.NOME AS NOMEFUNCIONARIO " +
                                "FROM PROJETOS INNER JOIN ORDEM_SERVICO ON ORDEM_SERVICO.PROJETO = PROJETOS.CODIGO " +
                                "INNER JOIN TIPOHORAS ON ORDEM_SERVICO.TIPOHORA = TIPOHORAS.CODIGO " +
                                "INNER JOIN CLIENTES ON ORDEM_SERVICO.CLIENTE = CLIENTES.CODIGO " +
                                "INNER JOIN FUNCIONARIOS ON ORDEM_SERVICO.FUNCIONARIO = FUNCIONARIOS.CODIGO " +
                                "GROUP BY PROJETOS.CODIGO, PROJETOS.DESCRICAO, CLIENTES.NOME, " +
                                "PROJETOS.HORASGERENTE, PROJETOS.HORASCOORDENADOR, PROJETOS.HORASCONSULTOR, " +
                                "ORDEM_SERVICO.INICIO, ORDEM_SERVICO.FIM, ORDEM_SERVICO.TRANSLADO,TIPOHORAS.DESCRICAO, FUNCIONARIOS.NOME " +
                                "ORDER BY CLIENTES.NOME ASCENDING";

                FbParameter[] parametros = new FbParameter[1];
                DataTable dtRelatorio = umaOrdemServicoBUS.GerarRelatorio(query, parametros);

                ViewBag.Title = "Relatório de Consulta de Horas Consumidas - Ordens de Serviço";

                if (dtRelatorio.Rows.Count != 0)
                {
                    WebReport relatorio = Relatorio.GerarRelatorioConsultaDeHorasConsumidasOS(this.Server.MapPath("~/Relatorios/ConsultaDeHorasGastas.frx"), dtRelatorio);
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
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { st = "er" });
            }
            finally
            {
                Conexao.Ativar(false);
            }
        }

        private static void PrepararOsRemota(OrdemServico os, Usuario usu, out IOrdemServicoRemotoNegocio umaOrdemServicoRemotoBUS, out OrdemServicoRemoto umaOrdemServicoRemota)
        {
            umaOrdemServicoRemotoBUS = new OrdemServicoRemotoBUS(Conexao.Instacia, usu.Funcionario.Empresa, usu.Funcionario.Filial);
            umaOrdemServicoRemota = new OrdemServicoRemoto();
            os.Remoto = true;
            umaOrdemServicoRemota.OrdemServico = os;
            umaOrdemServicoRemota.DataInicio = Convert.ToDateTime(os.DataDe);
            umaOrdemServicoRemota.DataFim = Convert.ToDateTime(os.DataAte);
            umaOrdemServicoRemota.Total = os.Total;
            os.Data = os.DataDe;
            os.Inicio = "00:00";
            os.Fim = "00:00";
            os.Traslado = "00:00";
            os.Total = "00:00";
        }

        private void AtualizarOS(Usuario usu, string data)
        {
            OrdemServico paramFilters = null;

            if (Session["FiltroOS"] != null)
            {
                paramFilters = (OrdemServico)Session["FiltroOS"];
            }
            else
            {
                paramFilters = new OrdemServico();
                paramFilters.Cliente = new Cliente();
                paramFilters.DataDe = data;
                paramFilters.DataAte = data;
            }

            if (!usu.IsAdministrador)
            {
                paramFilters.Funcionario = usu.Funcionario;
            }

            Session["OsFiltrada"] = new OrdemServicoBUS(Conexao.Instacia, usu.Funcionario.Empresa, usu.Funcionario.Filial).Pesquisar(paramFilters);
        }

        private void GerarRelatorioOS(int id, OrdemServicoBUS umOrdemServicoBUS, string query, string pathRelatorio, FbParameter[] parametros)
        {
            parametros[0].Value = id;

            DataTable dtRelatorio = umOrdemServicoBUS.GerarRelatorio(query, parametros);

            WebReport relatorio = new WebReport();
            relatorio = Relatorio.GerarRelatorioOS(id, this.Server.MapPath(pathRelatorio), dtRelatorio);
            relatorio.Width = 800;
            relatorio.Height = 1200;
            ViewBag.Title = "Relatório Ordem de Serviço";
            ViewBag.Id = id;
            ViewBag.Relatorio = relatorio;
        }
    }
}
