using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Murta
{    
    public class Inicializador
    {
        public static void InicializaConexao()
        { 
            string assembly = ConfigurationManager.AppSettings["ActiveDatabaseAssembly"];
            string connectionClass = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["ActiveConnectionClass"]];
            string connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["ActiveConnectionString"]].ConnectionString;

            //Murta.Dto.Connection.ConfigureConnection(connectionString: connectionString, assemblyKey: assembly, connectionClass: connectionClass);
        }
    }
}
