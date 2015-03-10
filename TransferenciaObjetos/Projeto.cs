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
// Entidade Projeto
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace TransferenciaObjetos
{
    public class Projeto
    {
        public Empresa Empresa { get; set; }
        public Filial Filial { get; set; }
        [Display(Name="Código")]
        [Required(ErrorMessage="A escolha do projeto é obrigatória")]
        public int Codigo { get; set; }
        [Display(Name="Descrição")]
        [Required(ErrorMessage="O campo descrição é obrigatório")]
        public string Descricao { get; set; }
        [Display(Name="Cliente")]
        public Cliente Cliente { get; set; }
        [Display(Name="Gerente")]
        [Required(ErrorMessage="O campo Gerente é obrigatório")]
        public string HorasGerente { get; set; }
        [Display(Name="Coordenador")]
        [Required(ErrorMessage="O campo Coordenador é obrigatório")]
        public string HorasCoordenador { get; set; }
        [Display(Name="Consultor")]
        [Required(ErrorMessage="O campo Consultor é obrigatório")]
        public string HorasConsultor { get; set; }
        public Meta Meta { get; set; }
    }
}
