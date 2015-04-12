using Murta.OrdemServico.Bll;
using Murta.OrdemServico.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Murta.OrdemServico.Service.WCF
{
    public class SistemaService : ISistema
    {
        protected AutentitcacaoBusiness autenticacaoBusiness = null;
        protected OrdemServicoBusiness ordemServicoBusiness = null;
        protected ClienteBusiness clienteBusiness = null;
        protected ProjetoBusiness projetoBusiness = null;
        protected TipoHoraBusiness tipoHoraBusiness = null;
        protected FuncionarioBusiness funcionarioBusiness = null;
        protected StatusBusiness statusBusiness = null;

        public SistemaService()
        {
            //Inicializa a conexão com o banco de dados
            string assembly = ConfigurationManager.AppSettings["ActiveDatabaseAssembly"];
            string connectionClass = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["ActiveConnectionClass"]];
            string connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["ActiveConnectionString"]].ConnectionString;

            //A conexão consiste num Singleton, então sempre haverá uma instancia ativa que poderá ser acessada em qualquer parte do código
            Connection.ConfigureConnection(connectionString: connectionString, assemblyKey: assembly, connectionClass: connectionClass);            

            //atribui uma conexão para cada objeto de negócio
            var conexao = Connection.GetInstance();
            this.autenticacaoBusiness = new AutentitcacaoBusiness(conexao);
            this.ordemServicoBusiness = new OrdemServicoBusiness(conexao);
            this.clienteBusiness = new ClienteBusiness(conexao);
            this.projetoBusiness = new ProjetoBusiness(conexao);
            this.tipoHoraBusiness = new TipoHoraBusiness(conexao);
            this.funcionarioBusiness = new FuncionarioBusiness(conexao);
            this.statusBusiness = new StatusBusiness(conexao);
        }

        public void CadastrarOrdemServico(Murta.OrdemServico.Dto.OS ordemServico)
        {            
            this.ordemServicoBusiness.Cadastrar(ordemServico);
        }

        public void EditarOrdemServico(Murta.OrdemServico.Dto.OS ordemServico)
        {
            this.ordemServicoBusiness.Editar(ordemServico);
        }

        public void ExcluirOrdemServico(Murta.OrdemServico.Dto.OS ordemServico)
        {
            this.ordemServicoBusiness.Excluir(ordemServico);
        }

        public Murta.OrdemServico.Dto.OS ConsultarOrdemServico(int id)
        {
            return this.ordemServicoBusiness.Consultar(id);
        }

        public List<Murta.OrdemServico.Dto.OS> ListarOrdemServico(DateTime dataDe, DateTime dataAte, Funcionario funcionario, Cliente cliente)
        {
            return this.ordemServicoBusiness.Listar(dataDe, dataAte, funcionario, cliente);
        }

        public List<OS> ListarOrdemServico()
        {
            return this.ordemServicoBusiness.Listar();
        }

        public List<OS> ListarOrdemServico(DateTime dataDe)
        {
            return this.ordemServicoBusiness.Listar(dataDe: dataDe);
        }

        public List<OS> ListarOrdemServico(DateTime dataDe, DateTime dataAte)
        {
            return  this.ordemServicoBusiness.Listar(dataDe: dataDe, dataAte: dataAte);
        }

        public List<OS> ListarOrdemServico(DateTime dataDe, DateTime dataAte, Funcionario funcionario)
        {
            return this.ordemServicoBusiness.Listar(dataDe, dataAte, funcionario);
        }

        public List<OS> ListarOrdemServico(DateTime dataDe, DateTime dataAte, Cliente cliente)
        {
            return this.ordemServicoBusiness.Listar(dataDe: dataDe, dataAte: dataAte, cliente: cliente);
        }

        public List<OS> ListarOrdemServico(DateTime dataDe, DateTime dataAte, Cliente cliente, Funcionario funcionario)
        {
            return this.ordemServicoBusiness.Listar(dataDe: dataDe, dataAte: dataAte, cliente:cliente, funcionario: funcionario);
        }

        public List<OS> ListarOrdemServico(DateTime dataDe, Funcionario funcionario)
        {
            return this.ordemServicoBusiness.Listar(dataDe: dataDe, funcionario: funcionario);
        }

        public List<OS> ListarOrdemServico(DateTime dataDe, Cliente cliente)
        {
            return this.ordemServicoBusiness.Listar(dataDe: dataDe, cliente: cliente); 
        }

        public List<OS> ListarOrdemServico(DateTime dataDe, Funcionario funcionario, Cliente cliente)
        {
            return this.ordemServicoBusiness.Listar(dataDe: dataDe, funcionario: funcionario, cliente: cliente);
        }

        public List<OS> ListarOrdemServico(Funcionario funcionario, Cliente cliente)
        {
            return this.ordemServicoBusiness.Listar(funcionario: funcionario, cliente: cliente);
        }

        public List<OS> ListarOrdemServico(Funcionario funcionario)
        {
            return this.ordemServicoBusiness.Listar(funcionario: funcionario);
        }

        public List<OS> ListarOrdemServico(Cliente cliente)
        {
            return this.ordemServicoBusiness.Listar(cliente: cliente);
        }

        public List<OS> ListarOrdemServico(DateTime data, Funcionario funcionario, Enums.TipoData tipo)
        {
            if (tipo == Enums.TipoData.DataDe)
                return this.ordemServicoBusiness.Listar(dataDe: data, funcionario: funcionario);
            else
                return this.ordemServicoBusiness.Listar(dataAte: data, funcionario: funcionario);
        }

        public List<OS> ListarOrdemServico(DateTime data, Cliente cliente, Enums.TipoData tipo)
        {
            if (tipo == Enums.TipoData.DataDe)
                return this.ordemServicoBusiness.Listar(dataDe: data, cliente: cliente);
            else
                return this.ordemServicoBusiness.Listar(dataAte: data, cliente: cliente);
        }

        public List<OS> ListarOrdemServico(DateTime data, Enums.TipoData tipo)
        {
            if (tipo == Enums.TipoData.DataDe)
                return this.ordemServicoBusiness.Listar(dataDe: data);
            else
                return this.ordemServicoBusiness.Listar(dataAte: data);
        }

        public List<Cliente> ListarClientes()
        {
            return this.clienteBusiness.Listar();
        }

        public List<Projeto> ListarProjetos()
        {
            return this.projetoBusiness.Listar();
        }

        public List<TipoHora> ListarTiposHora()
        {
            return this.tipoHoraBusiness.Listar();
        }

        public List<Funcionario> ListarFuncionarios()
        {
            return this.funcionarioBusiness.Listar();
        }
        
        public List<Status> ListarStatus()
        {
            return this.statusBusiness.Listar();
        }

        public Murta.Dto.Usuario Login(string usuario, string senha)
        {
            return this.autenticacaoBusiness.Login(usuario, senha);
        }
    }
}
