using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TransferenciaObjetos;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 21/05/2014
// ********************************************************************* 
// Entidade Funcionario
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Ordem_servico.Models
{
    public class Compartilhamento
    {
        [Required(ErrorMessage="Campo Empresa obrigatório")]
        [Display(Name="Empresa")]
        public int EmpresaId { get; set; }

        [Required(ErrorMessage="Campo Filial obrigatório")]
        [Display(Name="Filial")]
        public int FilialId { get; set; }

        public IEnumerable<Empresa> Empresas { get; set; }

        public IEnumerable<Filial> Filiais { get; set; }
    }
}