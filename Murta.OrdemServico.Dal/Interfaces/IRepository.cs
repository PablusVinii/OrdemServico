using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Dal.Interfaces
{
    public interface IRepository<TModel, TPrimaryKey>
    {
        List<TModel> Listar();
        TModel Consultar(TPrimaryKey id);
        void Cadastrar(TModel objeto);
        void Editar(TModel objeto);
        void Excluir(TModel objeto);
    }
}
