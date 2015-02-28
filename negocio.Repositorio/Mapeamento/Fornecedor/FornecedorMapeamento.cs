using System.Data.Entity.ModelConfiguration;
using negocio.Dominio;

namespace negocio.Repositorio.Mapeamento
{
    internal class FornecedorMapeamento : EntityTypeConfiguration<FornecedorDTO>
    {
        public FornecedorMapeamento()
        {
            ToTable("Fornecedor");
            HasKey(x => x.Id).Property(x => x.Id).HasColumnName("id");
            Property(x => x.Descricao);
            Property(x => x.Cnpj);
            Property(x => x.Telefone);
            Property(x => x.Endereco);

            //HasMany(x=>x.Compra);
        }
    }
}