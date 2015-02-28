using System.Data.Entity.ModelConfiguration;
using negocio.Dominio;

namespace negocio.Repositorio.Mapeamento
{
    public class VendaDetalheMapeamento : EntityTypeConfiguration<VendaDetalheDTO>
    {
        public VendaDetalheMapeamento()
        {
            ToTable("VendaDetalhe");
            HasKey(x => x.Id).Property(x => x.Id).HasColumnName("id");
            Property(x => x.Valor);
            Property(x => x.Quantidade);

            HasRequired(x => x.Venda);
            HasRequired(x => x.Produto);
        }
    }
}