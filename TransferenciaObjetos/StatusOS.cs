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
// Data: 06/06/2014
// ********************************************************************* 
// Entidade StatusOS 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace TransferenciaObjetos
{
    public class StatusOS
    {
        [Display(Name = "Situação")]
        [Required(ErrorMessage = "O campo situação é obrigatório")]
        public int Codigo { get; set; }
        [Display(Name = "Situação")]
        public string Descricao { get; set; }
    }
}
