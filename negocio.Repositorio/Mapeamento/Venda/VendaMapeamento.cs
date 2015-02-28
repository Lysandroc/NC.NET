using System.Data.Entity.ModelConfiguration;
using negocio.Dominio;

namespace negocio.Repositorio.Mapeamento
{
    public class VendaMapeamento : EntityTypeConfiguration<VendaDTO>
    {
        public VendaMapeamento()
        {
            ToTable("Venda");
            HasKey(x => x.Id).Property(x => x.Id).HasColumnName("id");
            Property(x => x.Descricao);
            Property(x => x.Placa);

            HasRequired(x => x.Pagamento);
            HasRequired(x => x.Cliente);
            HasRequired(x => x.Carro);
            HasMany(x => x.VendaDetalhe);
        }
    }
}