using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 12/05/2014
// ********************************************************************* 
// Entidade Banco 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace TransferenciaObjetos.Financeiro
{
    public class Banco
    {
        [Display(Name="Número do Banco")]
        public string NumBanco { get; set; }
        [Display(Name="Agência")]
        public string Agencia { get; set; }
        [Display(Name="Número da Conta")]
        public string Conta { get; set; }
    }
}
