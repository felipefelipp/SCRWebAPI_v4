namespace Domain.AggregatesModel.Classificacao;

public class PerguntaSelecionada
{
    public int PerguntaSelecionadaId { get; set; }
    public int PerguntaId { get; set; }
    public int ClassificacaoPacienteId { get; set; }
}