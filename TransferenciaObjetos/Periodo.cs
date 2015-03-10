using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TransferenciaObjetos.Pessoas;

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
    public class Periodo
    {
        public Empresa Empresa { get; set; }
        public Filial Filial { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public string NomeMes { get; set; }
        public Meta Meta { get; set; }
        [Required(ErrorMessage="Campo Esperado obrigatório")]
        [RegularExpression("([0-9]+)", ErrorMessage="O campo Esperado precisa ser um número")]
        public double Esperado { get; set; }
        [Required(ErrorMessage = "Campo Realizado obrigatório")]
        [RegularExpression("([0-9]+)", ErrorMessage = "O campo Realizado precisa ser um número")]
        public double Realizado { get; set; }
    }
}
