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
// Data: 28/07/2014
// ********************************************************************* 
// Entidade Filial
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace TransferenciaObjetos
{
    public class Indicador
    {
        public Empresa Empresa { get; set; }
        public Filial Filial { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "O campo Indicador é obrigatório")]
        public int Codigo { get; set; }
        [Display(Name="Indicador")]
        public string Descricao { get; set; }
    }
}
