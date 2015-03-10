using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TransferenciaObjetos.Pessoas;
using TRS.Apoio;

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
    public class Meta
    {

        public Meta()
        {
            this.Periodos = new List<Periodo>();
            Dictionary<int, string> meses = Meses.PegarMeses();
            for (int i = 1; i <= meses.Count; i++)
            {
                Periodo umPeriodo = new Periodo();
                umPeriodo.Ano = DateTime.Now.Year;
                umPeriodo.Mes = i;
                umPeriodo.NomeMes = meses[i];
                this.Periodos.Add(umPeriodo);
            }
        }

        public Empresa Empresa { get; set; }
        public Filial Filial { get; set; }
        public int Codigo { get; set; }
        [Display(Name="Descrição")]
        [Required(ErrorMessage="O campo Descrição é obrigatório")]
        public string Descricao { get; set; }
        [Display(Name="Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
        public Projeto Projeto { get; set; }
        public Indicador Indicador { get; set; }
        public Funcionario Funcionario { get; set; }
        public List<Periodo> Periodos { set; get;}
    }
}
