using Murta.OrdemServico.Dal.Interfaces;
using Murta.OrdemServico.Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Murta.Utils.Dal.Exceptions;
using Murta.OrdemServico.Dto;

namespace Murta.OrdemServico.Bll
{
    public class ClienteBusiness
    {
        protected IClienteRepository clienteRepository = null;

        public ClienteBusiness(DbConnection db)
        {
            this.clienteRepository = new ClienteRepository(db);
        }

        public List<Cliente> Listar()
        {
            var clientes = this.clienteRepository.Listar();
            return clientes;
        }
    }
}
