using Infrastructure.Models.Cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ContextConfiguration;

public class PacienteConfiguration : PessoaConfiguration<PacienteModel>
{
    public override void Configure(EntityTypeBuilder<PacienteModel> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("Paciente");

        builder
            .HasKey(p => p.PacienteId);

        builder
            .Property(p => p.PacienteId)
            .HasColumnName("PacienteId");

        builder
            .HasKey(p => p.PacienteId);

        builder
            .Property(p => p.Telefone)
            .HasColumnName("telefone")
            .HasColumnType("varchar(11)");

        builder
            .Property(p => p.Rua)
            .HasColumnName("rua")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(p => p.Numero)
            .HasColumnName("numero");

        builder
            .Property(p => p.Bairro)
            .HasColumnName("bairro")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(p => p.Municipio)
            .HasColumnName("municipio")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(p => p.UF)
            .HasColumnName("uf")
            .HasColumnType("varchar(2)")
            .IsRequired();

        builder
            .Property(p => p.CEP)
            .HasColumnName("cep")
            .HasColumnType("varchar(8)");

        builder
            .Property(p => p.Sexo)
            .HasColumnName("sexo")
            .HasColumnType("char(1)");

        builder
            .Property(p => p.Profissao)
            .HasColumnName("profissao")
            .HasColumnType("varchar(50)")
            .IsRequired();
    }

}
