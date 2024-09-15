using Infrastructure.Models.Funcionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ContextConfiguration;

public class UsuarioConfiguration : PessoaConfiguration<UsuarioModel>
{
    public override void Configure(EntityTypeBuilder<UsuarioModel> builder)
    {

        builder
            .ToTable("Usuario");

        builder
            .HasKey(u => u.UsuarioId);

        builder
            .Property(u => u.UsuarioId)
            .HasColumnName("UsuarioId");

        base.Configure(builder);

        builder
            .Property(u => u.COREN)
            .HasColumnName("coren")
            .HasColumnType("varchar(8)");

        builder
            .Property(u => u.CRM)
            .HasColumnName("crm")
            .HasColumnType("varchar(8)");

        builder
            .Property(u => u.Senha)
            .HasColumnName("senha")
            .HasColumnType("varchar(8)")
            .IsRequired();
    }
}
