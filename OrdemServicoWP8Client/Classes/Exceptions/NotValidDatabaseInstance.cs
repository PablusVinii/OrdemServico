using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServicoWP8Client.Classes.Exceptions
{
    public class NotValidDatabaseInstance:Exception
    {
        public NotValidDatabaseInstance()
            : base("Instancia nula ou inválida")
        {

        }
    }
}
