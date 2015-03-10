using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
// Entidade Cliente 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace TransferenciaObjetos
{
    public class Cliente
    {
        [Required(ErrorMessage="A escolha do cliente é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A escolha do cliente é obrigatória")]
        public int Codigo { get; set; }
        [Display(Name="Nome do Cliente")]
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public Email Email { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public string Contato { get; set; }
        public string HomePage { get; set; }
    }
}
