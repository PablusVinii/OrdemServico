using Negocio;
using Ordem_servico.App_Start;
using Ordem_servico.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
// Data: 28/05/2014
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
    public class AgendamentoController : Controller
    {

        //
        // GET: /Agendamento/

        public ActionResult Index()
        {
            try
            {

                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];


                ViewBag.Title = "Consultar Agendamentos - Agendamentos";
                Conexao.Ativar(true);
                List<Funcionario> lista = new FuncionarioBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                List<SelectListItem> listaSelecionavel = new List<SelectListItem>();

                SelectListItem itemDefault = new SelectListItem();
                itemDefault.Value = "0";
                itemDefault.Text = "Selecione um item";
                listaSelecionavel.Add(itemDefault);

                foreach (Funcionario item in lista)
                {
                    SelectListItem itemLista = new SelectListItem();
                    itemLista.Text = item.Nome;
                    itemLista.Value = item.Codigo.ToString();
                    if (umUsuario.IsAdministrador)
                    {
                        listaSelecionavel.Add(itemLista);
                    }
                    else
                    {
                        if (umUsuario.Funcionario.Codigo == item.Codigo)
                        {
                            listaSelecionavel.Add(itemLista);
                        }
                    }
                }

                ViewBag.Funcionarios = listaSelecionavel;

                if (Session["IdFuncionario"] != null)
                {
                    ViewBag.Argumento = "ps";
                    ViewBag.Funcionario = (int)Session["IdFuncionario"];
                }
                else
                {
                    if (!umUsuario.IsAdministrador)
                    {
                        ViewBag.Argumento = "ps";
                        ViewBag.Funcionario = umUsuario.Funcionario.Codigo;
                    }
                }

                return View();
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

        [HttpPost]
        public JsonResult PegarAgendamentos(int Funcionarios)
        {
            try
            {
                Session["IdFuncionario"] = Funcionarios;
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                AgendamentoBUS umAgendamentoBUS = new AgendamentoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                List<Agendamento> agendamentos = null;

                if (umUsuario.IsAdministrador)
                {
                    agendamentos = umAgendamentoBUS.Listar(Funcionarios);
                }
                else
                {
                    if (umUsuario.Funcionario.Codigo == Funcionarios)
                    {
                        agendamentos = umAgendamentoBUS.Listar(Funcionarios);
                    }
                }

                var jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(agendamentos);
                return Json(json, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(null);
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
        // GET: /Agendamento/Details/5

        public ActionResult Details(int id)
        {
            try
            {

                ViewBag.Title = "Detalhes - Agendamentos";
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                IAgendamentoNegocio umAgendamentoNegocio = new AgendamentoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                Agendamento umAgendamento = umAgendamentoNegocio.Consultar(id);

                if (!umUsuario.IsAdministrador)
                {
                    if (umUsuario.Funcionario.Codigo == umAgendamento.Funcionario.Codigo)
                    {
                        return View(umAgendamento);
                    }

                    return RedirectToAction("Index", new { st = "er" });
                }

                return View(umAgendamento);
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
        // GET: /Agendamento/Create

        public ActionResult Create()
        {
            try
            {
                ViewBag.Title = "Cadastro - Agendamentos";
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                Conexao.Ativar(true);
                var agendamentoConsultor = new AgendamentosConsultor();
                agendamentoConsultor.Clientes = new ClienteBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();

                if (umUsuario.IsAdministrador)
                {
                    agendamentoConsultor.Funcionarios = new FuncionarioBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                }
                else
                {
                    INegocio<Funcionario, int> umFuncBUS = new FuncionarioBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                    List<Funcionario> funcionario = new List<Funcionario>();
                    funcionario.Add(umFuncBUS.Consultar(umUsuario.Funcionario.Codigo));
                    agendamentoConsultor.Funcionarios = funcionario;
                }
                agendamentoConsultor.Cliente = new Cliente();
                agendamentoConsultor.Funcionario = new Funcionario();
                agendamentoConsultor.Agendamentos[0].Todos = true;

                agendamentoConsultor.Agendamentos[0].Status = new Status { Codigo = 1 };
                ViewBag.Situacoes = CarregarStatus(umUsuario, agendamentoConsultor.Agendamentos[0]);
                return View(agendamentoConsultor);
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
        // POST: /Agendamento/Create

        [HttpPost]
        public ActionResult Create(AgendamentosConsultor umAgendamentoConsultor)
        {
            try
            {
                Conexao.Ativar(true);

                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];

                if (!umUsuario.IsAdministrador)
                {
                    umAgendamentoConsultor.Funcionario = umUsuario.Funcionario;
                }

                IAgendamentoNegocio umAgendamentoBUS = new AgendamentoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);

                if (umAgendamentoConsultor.Agendamentos[0].DataFim == null)
                {
                    umAgendamentoConsultor.Agendamentos[0].Cliente = umAgendamentoConsultor.Cliente;
                    umAgendamentoConsultor.Agendamentos[0].Funcionario = umAgendamentoConsultor.Funcionario;
                    umAgendamentoConsultor.Agendamentos[0].Status = new Status { Codigo = 1 };
                    umAgendamentoConsultor.Agendamentos[0].DataPrevista = umAgendamentoConsultor.Agendamentos[0].DataDe;
                    umAgendamentoBUS.Cadastrar(umAgendamentoConsultor.Agendamentos[0]);
                }
                else
                {

                    foreach (var umAgendamento in umAgendamentoConsultor.Agendamentos)
                    {
                        List<DateTime> diaSelecionado = ManipulaDias.PegarDias(umAgendamento);

                        if (diaSelecionado.Count != 0)
                        {
                            foreach (DateTime data in diaSelecionado)
                            {
                                umAgendamento.Cliente = umAgendamentoConsultor.Cliente;
                                umAgendamento.Funcionario = umAgendamentoConsultor.Funcionario;
                                umAgendamento.DataPrevista = data.ToString("dd/MM/yyyy");
                                umAgendamentoBUS.Cadastrar(umAgendamento);
                            }
                        }
                        else
                        {
                            return RedirectToAction("Index", new { st = "sd" });
                        }
                    }
                }

                Session["IdFuncionario"] = umAgendamentoConsultor.Funcionario.Codigo;
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
        // GET: /Agendamento/Edit/5

        public ActionResult Edit(int id)
        {
            try
            {

                ViewBag.Title = "Edição - Agendamentos";

                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];

                ViewBag.Clientes = new ClienteBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                ViewBag.Status = new StatusBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();

                IAgendamentoNegocio umAgendamentoNegocio = new AgendamentoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                Agendamento umAgendamento = umAgendamentoNegocio.Consultar(id);

                if (!umUsuario.IsAdministrador)
                {
                    if (umUsuario.Funcionario.Codigo == umAgendamento.Funcionario.Codigo)
                    {
                        return View(umAgendamento);
                    }

                    return RedirectToAction("Index", new { st = "er" });
                }

                return View(umAgendamento);
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
        // POST: /Agendamento/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Agendamento umAgendamento)
        {
            try
            {
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                IAgendamentoNegocio umAgendamentoBUS = new AgendamentoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                umAgendamento.Funcionario = new Funcionario();
                umAgendamento.Funcionario.Codigo = Convert.ToInt32(Session["IdFuncionario"].ToString());
                umAgendamento.Empresa = umUsuario.Funcionario.Empresa;
                umAgendamento.Filial = umUsuario.Funcionario.Filial;
                umAgendamento.Codigo = id;

                if (umUsuario.IsAdministrador)
                {
                    umAgendamentoBUS.Editar(umAgendamento);
                }
                else
                {
                    if (umUsuario.Funcionario.Codigo == umAgendamento.Funcionario.Codigo)
                    {
                        umAgendamentoBUS.Editar(umAgendamento);
                        return RedirectToAction("Index", new { st = "ok" });
                    }
                    else
                    {
                        return RedirectToAction("Index", new { st = "er" });
                    }
                }

                return RedirectToAction("Index", new { st = "ok" });
            }
            catch
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
        // GET: /Agendamento/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {

                ViewBag.Title = "Excluir - Agendamentos";

                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];

                ViewBag.Clientes = new ClienteBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                ViewBag.Status = new StatusBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();

                IAgendamentoNegocio umAgendamentoNegocio = new AgendamentoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                Agendamento umAgendamento = umAgendamentoNegocio.Consultar(id);


                if (!umUsuario.IsAdministrador)
                {
                    if (umUsuario.Funcionario.Codigo == umAgendamento.Funcionario.Codigo)
                    {
                        return View(umAgendamento);
                    }

                    return RedirectToAction("Index", new { st = "er" });
                }

                return View(umAgendamento);
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
        // POST: /Agendamento/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Agendamento umAgendamento)
        {
            int IdFuncionario = 0;

            try
            {
                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                IAgendamentoNegocio umAgendamentoBUS = new AgendamentoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                umAgendamento.Funcionario = umUsuario.Funcionario;
                umAgendamento.Empresa = umUsuario.Funcionario.Empresa;
                umAgendamento.Filial = umUsuario.Funcionario.Filial;
                umAgendamento.Codigo = id;
                IdFuncionario = umAgendamento.Funcionario.Codigo;

                if (umUsuario.IsAdministrador)
                {
                    umAgendamentoBUS.Excluir(umAgendamento);
                }
                else
                {
                    if (umUsuario.Funcionario.Codigo == umAgendamento.Funcionario.Codigo)
                    {
                        umAgendamentoBUS.Excluir(umAgendamento);
                        ViewBag.Argumento = "ps";
                        ViewBag.Funcionario = IdFuncionario;
                        return RedirectToAction("Index", new { st = "ok" });
                    }
                    else
                    {
                        ViewBag.Argumento = "ps";
                        ViewBag.Funcionario = IdFuncionario;
                        return RedirectToAction("Index", new { st = "er" });
                    }
                }

                ViewBag.Argumento = "ps";
                ViewBag.Funcionario = IdFuncionario;
                return RedirectToAction("Index", new { st = "ok" });
            }
            catch
            {
                ViewBag.Argumento = "ps";
                ViewBag.Funcionario = IdFuncionario;
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

        public ActionResult AlterarStatus(int id)
        {
            try
            {

                ViewBag.Title = "Alterar Status - Agendamentos";

                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];

                IAgendamentoNegocio umAgendamentoNegocio = new AgendamentoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);
                Agendamento umAgendamento = umAgendamentoNegocio.Consultar(id);
                umAgendamento.DataConclusao = umAgendamento.DataPrevista;
                umAgendamento.InicioConclusao = umAgendamento.InicioPrevisto;
                umAgendamento.FimConclusao = umAgendamento.FimPrevisto;
                umAgendamento.TrasladoConclusao = umAgendamento.TrasladoPrevisto;


                List<SelectListItem> listaSelecionavel = CarregarStatus(umUsuario, umAgendamento);

                if (umUsuario.IsAdministrador)
                {
                    ViewBag.Status = listaSelecionavel;
                    return View(umAgendamento);
                }
                else
                {
                    if (umUsuario.Funcionario.Codigo == umAgendamento.Funcionario.Codigo)
                    {
                        ViewBag.Status = listaSelecionavel;
                        return View(umAgendamento);
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

        private static List<SelectListItem> CarregarStatus(Usuario umUsuario, Agendamento umAgendamento)
        {
            List<SelectListItem> listaSelecionavel = new List<SelectListItem>();

            IStatusNegocio umStatusBUS = new StatusBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);

            List<Status> listaStatus = umStatusBUS.Listar();

            foreach (Status status in listaStatus)
            {
                SelectListItem item = new SelectListItem();
                item.Value = status.Codigo.ToString();
                item.Text = status.Descricao;

                if (umAgendamento.Status.Codigo == status.Codigo)
                {
                    item.Selected = true;
                }

                listaSelecionavel.Add(item);
            }
            return listaSelecionavel;
        }

        [HttpPost]
        public ActionResult AlterarStatus(int id, FormCollection collection)
        {

            int idFucnionario = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    Conexao.Ativar(true);
                    Usuario umUsuario = (Usuario)Session["UsuarioLogado"];
                    IAgendamentoNegocio umAgendamentoNegocio = new AgendamentoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);

                    Agendamento umAgendamento = umAgendamentoNegocio.Consultar(id);
                    umAgendamento.DataConclusao = Convert.ToDateTime(collection[1].ToString()).ToString("dd/MM/yyyy");
                    umAgendamento.InicioConclusao = collection[2].ToString();
                    umAgendamento.FimConclusao = collection[3].ToString();
                    umAgendamento.TrasladoConclusao = collection[4].ToString();
                    umAgendamento.Status = new Status { Codigo = Convert.ToInt32(collection[5].ToString()) };
                    idFucnionario = umAgendamento.Funcionario.Codigo;
                    
                    if (umUsuario.IsAdministrador)
                    {
                        umAgendamentoNegocio.Editar(umAgendamento);
                        umAgendamento = umAgendamentoNegocio.Consultar(id);
                        this.ConfigurarEmail(umAgendamento);
                        return RedirectToAction("Index", new { st = "ok" });
                    }
                    else
                    {
                        if (umUsuario.Funcionario.Codigo == umAgendamento.Funcionario.Codigo)
                        {
                            umAgendamentoNegocio.Editar(umAgendamento);
                            umAgendamento = umAgendamentoNegocio.Consultar(id);
                            this.ConfigurarEmail(umAgendamento);
                            return RedirectToAction("Index", new { st = "ok" });
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

        public ActionResult GerarOS(int id)
        {
            try
            {

                ViewBag.Title = "Gerar Ordem de Serviço - Agendamentos";

                Conexao.Ativar(true);
                Usuario umUsuario = (Usuario)Session["UsuarioLogado"];

                IAgendamentoNegocio umAgendamentoNegocio = new AgendamentoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial);

                Agendamento umAgendamento = umAgendamentoNegocio.Consultar(id);
                OrdemServico umaOS = new OrdemServico();
                umaOS.Clientes = new ClienteBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                umaOS.Cliente = umAgendamento.Cliente;
                umaOS.Situacoes = new StatusOrdemServicoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                umaOS.Projetos = new ProjetoBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Pesquisar(umaOS.Cliente.Codigo);
                umaOS.Projeto = new Projeto();
                umaOS.TipoHoras = new TipoHoraBUS(Conexao.Instacia, umUsuario.Funcionario.Empresa, umUsuario.Funcionario.Filial).Listar();
                umaOS.TipoHora = new TipoHora();
                umaOS.Data = umAgendamento.DataPrevista;
                umaOS.Inicio = umAgendamento.InicioPrevisto;
                umaOS.Fim = umAgendamento.FimPrevisto;
                umaOS.Traslado = umAgendamento.TrasladoPrevisto;

                Session["FuncAgendamento"] = umAgendamento.Funcionario;

                if (umUsuario.IsAdministrador)
                {
                    return View(umaOS);
                }
                else
                {
                    if (umAgendamento.Funcionario.Codigo == umUsuario.Funcionario.Codigo)
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

        public void ConfigurarEmail(Agendamento umAgendamento)
        {
            string assunto = "VISITA " + umAgendamento.Cliente.Nome;
            string mensagem = string.Empty;

            using (StreamReader streamReader = new StreamReader(ConfigurationManager.AppSettings["LayoutEmail"].ToString(), Encoding.UTF8))
            {
                mensagem = streamReader.ReadToEnd();
            }

            mensagem = mensagem.Replace("{data}", umAgendamento.DataPrevista.ToString());
            mensagem = mensagem.Replace("{inicio}", umAgendamento.InicioPrevisto);
            mensagem = mensagem.Replace("{fim}", umAgendamento.FimPrevisto);
            mensagem = mensagem.Replace("{traslado}", umAgendamento.TrasladoPrevisto);
            mensagem = mensagem.Replace("{funcionario}", umAgendamento.Funcionario.Nome);
            mensagem = mensagem.Replace("{situacao}", umAgendamento.Status.Descricao);
            mensagem = mensagem.Replace("{resumo}", umAgendamento.ResumoAgendamento);
            mensagem = mensagem.Replace("{empresa}", umAgendamento.Cliente.RazaoSocial);
            mensagem = mensagem.Replace("{cliente}", umAgendamento.Cliente.Nome);
            mensagem = mensagem.Replace("{cnpj}", umAgendamento.Cliente.CNPJ);
            mensagem = mensagem.Replace("{ie}", umAgendamento.Cliente.IE);
            mensagem = mensagem.Replace("{contato}", umAgendamento.Cliente.Contato);
            mensagem = mensagem.Replace("{homepage}", umAgendamento.Cliente.HomePage);

            string endereco = string.Empty;

            if (!string.IsNullOrEmpty(umAgendamento.Cliente.Endereco.Logradouro))
            {
                endereco += umAgendamento.Cliente.Endereco.Logradouro + " ";
            }

            if (!string.IsNullOrEmpty(umAgendamento.Cliente.Endereco.Numero))
            {
                endereco += umAgendamento.Cliente.Endereco.Numero + " ";
            }

            if (!string.IsNullOrEmpty(umAgendamento.Cliente.Endereco.CEP))
            {
                endereco += umAgendamento.Cliente.Endereco.CEP + " ";
            }

            if (!string.IsNullOrEmpty(umAgendamento.Cliente.Endereco.Bairro))
            {
                endereco += umAgendamento.Cliente.Endereco.Bairro + " ";
            }

            if (!string.IsNullOrEmpty(umAgendamento.Cliente.Endereco.Municipio))
            {
                endereco += umAgendamento.Cliente.Endereco.Municipio;
            }

            mensagem = mensagem.Replace("{endereco}", endereco);

            mensagem = mensagem.Replace("{telefone}", "(" + umAgendamento.Cliente.Telefone.DDD + ") " + umAgendamento.Cliente.Telefone.Numero);
            mensagem = mensagem.Replace("{ano}", DateTime.Now.Year.ToString());

            TRS.Apoio.Email umEmailCorporativo = new TRS.Apoio.Email();
            umEmailCorporativo.AddRemetente(ConfigurationManager.AppSettings["EmailRemetente"].ToString());
            umEmailCorporativo.AddDestinatario(umAgendamento.Funcionario.Email.WebMail);
            umEmailCorporativo.AddDestinatario(umAgendamento.Cliente.Email.WebMail);
            umEmailCorporativo.AddDestinatario(ConfigurationManager.AppSettings["EmailAdministrativo"].ToString());
            umEmailCorporativo.AddDestinatarioComCopiaOculta(ConfigurationManager.AppSettings["EmailDiretoriaTecnica"].ToString());
            umEmailCorporativo.AddMensagem(assunto, mensagem);
            umEmailCorporativo.Enviar();
        }

    }
}
