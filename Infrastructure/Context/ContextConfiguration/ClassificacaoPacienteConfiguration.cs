using Infrastructure.Models.Classificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ContextConfiguration
{
    public class ClassificacaoPacienteConfiguration : IEntityTypeConfiguration<ClassificacaoPacienteModel>
    {
        public void Configure(EntityTypeBuilder<ClassificacaoPacienteModel> builder)
        {
            builder
                .ToTable("ClassificacaoPaciente");

            builder
                .HasKey(cpc => cpc.ClassificacaoPacienteId);

            builder
                .Property(cpc => cpc.ClassificacaoPacienteId)
                .HasColumnName("ClassificacaoPacienteId");

            builder
                .Property(cpc => cpc.PacienteId)
                .HasColumnName("PacienteId");

            builder
               .Property<DateTime>("InseridoEm")
               .HasColumnType("datetime")
               .HasDefaultValueSql("getdate()");

            builder
                .Property<int>("InseridoPor")
                .HasColumnType("int")
                .HasDefaultValueSql("1"); //Implementar inserido por usuário X ou Y

            builder
                .Property<DateTime>("ModificadoEm")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()"); //Implementar modificado em 

            builder
                .Property<int>("ModificadoPor")
                .HasColumnType("int")
                .HasDefaultValueSql("1"); //Implementar usuário que modificou 

        }
    }
}
