using Infrastructure.Models.Classificacao;

namespace Infrastructure.Models.Atendimento;

public class AtendimentoPacienteModel
{
    public int AtendimentoPacienteId { get; set; }
    public int PacienteId { get; set; }
    public string SenhaClassificacao { get; set; }
    public DateTime DataAtendimento { get; set; }
    public virtual ClassificacaoPacienteModel ClassificacaoPaciente { get; set; }
}
