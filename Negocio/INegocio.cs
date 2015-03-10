using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public interface INegocio<T, S>
    {
        void Cadastrar(T obj);
        void Editar(T obj);
        void Excluir(T obj);
        List<T> Listar();
        List<T> Pesquisar(S id);
        T Consultar(S id);
    }
}
