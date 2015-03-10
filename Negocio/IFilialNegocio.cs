using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;

namespace Negocio
{
    interface IFilialNegocio:INegocio<Filial, string>
    {
        List<Filial> Listar(string empresa);
    }
}
