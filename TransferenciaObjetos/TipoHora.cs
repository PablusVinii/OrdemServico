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
// Data: 20/06/2014
// ********************************************************************* 
// Entidade Tipo de hora
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace TransferenciaObjetos
{
    public class TipoHora
    {
        public Empresa Empresa { get; set; }
        public Filial Filial { get; set; }
        [Required(ErrorMessage="A escolha do tipo de hora é obrigatória")]
        public int Codigo { get; set; }
        [Display(Name = "Tipo de Hora")]
        public string Descricao { get; set; }
    }
}
