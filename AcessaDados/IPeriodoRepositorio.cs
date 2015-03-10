using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransferenciaObjetos;

namespace AcessaDados
{
    public interface IPeriodoRepositorio:IRepositorio<Periodo,int>
    {
        Periodo Consultar(string empresa, string filial, int ano, int mes, int meta, int funcionario);
    }
}
