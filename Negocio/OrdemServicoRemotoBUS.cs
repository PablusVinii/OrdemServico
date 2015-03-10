using AcessaDados;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransferenciaObjetos;

namespace Negocio
{
    public class OrdemServicoRemotoBUS: IOrdemServicoRemotoNegocio
    {

        protected IOrdemServicoRemotoRepositorio _repository = null;
        protected IOrdemServicoNegocio _business = null;
        protected FbConnection _connection = null;
        protected Empresa empresa = null;
        protected Filial filial = null;

        public OrdemServicoRemotoBUS(FbConnection conn, Empresa empresa, Filial filial)
        {
            this._connection = conn;

            if (this._connection.State == System.Data.ConnectionState.Closed)
            {
                this._connection.Open();
            }

            this._repository = new OrdemServicoRemotoDAO(conn);
            this._business = new OrdemServicoBUS(conn, empresa, filial);
            this.empresa = empresa;
            this.filial = filial;

        }

        public bool VerificaPrazoEdicao(OrdemServicoRemoto os, int diasLimite)
        {
            return this._business.VerificaPrazoEdicao(os.OrdemServico, diasLimite);
        }

        public void Cadastrar(OrdemServicoRemoto obj)
        {
            this._business.Cadastrar(obj.OrdemServico);
            obj.OrdemServico.Codigo = this._business.UltimoId();
            this._repository.Cadastrar(obj);

            IMetaNegocio umaMetaNegocio = new MetaBUS(this._connection, this.empresa, this.filial);
            List<Meta> lista = umaMetaNegocio.Listar(obj.OrdemServico.Projeto);

            DateTime dataOrdemServico = Convert.ToDateTime(obj.OrdemServico.Data);

            IOrdemServicoRepositorio umOrdemServicoDAO = new OrdemServicoDAO(this._connection);

            foreach (var meta in lista)
            {
                DateTime horasAcimaDeCem = new DateTime();
                horasAcimaDeCem = horasAcimaDeCem.AddHours(Convert.ToInt32(obj.Total.Split(':')[0]));
                horasAcimaDeCem = horasAcimaDeCem.AddMinutes(Convert.ToInt32(obj.Total.Split(':')[1]));
                TimeSpan ticks = new TimeSpan(horasAcimaDeCem.Ticks);

                umOrdemServicoDAO.AcrescentarNaMeta(
                    ano: dataOrdemServico.Year,
                    mes: dataOrdemServico.Month,
                    meta: meta.Codigo,
                    funcionario: obj.OrdemServico.Funcionario.Codigo,
                    indicador: meta.Indicador.Codigo,
                    totalHoras:ticks.TotalHours);
            }
        }

        public void Editar(OrdemServicoRemoto obj)
        {
            IOrdemServicoRemotoNegocio umaOrdemServicoRemotaBus = new OrdemServicoRemotoBUS(Conexao.Instacia, this.empresa, this.filial);

            OrdemServicoRemoto objAnterior = umaOrdemServicoRemotaBus.Consultar(obj.OrdemServico.Codigo);

            this._business.Editar(obj.OrdemServico);
            this._repository.Editar(obj);
            IMetaNegocio umaMetaNegocio = new MetaBUS(this._connection, this.empresa, this.filial);
            List<Meta> lista = umaMetaNegocio.Listar(obj.OrdemServico.Projeto);

            DateTime dataOrdemServico = Convert.ToDateTime(obj.OrdemServico.Data);

            IOrdemServicoRepositorio umOrdemServicoDAO = new OrdemServicoDAO(this._connection);

            foreach (var meta in lista)
            {
                if (meta.Indicador.Codigo == 1)
                {

                    DateTime horasAcimaDeCemAtual = new DateTime();
                    horasAcimaDeCemAtual = horasAcimaDeCemAtual.AddHours(Convert.ToInt32(obj.Total.Split(':')[0]));
                    horasAcimaDeCemAtual = horasAcimaDeCemAtual.AddMinutes(Convert.ToInt32(obj.Total.Split(':')[1]));
                    TimeSpan ticksAtual = new TimeSpan(horasAcimaDeCemAtual.Ticks);

                    double totalAtual = ticksAtual.TotalHours;

                    DateTime horasAcimaDeCemAnterior = new DateTime();
                    horasAcimaDeCemAnterior = horasAcimaDeCemAnterior.AddHours(Convert.ToInt32(objAnterior.Total.Split(':')[0]));
                    horasAcimaDeCemAnterior = horasAcimaDeCemAnterior.AddMinutes(Convert.ToInt32(objAnterior.Total.Split(':')[1]));
                    TimeSpan ticksAnterior = new TimeSpan(horasAcimaDeCemAnterior.Ticks);

                    double totalAnterior = ticksAnterior.TotalHours;

                    if (totalAtual > totalAnterior)
                    {
                        umOrdemServicoDAO.AcrescentarNaMeta
                            (
                                ano: dataOrdemServico.Year,
                                mes: dataOrdemServico.Month,
                                meta: meta.Codigo,
                                funcionario: obj.OrdemServico.Funcionario.Codigo,
                                indicador: meta.Indicador.Codigo,
                                totalHoras: totalAtual - totalAnterior
                            );
                    }
                    else
                    {
                        umOrdemServicoDAO.DecrementarNaMeta
                             (
                                 ano: dataOrdemServico.Year,
                                 mes: dataOrdemServico.Month,
                                 meta: meta.Codigo,
                                 funcionario: obj.OrdemServico.Funcionario.Codigo,
                                 indicador: meta.Indicador.Codigo,
                                 totalHoras: totalAnterior - totalAtual
                             );
                    }
                }
            }
        }

