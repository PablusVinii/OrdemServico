using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransferenciaObjetos;

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

namespace AcessaDados
{
    public interface IProjetoRepositorio:IRepositorio<Projeto, int>
    {
        List<Projeto> Pesquisar(string empresa, string filial, string descricao);
    }
}
