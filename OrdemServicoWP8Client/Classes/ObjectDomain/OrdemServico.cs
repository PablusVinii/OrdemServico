using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemServicoWP8Client.Classes.ObjectDomain
{
    [Table]
    public class OrdemServico
    {
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(CanBeNull = false)]
        public bool Remoto { get; set; }

        [Column(CanBeNull = false)]
        public bool Faturado { get; set; }

        [Column(CanBeNull = false)]
        public int Situacao { get; set; }

        [Column(CanBeNull = false)]
        public DateTime Data { get; set; }

        [Column(CanBeNull = false)]
        public string Inicio { get; set; }

        [Column(CanBeNull = false)]
        public string Fim { get; set; }

        [Column(CanBeNull = false)]
        public string Traslado { get; set; }

        [Column(CanBeNull = false)]
        public string Atividades { get; set; }

        [Column(CanBeNull = true)]
        public string Observacao { get; set; }

        [Association(Name = "FK_OrdemSerico_OrdemSericoCliente", IsForeignKey = true, Storage = "cliente", ThisKey = "clienteId")]
        public Cliente Cliente
        {
            get { return this.cliente.Entity; }
            set { this.cliente.Entity = value; }
        }

        [Association(Name = "FK_OrdemSerico_OrdemSericoFuncionario", IsForeignKey = true, Storage = "funcionario", ThisKey = "funcionarioId")]
        public Funcionario Funcionario
        {
            get { return this.funcionario.Entity; }
            set { this.funcionario.Entity = value; }
        }

        [Association(Name = "FK_OrdemSerico_OrdemSericoProjeto", IsForeignKey = true, Storage = "projeto", ThisKey = "projetoId")]
        public Projeto Projeto
        {
            get { return this.projeto.Entity; }
            set { this.projeto.Entity = value; }
        }

        [Association(Name = "FK_OrdemSerico_OrdemSericoTipoHora", IsForeignKey = true, Storage = "tipoHora", ThisKey = "tipoHoraId")]
        public TipoHora TipoHora
        {
            get { return this.tipoHora.Entity; }
            set { this.tipoHora.Entity = value; }
        }

        [Column(Name = "Cliente")]
        private int? clienteId;

        [Column(Name = "Funcionario")]
        private int? funcionarioId;

        [Column(Name = "Projeto")]
        private int? projetoId;

        [Column(Name = "TipoHora")]
        private int? tipoHoraId;

        private EntityRef<Cliente> cliente = new EntityRef<Cliente>();

        private EntityRef<Funcionario> funcionario = new EntityRef<Funcionario>();

        private EntityRef<Projeto> projeto = new EntityRef<Projeto>();

        private EntityRef<TipoHora> tipoHora = new EntityRef<TipoHora>();
    }
}
