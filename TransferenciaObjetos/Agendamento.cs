using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TransferenciaObjetos.Pessoas;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 26/05/2014
// ********************************************************************* 
// Entidade Agendamento
//
// ********************************************************************* 
// Data última alteração: 10/11/2014 
// Últimas alterações: Mudança de nome de campos. Retirada de campos da view.
//
// ********************************************************************* 

namespace TransferenciaObjetos
{
    public class Agendamento 
    {
        [Display(Name = "Código")]
        public int Codigo { get; set; }
        public Empresa Empresa { get; set; }
        public Filial Filial { get; set; }
        [Display(Name = "Recurso")]
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public Status Status { get; set; }
        [Display(Name="Resumo do Agendamento")]
        public string ResumoAgendamento { get; set; }
        [Display(Name="Data de:")]
        [Required(ErrorMessage = "O campo Data De é obrigatório")]
        public string DataDe { get; set; }
        [Display(Name = "Data fim:")]
        public string DataFim { get; set; }
        [Display(Name = "Início :")]
        [Required(ErrorMessage="O campo Início é obrigatório")]
        public string InicioPrevisto { get; set; }
        [Display(Name = "Fim :")]
        [Required(ErrorMessage="O campo Fim é obrigatório")]
        public string FimPrevisto { get; set; }
        [Display(Name = "Traslado :")]
        [Required(ErrorMessage="O campo Traslado é obrigatório")]
        public string TrasladoPrevisto { get; set; }
        [Display(Name = "Data Prevista:")]
        public string DataPrevista { get; set; }
        [Display(Name="Data de Conclusão")]
        public string DataConclusao { get; set; }
        [Display(Name="Início da Conclusão")]
        [Required(ErrorMessage="O campo Início da Conclusão é obrigatório")]
        public string InicioConclusao { get; set; }
        [Display(Name="Fim da Conclusão")]
        [Required(ErrorMessage="O campo Fim da Conclusão é obriatório")]
        public string FimConclusao { get; set; }
        [Display(Name="Traslado da Conclusão")]
        [Required(ErrorMessage="O campo Traslado Conclusão é obrigatório")]
        public string TrasladoConclusao { get; set; }
        [Display(Name="Todos")]
        public bool Todos { get; set; }
        [Display(Name="Segunda-feira")]
        public bool Segunda { get; set; }
        [Display(Name="Terça-feira")]
        public bool Terca { get; set; }
        [Display(Name="Quarta-feira")]
        public bool Quarta { get; set; }
        [Display(Name="Quinta-feira")]
        public bool Quinta { get; set; }
        [Display(Name="Sexta-feira")]
        public bool Sexta { get; set; }
        [Display(Name="Sábado")]
        public bool Sabado { get; set; }
        [Display(Name="Domingo")]
        public bool Domingo { get; set; }
    }
}
