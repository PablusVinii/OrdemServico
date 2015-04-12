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
    public class OrdemServicoBusiness
    {
        protected IOrdemServicoRepository ordemServicoRepository = null;

        public OrdemServicoBusiness(DbConnection db)
        {
            if (db == null)
                throw new InvalidDatabaseInstanceException();

            this.ordemServicoRepository = new OrdemServicoRepository(db);
        }

        public void Cadastrar(Murta.OrdemServico.Dto.OS ordemServico)
        {
            this.ordemServicoRepository.Cadastrar(ordemServico);
        }

        public void Editar(Murta.OrdemServico.Dto.OS ordemServico)
        {
            this.ordemServicoRepository.Editar(ordemServico);
        }

        public void Excluir(Murta.OrdemServico.Dto.OS ordemServico)
        {
            this.ordemServicoRepository.Excluir(ordemServico);
        }

        public Murta.OrdemServico.Dto.OS Consultar(int id)
        {
            return this.ordemServicoRepository.Consultar(id);
        }

        public List<Murta.OrdemServico.Dto.OS> Listar(DateTime? dataDe = null, DateTime? dataAte = null, Funcionario funcionario = null, Cliente cliente = null)
        {         
            var ordensServico = this.ordemServicoRepository.Listar();

            #region Se data De e Até nulo

            if (!dataDe.HasValue && !dataAte.HasValue && funcionario == null && cliente == null)
                return ordensServico;


            if (!dataDe.HasValue && !dataAte.HasValue && funcionario != null && cliente != null)
                return (from os in ordensServico
                        where os.Data >= dataDe && os.Data <= dataAte &&
                        os.Funcionario.Codigo == funcionario.Codigo && os.Cliente.Codigo == cliente.Codigo
                        select os).ToList();

            if (!dataDe.HasValue && !dataAte.HasValue && funcionario == null && cliente != null)
                return (from os in ordensServico where os.Cliente.Codigo == cliente.Codigo select os).ToList();

            if (!dataDe.HasValue && !dataAte.HasValue && cliente == null && funcionario != null)
                return (from os in ordensServico where os.Funcionario.Codigo == funcionario.Codigo select os).ToList();

            #endregion 

            #region Se data De e Até diferente de nulo

            if (dataDe.HasValue && dataAte.HasValue && funcionario != null && cliente != null)
                return (from os in ordensServico
                        where os.Data >= dataDe.Value && os.Data <= dataAte.Value &&
                            os.Funcionario.Codigo == funcionario.Codigo &&
                            os.Cliente.Codigo == cliente.Codigo
                        select os).ToList();

            if (dataDe.HasValue && dataAte.HasValue && funcionario == null && cliente == null)
                return (from os in ordensServico where os.Data >= dataDe.Value && os.Data <= dataAte.Value select os).ToList();

            if (dataDe.HasValue && dataAte.HasValue && funcionario != null && cliente == null)
                return (from os in ordensServico
                        where os.Data >= dataDe.Value && os.Data <= dataAte.Value &&
                            os.Funcionario.Codigo == funcionario.Codigo
                        select os).ToList();

            if (dataDe.HasValue && dataAte.HasValue && cliente != null && funcionario == null)
                return (from os in ordensServico
                        where os.Data >= dataDe.Value && os.Data <= dataAte.Value &&
                            os.Cliente.Codigo == cliente.Codigo
                        select os).ToList();            

            #endregion

            #region Se data De ou Até nulo            

            if (dataDe.HasValue && !dataAte.HasValue && funcionario == null && cliente != null)
                return (from os in ordensServico where os.Data >= dataDe && os.Data <= DateTime.Now && os.Cliente.Codigo == cliente.Codigo select os).ToList();

            if (dataDe.HasValue && !dataAte.HasValue && cliente == null && funcionario != null)
                return (from os in ordensServico where os.Data > dataDe.Value && os.Data <= DateTime.Now && os.Funcionario.Codigo == funcionario.Codigo select os).ToList();

            if (dataDe.HasValue && !dataAte.HasValue && cliente == null && funcionario == null)
                return (from os in ordensServico where os.Data >= dataDe && os.Data <= DateTime.Now select os).ToList();

            if (!dataDe.HasValue && dataAte.HasValue && cliente == null && funcionario == null)
                return (from os in ordensServico where os.Data >= DateTime.Now && os.Data <= dataAte select os).ToList();

            if (!dataDe.HasValue && dataAte.HasValue && cliente == null && funcionario != null)
                return (from os in ordensServico where os.Data >= DateTime.Now && os.Data <= dataAte && os.Funcionario.Codigo == funcionario.Codigo select os).ToList();

            if (!dataDe.HasValue && dataAte.HasValue && funcionario == null && cliente != null)
                return (from os in ordensServico where os.Data >= DateTime.Now && os.Data <= dataAte && os.Cliente.Codigo == cliente.Codigo select os).ToList();

            #endregion           
       
            throw new Exception("Contexto não identificado");
        }
    }
}
