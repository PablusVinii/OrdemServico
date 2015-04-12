using Murta.OrdemServico.Dal.Interfaces;
using Murta.OrdemServico.Dal.Repositories;
using Murta.OrdemServico.Dto;
using Murta.Utils.Dal.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Bll
{
    public class TipoHoraBusiness
    {
        protected ITipoHoraRepository tipoHoraRepository = null;

        public TipoHoraBusiness(DbConnection db)
        {
            if (db == null)
                throw new InvalidDatabaseInstanceException();

            this.tipoHoraRepository = new TipoHoraRepository(db);
        }

        public List<TipoHora> Listar()
        {
            return this.tipoHoraRepository.Listar();
        }
    }
}