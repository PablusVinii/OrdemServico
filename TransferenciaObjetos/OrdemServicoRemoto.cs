using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 12/08/2014
// ********************************************************************* 
// Decorator da Entidade OrdemServico 
//
// *********************************************************************
//
// ********************************************************************* 

namespace TransferenciaObjetos
{
    public class OrdemServicoRemoto
    {
        public OrdemServico OrdemServico { get; set; }

        [Display(Name="Data Início")]
        public DateTime DataInicio { get; set; }

        [Display(Name="Data Fim")]
        public DateTime DataFim { get; set; }

        [Display(Name="Total")]
        [Required(ErrorMessage = "O campo Total é obrigatório")]
        public string Total { get; set; }
    }
}
