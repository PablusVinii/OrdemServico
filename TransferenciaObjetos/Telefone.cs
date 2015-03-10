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
// Entidade Telefone 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace TransferenciaObjetos.Pessoas
{
    public enum TipoTelefone
    {
        TelefoneFixo,
        TelefoneMovel
    }

    public class Telefone
    {
        public string DDD { get; set; }
        public string Numero { get; set; }
        public TipoContato Tipo { get; set; }
    }
}
