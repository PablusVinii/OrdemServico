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
// Interface de repositorio 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace AcessaDados
{
    public interface IRepositorio<T, S>
    {
        void Cadastrar(T obj);
        void Editar(T obj);
        void Excluir(T obj);
        List<T> Listar(string empresa, string filial);
        List<T> Pesquisar(string empresa, string filial, S id);
        T Consultar(string empresa, string filia, S id);
    }
}
