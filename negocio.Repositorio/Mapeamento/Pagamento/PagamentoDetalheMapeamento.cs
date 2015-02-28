using System.Data.Entity.ModelConfiguration;
using negocio.Dominio;

namespace negocio.Repositorio.Mapeamento.Pagamento
{
    public class PagamentoDetalheMapeamento : EntityTypeConfiguration<PagamentoDetalheDTO>
    {
        public PagamentoDetalheMapeamento()
        {
            ToTable("PagamentoDetalhe");
            HasKey(x => x.id).Property(x => x.id).HasColumnName("id");
            Property(x => x.DataPagamento);
            Property(x => x.NumeroParcela);
            Property(x => x.Valor);
            Property(x => x.Pago);

            HasRequired(x => x.Pagamento);
        }
    }
}