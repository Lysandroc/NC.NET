using System.Data.Entity.ModelConfiguration;
using negocio.Dominio;

namespace negocio.Repositorio.Mapeamento
{
    internal class ClienteMapeamento : EntityTypeConfiguration<ClienteDTO>
    {
        public ClienteMapeamento()
        {
            ToTable("Cliente");
            HasKey(x => x.Id);
            Property(x => x.Nome).HasColumnName("Nome");
            Property(x => x.Sexo).HasColumnName("Sexo").HasMaxLength(1).IsFixedLength().IsUnicode(false);
            Property(x => x.DataNascimento).HasColumnName("DataNascimento");
            Property(x => x.Cpf).HasColumnName("Cpf");
            Property(x => x.Email).HasColumnName("Email");
            Property(x => x.Telefone).HasColumnName("Telefone");
            Property(x => x.Celular).HasColumnName("Celular");
            Property(x => x.Endereco).HasColumnName("Endereco");
        }
    }
}