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
// Data: 26/05/2014
// ********************************************************************* 
// Entidade Status
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace TransferenciaObjetos
{
    public  class Status
    {
        public int Codigo { get; set; }
        [Display(Name="Status do Agendamento")]
        public string Descricao { get; set; }
        public Empresa Empresa { get; set; }
        public Filial Filial { get; set; }
    }
}
