using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServicoWP8Client.Classes.Repository.Interface
{
    public interface IRepository<TEntity, TIdentify>
    {
        List<TEntity> Listar();

        TEntity Consultar(TIdentify id);

        void Cadastrar(TEntity obj);

        void Editar(TEntity obj);

        void Excluir(TEntity obj);
    }
}
