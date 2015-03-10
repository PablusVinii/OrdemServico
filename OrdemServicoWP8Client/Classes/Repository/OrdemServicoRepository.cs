using OrdemServicoWP8Client.Classes.Exceptions;
using OrdemServicoWP8Client.Classes.ObjectDomain;
using OrdemServicoWP8Client.Classes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServicoWP8Client.Classes.Repository
{
    public class OrdemServicoRepository:IOrdemServicoRepository
    {
        protected DataBase DataBase = null;

        public OrdemServicoRepository(DataBase db)
        {
            if (db == null)
                throw new NotValidDatabaseInstance();

            this.DataBase = db;
        }

        public List<OrdemServico> Listar()
        {
            return (from o in this.DataBase.OrdensServico select o).ToList();
        }

        public OrdemServico Consultar(int id)
        {
            return (from o in this.DataBase.OrdensServico where o.Id == id select o).First();
        }

        public void Cadastrar(OrdemServico obj)
        {
            this.DataBase.OrdensServico.InsertOnSubmit(obj);
            this.DataBase.SubmitChanges();
        }

        public void Editar(OrdemServico obj)
        {
            this.DataBase.Refresh(RefreshMode.OverwriteCurrentValues, obj);            
        }

        public void Excluir(OrdemServico obj)
        {
            this.DataBase.OrdensServico.DeleteOnSubmit(obj);
            this.DataBase.SubmitChanges();
        }
    }
}
