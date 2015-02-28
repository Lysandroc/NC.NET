using System.Data.Entity.ModelConfiguration;
using negocio.Dominio;

namespace negocio.Repositorio.Mapeamento
{
    internal class CarroMapeamento : EntityTypeConfiguration<CarroDTO>
    {
        public CarroMapeamento()
        {
            ToTable("Carro");
            //HasKey(x => x.Id).Property(x=>x.Id).HasColumnName("idCarro");
            HasKey(x => x.Id);
            Property(x => x.Marca).HasColumnName("Marca");
            Property(x => x.Modelo).HasColumnName("Modelo");
            //Relacionamento 1 para N
            //HasMany(x => x.Venda);
        }
    }
}