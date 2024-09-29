namespace Infrastructure.Models.Classificacao;

public class RespostaSelecionadaModel
{
    public int RespostaSelecionadaId { get; set; }
    public int PerguntaId { get; set; }
    public int RespostaId { get; set; }
    public string ValorRespostaTexto { get; set; }
    public string ValorRespostaTextoArea { get; set; }
    public DateTime? RespostaDateTime { get; set; }
    public int ClassificacaoPacienteId { get; set; }
}