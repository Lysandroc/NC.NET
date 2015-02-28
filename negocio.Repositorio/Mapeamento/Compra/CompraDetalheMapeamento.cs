using System.Data.Entity.ModelConfiguration;
using negocio.Dominio;

namespace negocio.Repositorio.Mapeamento
{
    public class CompraDetalheMapeamento : EntityTypeConfiguration<CompraDetalheDTO>
    {
        public CompraDetalheMapeamento()
        {
            ToTable("CompraDetalhe");
            HasKey(x => x.Id).Property(x => x.Id).HasColumnName("id");
            Property(x => x.ValorItem);
            Property(x => x.Quantidade);

            HasRequired(x => x.Compra);
            HasRequired(x => x.Produto);
        }
    }
}