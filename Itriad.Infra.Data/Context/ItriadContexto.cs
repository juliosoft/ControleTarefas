using Itriad.Domain.Entities;
using Itriad.Infra.Data.EntityMap;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Itriad.Infra.Data.Context
{
    /// <summary>
    /// Install-Package EntityFramework
    /// </summary>
    public class ItriadContexto : DbContext 
    {
        public ItriadContexto() : base ("ControleTarefasConexao") //Nome da string de conexão 
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        #region Declaração de entidades
        public DbSet<BackLogItem> BackLogItens { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<HistoricoTarefa> HistoricoTarefas { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<TipoTarefa> TipoTarefa { get; set; }
        #endregion

        /// <summary>
        /// Reescreve OnModelCreating para configurações personalizadas 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove os plurais das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Remove a instrução de exclusão em castata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Configura para que sempre a chave primaria seja NomeClasse + Id
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            // Configura para sempre que um atibuto for string, seja gerada  a coluna no tipo varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            // Configura para quando for do tipo string, 
            // e não for delimitado o tamanho, ele cria a coluna com tamanho padrão a 100 car..
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new BackLogItemMap());
            modelBuilder.Configurations.Add(new CargoMap());
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new EmpresaMap());
            modelBuilder.Configurations.Add(new HistoricoTarefaMap());
            modelBuilder.Configurations.Add(new ProfissionalMap());
            modelBuilder.Configurations.Add(new ProjetoMap());
            modelBuilder.Configurations.Add(new SprintMap());
            modelBuilder.Configurations.Add(new TarefaMap());
            modelBuilder.Configurations.Add(new TimeMap());
            modelBuilder.Configurations.Add(new TipoTarefaMap());
            
        }
        /// <summary>
        /// Reescreve SaveChanges para informações de auditoria.
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                    entry.Property("UsuarioCadastro").CurrentValue = "Usuário Mestre";
                    entry.Property("UsuarioAtualizacao").CurrentValue = "Usuário Mestre";
                }
                else
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("UsuarioCadastro").IsModified = false;
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                    entry.Property("UsuarioAtualizacao").CurrentValue = "Usuário Mestre";
                }
            }

            return base.SaveChanges();
        }
    }

}
