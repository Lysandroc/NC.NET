using System.Data.Entity.ModelConfiguration;
using negocio.Dominio;

namespace negocio.Repositorio.Mapeamento
{
    internal class PagamentoMapeamento : EntityTypeConfiguration<PagamentoDTO>
    {
        public PagamentoMapeamento()
        {
            ToTable("Pagamento");
            HasKey(x => x.Id).Property(x => x.Id).HasColumnName("id");
            Property(x => x.Data);
            Property(x => x.QuantidadeParcela);
            Property(x => x.ValorTotal);
            Property(x => x.FormaPagamento);
            Property(x => x.TipoNegocio);

            HasMany(x => x.Compra);
            HasMany(x => x.Venda);
            HasMany(x => x.PagamentoDetalhe);
        }
    }
}