using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.Utils.Dal.Exceptions
{
    public class InvalidDatabaseInstanceException:Exception
    {
        public InvalidDatabaseInstanceException ()
            : base("Instância do banco de dados não pode ser nula.")
        {

        }
    }
}
