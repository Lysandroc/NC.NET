using System.Data.Entity.ModelConfiguration;
using negocio.Dominio;

namespace negocio.Repositorio.Mapeamento
{
    public class ProdutoMapeamento : EntityTypeConfiguration<ProdutoDTO>
    {
        public ProdutoMapeamento()
        {
            ToTable("Produto");
            HasKey(x => x.Id).Property(x => x.Id).HasColumnName("id");
            Property(x => x.Descricao);
            Property(x => x.Tamanho);
            Property(x => x.Referencia);
            Property(x => x.Marca);
            Property(x => x.Modelo);

            //HasMany(x => x.VendaDetalhe);
            //HasMany(x => x.CompraDetalhe);
        }
    }
}