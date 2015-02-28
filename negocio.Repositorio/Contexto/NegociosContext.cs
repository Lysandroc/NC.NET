using System.Data.Entity;
using negocio.Dominio;
using negocio.Repositorio.Mapeamento;

namespace negocio.Repositorio.Contexto
{
    public class AppDataContextInitializer : DropCreateDatabaseIfModelChanges<NegociosContext>
    {
    }

    public class NegociosContext : DbContext
    {
        public NegociosContext()
            : base("NegocioCesaros")
        {
            Database.SetInitializer(new AppDataContextInitializer());
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<CarroDTO> dbCarro { get; set; }
        public DbSet<ClienteDTO> dbCliente { get; set; }

        public DbSet<ProdutoDTO> dbProduto { get; set; }
        public DbSet<ProdutoCategoriaDTO> dbProdutoCategoria { get; set; }

        public DbSet<VendaDTO> dbVenda { get; set; }
        public DbSet<VendaDetalheDTO> dbVendaDetalhe { get; set; }

        public DbSet<CompraDTO> dbCompra { get; set; }
        public DbSet<CompraDetalheDTO> dbCompraDetalhe { get; set; }

        public DbSet<FornecedorDTO> dbFornecedor { get; set; }
        public DbSet<PagamentoDTO> dbPagamento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarroMapeamento());
            modelBuilder.Configurations.Add(new ClienteMapeamento());

            modelBuilder.Configurations.Add(new CompraMapeamento());
            modelBuilder.Configurations.Add(new CompraDetalheMapeamento());

            modelBuilder.Configurations.Add(new VendaMapeamento());
            modelBuilder.Configurations.Add(new VendaDetalheMapeamento());

            modelBuilder.Configurations.Add(new ProdutoMapeamento());
            modelBuilder.Configurations.Add(new ProdutoCategoriaMapeamento());

            modelBuilder.Configurations.Add(new FornecedorMapeamento());
            modelBuilder.Configurations.Add(new PagamentoMapeamento());

            base.OnModelCreating(modelBuilder);
        }
    }
}