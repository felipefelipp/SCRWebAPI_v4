using Infrastructure.Context.ContextConfiguration;
using Infrastructure.Models.Atendimento;
using Infrastructure.Models.Classificacao;
using Infrastructure.Models.Cliente;
using Infrastructure.Models.Funcionario;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<PacienteModel> Pacientes { get; set; }
    public DbSet<ResponsavelModel> Responsaveis { get; set; }
    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<PerguntaModel> Perguntas { get; set; }
    public DbSet<CategoriaPerguntaModel> CategoriaPerguntas { get; set; }
    public DbSet<PerguntaSelecionadaModel> PerguntaSelecionada { get; set; }
    public DbSet<RespostaModel> Respostas { get; set; }
    public DbSet<RespostaSelecionadaModel> RespostaSelecionada { get; set; }
    public DbSet<ClassificacaoPacienteModel> Classificacoes { get; set; }
    public DbSet<ResultadoModel> Resultados { get; set; }
    public DbSet<AtendimentoPacienteModel> Atendimentos { get; set; }
    public DbSet<PacienteResponsavelModel> PacientesResponsaveis { get; set; }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PacienteConfiguration());
        modelBuilder.ApplyConfiguration(new ResponsavelConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        modelBuilder.ApplyConfiguration(new PerguntaConfiguration());
        modelBuilder.ApplyConfiguration(new CategoriaPerguntaConfiguration());
        modelBuilder.ApplyConfiguration(new RespostaConfiguration());
        modelBuilder.ApplyConfiguration(new PerguntaSelecionadaConfiguration());    
        modelBuilder.ApplyConfiguration(new ClassificacaoPacienteConfiguration());
        modelBuilder.ApplyConfiguration(new RespostaSelecionadaConfiguration());
        modelBuilder.ApplyConfiguration(new ResultadoConfiguration());
        modelBuilder.ApplyConfiguration(new AtendimentoPacienteConfiguration());
        modelBuilder.ApplyConfiguration(new PacienteResponsavelConfiguration());
    }
}
