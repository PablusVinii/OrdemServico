using System;
using System.Collections.Generic;
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
// Data: 12/05/2014
// ********************************************************************* 
// Entidade Cargo 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace TransferenciaObjetos.Pessoas
{
    public enum TipoVinculo
    {
        CLT,
        PJ,
        Estagio,
        Cooperativa
    }

    public enum Formacao
    {
        FUNDAMENTAL1,
        FUNDAMENTAL2,
        MEDIO,
        SUPERIOR,
        TECNICO

    }

    public class Cargo
    {
        public string Codigo { get; set; }
        public TipoVinculo VinculoEmpregaticio { get; set; }
        public string Hierarquia { get; set; } 
        public Formacao Formacao { get; set; } 
        public List<string> Consultor { get; set; }
        public DateTime DiaPagamento { get; set; }
    }
}
