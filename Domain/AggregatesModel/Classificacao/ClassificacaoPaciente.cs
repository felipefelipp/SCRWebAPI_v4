using Domain.AggregatesModel.Atendimento;

namespace Domain.AggregatesModel.Classificacao;

public class ClassificacaoPaciente
{
    public virtual AtendimentoPaciente AtendimentoPaciente { get; set; }
    public int AtendimentoPacienteId { get; set; }
    public int ClassificacaoPacienteId { get; set; }
    public int PacienteId { get; set; }
}
