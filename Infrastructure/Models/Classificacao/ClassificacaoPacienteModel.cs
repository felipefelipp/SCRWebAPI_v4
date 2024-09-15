using Infrastructure.Models.Atendimento;

namespace Infrastructure.Models.Classificacao;

public class ClassificacaoPacienteModel
{
    public virtual AtendimentoPacienteModel AtendimentoPaciente { get; set; }
    public int AtendimentoPacienteId { get; set; }
    public int ClassificacaoPacienteId { get; set; }
    public int PacienteId { get; set; }
}
