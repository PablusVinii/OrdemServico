using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos.Pessoas;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 12/05/2014
// ********************************************************************* 
// Entidade Usuario 
//
// ********************************************************************* 
// Data última alteração: 03/06/2014
// Últimas alterações: Adição da propriedade IsAdministrador
//
// ********************************************************************* 

namespace TransferenciaObjetos.Autenticacao
{
    public class Usuario
    {
        public string Codigo { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage="O campo Login é obrigatório")]
        [StringLength(20, MinimumLength=5, ErrorMessage="O Login deve ter no mínimo 5 e no máximo 20 caracteres")]
        [DataType(DataType.Text)]
        public string NomeUsuario { get; set; }

        [Display(Name="Senha")]
        [Required(ErrorMessage="O campo Senha é obrigatório")]
        [StringLength(11, MinimumLength=4, ErrorMessage="A Senha deve ter no mínimo 4 e no máximo 11 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name="Repetir Senha")]
        [Required(ErrorMessage="O campo Repetir Senha é obrigatório")]
       // [System.C Compare("Senha", ErrorMessage="O valor deste campo deve ser igual ao do campo Senha")]
        [StringLength(11, MinimumLength = 4, ErrorMessage = "A Senha deve ter no mínimo 4 e no máximo 11 caracteres")]
        [DataType(DataType.Password)]
        public string RepetirSenha { get; set; }

        [Display(Name="Data de Entrada")]
        [Required(ErrorMessage="O campo Data é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string Data { get; set; }

        [Display(Name="Lembrar Senha")]
        public bool LembrarSenha { get; set; }

        public Funcionario Funcionario { get; set; }

        public bool IsAdministrador { get; set; }
    }
}
