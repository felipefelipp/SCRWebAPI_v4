namespace Infrastructure.Models.Classificacao;

public class PerguntaModel
{
    public int PerguntaId { get; set; }
    public string TextoPergunta { get; set; }
    public int? CategoriaPerguntaId { get; set; }
    public virtual CategoriaPerguntaModel CategoriaPergunta { get; set; }

}

