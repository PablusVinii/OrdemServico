using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Murta.QueryFactor;
using Murta.QueryFactor.Annotations;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 12/05/2014
// ********************************************************************* 
// Entidade Empresa
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace TransferenciaObjetos
{
    [Table(NameTable="SYS_COMPANY")]
    public  class Empresa
    {
        [Display(Name="Código")]
        [Column(NameColumn="EMPRESA")]
        public string Codigo { get; set; }

        [Display(Name="Empresa")]
        [Column(NameColumn="NOME")]
        public string Nome { get; set; }
    }
}
