using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransferenciaObjetos;
using TransferenciaObjetos.Pessoas;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 28/05/2014
// ********************************************************************* 
// Entidade AgendamentosConsultor
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Ordem_servico.Models
{
    public class AgendamentosConsultor
    {
        public AgendamentosConsultor()
        {
            this.Agendamentos = new List<Agendamento>() { new Agendamento()};
        }

        protected List<Cliente> _clientes = new List<Cliente>();
        protected List<Funcionario> _funcionarios = new List<Funcionario>();
        public Cliente Cliente { get; set; }
        [Display(Name="Funcionário")]
        public Funcionario Funcionario { get; set; }
        public List<Cliente> Clientes 
        {
            set
            {
                this._clientes = value;
            }
        }
        public List<Funcionario> Funcionarios {
            set
            {
                this._funcionarios = value;
            }
        }
        public List<SelectListItem> ClientesSelecionaveis 
        { 
            get 
            {
                var items = this._clientes.Select(f => new SelectListItem()
                {
                    Text = f.Nome,
                    Value = f.Codigo.ToString()
                }).ToList();

                items.Insert(0, new SelectListItem() { Text = "Selecione um valor", Value = null, Selected = true });

                return items;
            } 
        }
        public List<SelectListItem> FuncionariosSelecionaveis 
        { 
            get 
            {
                var items = this._funcionarios.Select(f => new SelectListItem()
                {
                    Text = f.Nome,
                    Value = f.Codigo.ToString()
                }).ToList();

                items.Insert(0, new SelectListItem() { Text = "Selecione um valor", Value = null, Selected = true });

                return items;    
            } 
        }
        public List<Agendamento> Agendamentos { get; set; }
    }
}