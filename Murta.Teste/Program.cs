using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Murta.QueryFactory;
using Murta.QueryFactory.Annotations;
using Murta.Dto;
using Murta.OrdemServico.Dal;
using System.Configuration;
using System.Data.Common;
using System.Dynamic;
using Murta.OrdemServico.Dal.Repositories;

namespace Murta.Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            string assembly = ConfigurationManager.AppSettings["ActiveDatabaseAssembly"];
            string connectionClass = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["ActiveConnectionClass"]];
            string connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["ActiveConnectionString"]].ConnectionString;

            Connection.ConfigureConnection(connectionString: connectionString, assemblyKey: assembly, connectionClass: connectionClass);
            var connection = Connection.GetInstance();

            var clienteRepository = new ClienteRepository((DbConnection)connection);
            var clientes = clienteRepository.Listar();
            var cliente = clienteRepository.Consultar(1);
            var novoCliente = new Cliente { Codigo = 0, Nome = "esse dia foi louco" };
            clienteRepository.Cadastrar(novoCliente);
            clienteRepository.Editar(novoCliente);
            clienteRepository.Excluir(new Cliente { Codigo = 0 });            
        }
    }
}
;