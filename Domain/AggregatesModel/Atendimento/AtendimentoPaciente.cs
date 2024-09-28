using Domain.AggregatesModel.Extensions;

namespace Domain.AggregatesModel.Atendimento;

public class AtendimentoPaciente
{
    public int PacienteId { get; set; }
    public int AtendimentoPacienteId { get; set; }
    public string SenhaClassificacao { get; set; }
    public DateTime DataAtendimento { get; set; }
}
