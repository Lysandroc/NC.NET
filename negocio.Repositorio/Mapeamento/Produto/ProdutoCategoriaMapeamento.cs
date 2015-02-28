using System.Data.Entity.ModelConfiguration;
using negocio.Dominio;

namespace negocio.Repositorio.Mapeamento
{
    public class ProdutoCategoriaMapeamento : EntityTypeConfiguration<ProdutoCategoriaDTO>
    {
        public ProdutoCategoriaMapeamento()
        {
            ToTable("ProdutoCategoria");
            HasKey(x => x.Id).Property(x => x.Id).HasColumnName("id");
            Property(x => x.Categoria);
            HasMany(x => x.Produtos).WithRequired(x => x.ProdutoCategoria).HasForeignKey(x => x.idProdutoCategoria);
        }
    }
}