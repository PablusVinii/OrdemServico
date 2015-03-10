using OrdemServicoWP8Client.Classes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServicoWP8Client.Classes.Utils
{
    public class DataBaseUtils
    {
        public static void InicializarBanco()
        {
            DataBase db = DataBase.PegarBancoDeDados();

            var clientes = (from c in db.Cliente select c);
            db.Cliente.DeleteAllOnSubmit(clientes);

            var projetos = (from p in db.Projeto select p);
            db.Projeto.DeleteAllOnSubmit(projetos);

            var tiposHora = (from th in db.TipoHora select th);
            db.TipoHora.DeleteAllOnSubmit(tiposHora);

            var funcionarios = (from f in db.Funcionario select f);
            db.Funcionario.DeleteAllOnSubmit(funcionarios);

            db.SubmitChanges();

        }

        public static void ImportarDados()
        {
            // TODO Realizar importação dos dados aqui.
        }
    }
}
