using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TransferenciaObjetos.Pessoas;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 12/05/2014
// ********************************************************************* 
// Entidade OrdemServico 
//
// ********************************************************************* 
// Data última alteração: 14/05/2014
// Últimas alterações: Adicionanda DataAnnotations
//
// ********************************************************************* 

namespace TransferenciaObjetos
{
    public class OrdemServico
    {
        protected List<Cliente> _listaClientes = new List<Cliente>();
        protected List<StatusOS> _listaOrdensServico = new List<StatusOS>();
        protected List<Projeto> _listaProjetos = new List<Projeto>();
        protected List<TipoHora> _listaTipoHora = new List<TipoHora>();
        string _total = string.Empty;

        [Display(Name = "Código")]
        [Required(ErrorMessage = "O campo código é obrigatório")]
        public int Codigo { get; set; }

        public Empresa Empresa { get; set; }

        public Filial Filial { get; set; }

        public Cliente Cliente { get; set; }

        public List<Cliente> Clientes
        {
            set
            {
                this._listaClientes = value;
            }
        }

        public List<StatusOS> Situacoes
        {
            set
            {
                this._listaOrdensServico = value;
            }
        }

        public List<Projeto> Projetos 
        { 
            set 
            { 
                this._listaProjetos = value; 
            } 
        }

        public List<TipoHora> TipoHoras 
        { 
            set 
            {
                this._listaTipoHora = value; 
            } 
        }

        public List<SelectListItem> ClientesSelecionaveis
        {
            get
            {
                var items = this._listaClientes.Select(c => new SelectListItem()
                                         {
                                             Text = c.Nome,
                                             Value = c.Codigo.ToString()
                                         }).ToList();

                items.Insert(0, new SelectListItem() { Text = "Selecione um valor", Value = null, Selected = true });

                return items;
            }
        }

        public List<SelectListItem> SituacacoesSelecionaveis
        {
            get
            {
                var items = this._listaOrdensServico.Select(s => new SelectListItem()
                                    {
                                        Text = s.Descricao,
                                        Value = s.Codigo.ToString()
                                    }).ToList();

                items.Insert(0, new SelectListItem() { Text = "Selecione um valor", Value = null, Selected = true });

                return items;
            }
        }

        public List<SelectListItem> ProjetoSelecionaveis 
        { 
            get 
            {
                var items = this._listaProjetos.Select(p => new SelectListItem()
                    {
                        Text = p.Descricao,
                        Value = p.Codigo.ToString()
                    }).ToList();

                items.Insert(0, new SelectListItem() { Text = "Selecione um valor", Value = null, Selected = true });

                return items;
            } 
        }

        public List<SelectListItem> TipoHoraSelecionaveis 
        { 
            get 
            {
                var items = this._listaTipoHora.Select(t => new SelectListItem() 
                    { 
                        Text = t.Descricao,
                        Value = t.Codigo.ToString()
                    }).ToList();

                items.Insert(0, new SelectListItem() { Text = "Selecione um valor", Value = null, Selected = true });

                return items; 
            }
        }

        [Display(Name = "Recurso")]
        public Funcionario Funcionario { get; set; }

        [Required(ErrorMessage = "O campo Total é obrigatório")]
        public string Total
        {
            set { this._total = value; }

            get
            {
                if (!this.Remoto)
                {
                    DateTime dtInicio = Convert.ToDateTime(this.Inicio);
                    DateTime dtFim = Convert.ToDateTime(this.Fim);
                    DateTime dtTraslado = Convert.ToDateTime(this.Traslado);

                    TimeSpan tsTotal = (dtFim - dtInicio).Add(dtTraslado.TimeOfDay);

                    DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    return origin.AddSeconds(tsTotal.TotalSeconds).ToString("hh:mm");
                }

                return this._total;
            }
        }

        public bool Faturado { get; set; }

        public bool Remoto { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "O campo Data é obrigatório")]
        public string Data { get; set; }

        [Display(Name = "Início")]
        [Required(ErrorMessage = "O campo início é obrigatório")]
        public string Inicio { get; set; }

        [Display(Name = "Fim")]
        [Required(ErrorMessage = "O campo fim é obrigatório")]
        public string Fim { get; set; }

        [Display(Name = "Traslado")]
        [Required(ErrorMessage = "O campo traslado é obrigatório")]
        public string Traslado { get; set; }

        [Required(ErrorMessage = "O campo atividade é obrigatório")]
        public string Atividade { get; set; }

        public StatusOS Status { get; set; }

        [Display(Name = "Data de:")]
        [Required(ErrorMessage = "O campo Data De é obrigatório")]
        public string DataDe { get; set; }

        [Display(Name = "Data até:")]
        [Required(ErrorMessage = "O campo Data Até é obrigatório")]
        public string DataAte { get; set; }

        [Display(Name="Observação/Despesa")]
        public string Observacao { get; set; }

        public Projeto Projeto { get; set; }

        [Display(Name="Tipo de Hora")]
        public TipoHora TipoHora { get; set; }
    }
}
