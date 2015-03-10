using OrdemServicoWP8Client.Classes.ObjectDomain;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServicoWP8Client.Classes.Repository
{
    public class DataBase : DataContext
    {
        public const string ConnectionString = "Data Source='isostore:Ordem_servico.sdf'";

        public DataBase()
            : base(ConnectionString)
        {

        }

        public Table<OrdemServico> OrdensServico
        {
            get
            {
                return this.GetTable<OrdemServico>();
            }
        }

        public Table<Cliente> Cliente
        {
            get
            {
                return this.GetTable<Cliente>();
            }
        }

        public Table<Funcionario> Funcionario
        {
            get
            {
                return this.GetTable<Funcionario>();
            }
        }

        public Table<Projeto> Projeto
        {
            get
            {
                return this.GetTable<Projeto>();
            }
        }

        public Table<TipoHora> TipoHora
        {
            get
            {
                return this.GetTable<TipoHora>();
            }
        }

        public static DataBase PegarBancoDeDados()
        {
            DataBase db = new DataBase();

            if (db.DatabaseExists() == false)
            {
                db.CreateDatabase();
            }

            return db;
        }
    }
}
