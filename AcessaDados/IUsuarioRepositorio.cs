using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos.Autenticacao;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 15/05/2014
// ********************************************************************* 
// Interface par autenticação no sistema 
//
// ********************************************************************* 
// Data última alteração: 
//
// ********************************************************************* 

namespace AcessaDados
{
    public interface IUsuarioRepositorio:IRepositorio<Usuario,string>
    {
        Usuario Login(string nomeUsuario, string senha);

        void AlterarSenha(Usuario obj);
    }
}
