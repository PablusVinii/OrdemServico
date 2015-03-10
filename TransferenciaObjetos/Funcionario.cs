using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos.Autenticacao;
using TransferenciaObjetos.Financeiro;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 12/05/2014
// ********************************************************************* 
// Entidade Funcionario
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace TransferenciaObjetos.Pessoas
{

    public class Funcionario
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "A escolha do recurso é obrigatória")]
        [RegularExpression("([0-9]+)", ErrorMessage = "A escolha do recurso é obrigatória")]
        public int Codigo { get; set; }

        public Empresa Empresa { get; set; }

        public Filial Filial { get; set; }

        [Display(Name = "Recurso")]
        public string Nome { get; set; }

        [Display(Name="Situação")]
        public string Status { get; set; }

        [Display(Name="Nome Reduzido")]
        public string Reduzido { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data de Admissão")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataAdmissao { get; set; }

        [Display(Name="Data de Emissão")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataEmissao { get; set; }

        public Email Email { get; set; }

        public List<Telefone> Telefones { get; set; }

        public Setor Setor { get; set; }

        public Cargo Cargo { get; set; }

        public Habilitacao Habilitacao { get; set; }

        public Banco Banco { get; set; }

        [Display(Name="Observação")]
        public string Observacao { get; set; }

        public Usuario Usuario { get; set; }

        [Display(Name = "Data de Criação")]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}")]
        public DateTime DataCriacao { get; set; }
    }
}
