namespace Domain.AggregatesModel.Classificacao;

public class PerguntaSelecionadaPaciente
{
    public int PerguntaSelecionadaPacienteId { get; set; }
    public int PerguntaId { get; set; }
    public int PacienteId { get; set; }
    public int ClassificacaoPacienteId { get; set; }


}