namespace Domain.AggregatesModel.Classificacao;

public class Pergunta
{
    public int PerguntaId { get; set; }
    public string DescricaoPergunta { get; set; }
    public int? CategoriaPerguntaId { get; set; }
}