        public void Excluir(OrdemServicoRemoto obj)
        {
            this._business.Excluir(obj.OrdemServico);
            this._repository.Excluir(obj);

            IMetaNegocio umaMetaNegocio = new MetaBUS(this._connection, this.empresa, this.filial);
            List<Meta> lista = umaMetaNegocio.Listar(obj.OrdemServico.Projeto);

            DateTime dataOrdemServico = Convert.ToDateTime(obj.OrdemServico.Data);

            IOrdemServicoRepositorio umOrdemServicoDAO = new OrdemServicoDAO(this._connection);
      
            foreach (var meta in lista)
            {
                DateTime horasAcimaDeCem = new DateTime();
                horasAcimaDeCem = horasAcimaDeCem.AddHours(Convert.ToInt32(obj.Total.Split(':')[0]));
                horasAcimaDeCem = horasAcimaDeCem.AddMinutes(Convert.ToInt32(obj.Total.Split(':')[1]));
                TimeSpan ticks = new TimeSpan(horasAcimaDeCem.Ticks);

                umOrdemServicoDAO.DecrementarNaMeta(
                    ano: dataOrdemServico.Year,
                    mes: dataOrdemServico.Month,
                    meta: meta.Codigo,
                    funcionario: obj.OrdemServico.Funcionario.Codigo,
                    indicador: meta.Indicador.Codigo,
                    totalHoras: ticks.TotalHours
                );
            }
        }

        public List<OrdemServicoRemoto> Listar()
        {
            List<OrdemServicoRemoto> listaOSRemoto = this.ConverterParaObjetoDerivado(
                lista: this._business.Listar()
           ).ToList();

            return listaOSRemoto;
        }

        public List<OrdemServicoRemoto> Listar(string idFuncionario)
        {
            List<OrdemServicoRemoto> listaOSRemoto = this.ConverterParaObjetoDerivado(
                 lista: this._business.Listar(idFuncionario)
            ).ToList();

            return _repository.RealizarListagem(listaOSRemoto);
        }

        public List<OrdemServicoRemoto> Pesquisar(int id)
        {
            List<OrdemServicoRemoto> listaOSRemoto = this.ConverterParaObjetoDerivado(
                 lista: this._business.Pesquisar(id)
            ).ToList();

            return this._repository.RealizarListagem(listaOSRemoto);
        }

        public List<OrdemServicoRemoto> Pesquisar(OrdemServicoRemoto os)
        {
            List<OrdemServicoRemoto> listaOSRemoto = this.ConverterParaObjetoDerivado(
                 lista: this._business.Pesquisar(os.OrdemServico)
            ).ToList();

            return this._repository.RealizarListagem(listaOSRemoto);
        }

        public OrdemServicoRemoto Consultar(int id)
        {
           OrdemServicoRemoto umaOsRemoto = this.ConverterParaObjetoDerivado(
                os: this._business.Consultar(id)
           );

            return _repository.RealizarConsulta(umaOsRemoto);
        }

        protected IEnumerable<OrdemServicoRemoto> ConverterParaObjetoDerivado(List<OrdemServico> lista)
        {
            foreach (var item in lista)
                yield return new OrdemServicoRemoto { OrdemServico = item };
        }

        protected OrdemServicoRemoto ConverterParaObjetoDerivado(OrdemServico os)
        {
            return new OrdemServicoRemoto { OrdemServico = os };
        }
    }
}
