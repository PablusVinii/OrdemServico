using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Data.Common;

namespace Murta.OrdemServico.Dto
{
    public static class Connection
    {
        private static object connection = new object();

        public static void ConfigureConnection(string connectionString, string assemblyKey, string connectionClass)
        {
            var databaseAssembly = ConfigurationManager.AppSettings[assemblyKey];  
            var assembly = Assembly.LoadFrom(databaseAssembly);                                            
            var type = assembly.GetType(connectionClass);
            connection = Activator.CreateInstance(type);
            connection.GetType().GetProperty("ConnectionString").SetValue(connection, connectionString, null);

            try
            {
                connection.GetType().GetMethod("Open").Invoke(connection, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                var connectionState = connection.GetType().GetProperty("State").GetValue(connection, null);

                if (((ConnectionState)connectionState) == ConnectionState.Open)
                {
                    connection.GetType().GetMethod("Close").Invoke(connection, null);
                }
            }
        }

        public static DbConnection GetInstance()
        {
            if (connection == null)
                throw new Exception("No database connection configurated");

            return (DbConnection) connection;
        }
    }
}
