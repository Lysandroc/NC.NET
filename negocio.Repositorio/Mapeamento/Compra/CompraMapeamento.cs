using System.Data.Entity.ModelConfiguration;
using negocio.Dominio;

namespace negocio.Repositorio.Mapeamento
{
    public class CompraMapeamento : EntityTypeConfiguration<CompraDTO>
    {
        public CompraMapeamento()
        {
            ToTable("Compra");
            HasKey(x => x.Id).Property(x => x.Id).HasColumnName("id");
            Property(x => x.Descricao);

            HasRequired(x => x.Fornecedor);
            HasRequired(x => x.Pagamento);
            HasMany(x => x.CompraDetalhe);
        }
    }
}