using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using IAPromocoes.Domain.Entities;
using IAPromocoes.Infra.Data.EntityConfig;
using System.Data.Entity.Validation;

namespace IAPromocoes.Infra.Data.Context
{
    public class IAPromocoesContext : BaseDbContext
    {
        public IAPromocoesContext()
            : base("IAPromocoesContext")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Produto> Produtos { get; set; }
        public IDbSet<ProdutoPreco> ProdutoPrecos { get; set; }
        public IDbSet<ProdutoImagem> ProdutoImagens { get; set; }
        public IDbSet<Categoria> Categorias { get; set; }
        public IDbSet<Pedido> Pedidos { get; set; }
        public IDbSet<ItemPedido> ItemPedidos { get; set; }
        public IDbSet<Cliente> Clientes { get; set; }
        public IDbSet<StatusPedido> StatusPedidos { get; set; }
        public IDbSet<FormaDePagamento> FormaDePagamentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            
            // General Custom Context Properties
            //modelBuilder.Properties()
            //    .Where(p => p.Name == "Id" + p.ReflectedType.Name)
            //    .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));
            
            // ModelConfiguration
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoPrecoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoImagemConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new PedidoConfiguration());
            modelBuilder.Configurations.Add(new ItemPedidoConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new StatusPedidoConfiguration());
            modelBuilder.Configurations.Add(new FormaDePagamentoConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            //{
            //    if (entry.State == EntityState.Added)
            //    {
            //        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            //    }

            //    if (entry.State == EntityState.Modified)
            //    {
            //        entry.Property("DataCadastro").IsModified = false;
            //    }
            //}
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
