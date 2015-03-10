using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;
// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 26/05/2014
// ********************************************************************* 
// Entidade IAgendamentoNegocio
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 
namespace Negocio
{
    public interface IAgendamentoNegocio:INegocio<Agendamento, int>
    {
        List<Agendamento> Listar(int IdFuncionario);
    }
}
