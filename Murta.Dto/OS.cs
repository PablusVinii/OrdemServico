using Murta.QueryFactor.Annotations;
using Murta.QueryFactory.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Dto
{
    [Table(NameTable = "ORDEM_SERVICO")]
    public class OS
    {
        protected Projeto projeto = new Projeto();
        protected TipoHora tipoHora = new TipoHora();
        protected Cliente cliente = new Cliente();
        protected Funcionario funcionario = new Funcionario();
        private Empresa empresa = new Empresa();
        protected Filial filial = new Filial();
        protected Status status = new Status();

        [Column(NameColumn = "CODIGO")]
        [WhereClause(NameColumn = "CODIGO", ID = 1)]
        public int Codigo { get; set; }        

        [Column(NameColumn = "DATA", IsUsedInsertOrUpdateOperation = true)]
        public DateTime Data { get; set; }

        [Column(NameColumn = "INICIO", IsUsedInsertOrUpdateOperation = true)]
        public string Inicio { get; set; }

        [Column(NameColumn = "FIM", IsUsedInsertOrUpdateOperation = true)]
        public string Fim { get; set; }

        [Column(NameColumn = "TRANSLADO", IsUsedInsertOrUpdateOperation = true)]
        public string Traslado { get; set; }

        [Column(NameColumn = "ATIVIDADE", IsUsedInsertOrUpdateOperation = true)]
        public string Atividade { get; set; }

        [Column(NameColumn = "OBSERVACAO", IsUsedInsertOrUpdateOperation = true)]
        public string Observacao { get; set; }

        [Column(NameColumn = "FATURADO", IsUsedInsertOrUpdateOperation = true)]
        public string Faturado { get; set; }

        [Column(IsObject=true, NameColumn="STATUS", Type=typeof(Status), NameObjectProperty="Status")]
        [Join(TypeJoin = "INNER JOIN", TableA = "ORDEM_SERVICO", FieldA = "STATUS", TableB = "SITUACAO_OS", FieldB = "CODIGO")]
        public Status Status 
        { 
            get 
            { 
                return this.status; 
            } 
            set 
            {
                this.status = value;
            } 
        }

        [Join(TypeJoin = "INNER JOIN", TableA = "ORDEM_SERVICO", FieldA = "PROJETO", TableB = "PROJETOS", FieldB = "CODIGO")]
        [Column(IsObject = true, Type = typeof(Projeto), NameObjectProperty = "Projeto")]
        public Projeto Projeto
        {
            get
            {
                return this.projeto;
            }
            set
            {
                this.projeto = value;
            }
        }

        [Join(TypeJoin = "INNER JOIN", TableA = "ORDEM_SERVICO", FieldA = "TIPOHORA", TableB = "TIPOHORAS", FieldB = "CODIGO")]
        [Column(IsObject = true, Type = typeof(TipoHora), NameObjectProperty = "TipoHora")]
        public TipoHora TipoHora
        {
            get
            {
                return this.tipoHora;
            }
            set
            {
                this.tipoHora = value;
            }
        }

        [Column(IsObject = true, Type = typeof(Empresa), NameObjectProperty = "Empresa")]
        [Join(TypeJoin = "INNER JOIN", TableA = "ORDEM_SERVICO", FieldA = "EMPRESA", TableB = "SYS_COMPANY", FieldB = "EMPRESA")]
        public Empresa Empresa
        {
            get
            {
                return this.empresa;
            }
            set
            {
                this.empresa = value;
            }
        }

        [Join(TypeJoin = "INNER JOIN", TableA = "ORDEM_SERVICO", FieldA = "FILIAL", TableB = "SYS_BRANCH", FieldB = "FILIAL")]
        [Column(IsObject = true, Type = typeof(Filial), NameObjectProperty = "Filial")]
        public Filial Filial
        {
            get
            {
                return this.filial;
            }
            set
            {
                this.filial = value;
            }
        }

        [Join(TypeJoin = "INNER JOIN", TableA = "ORDEM_SERVICO", FieldA = "CLIENTE", TableB = "CLIENTES", FieldB = "CODIGO")]
        [Column(IsObject = true, Type = typeof(Cliente), NameObjectProperty = "Cliente")]
        public Cliente Cliente
        {
            get
            {
                return this.cliente;
            }
            set
            {
                this.cliente = value;
            }
        }

        [Join(TypeJoin = "INNER JOIN", TableA = "ORDEM_SERVICO", FieldA = "FUNCIONARIO", TableB = "FUNCIONARIOS", FieldB = "CODIGO")]
        [Column(IsObject = true, Type = typeof(Funcionario), NameObjectProperty = "Funcionario")]
        public Funcionario Funcionario
        {
            get
            {
                return this.funcionario;
            }
            set
            {
                this.funcionario = value;
            }
        }
    }
}
