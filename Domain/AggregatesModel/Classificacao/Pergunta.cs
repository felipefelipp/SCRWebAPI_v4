﻿namespace Domain.AggregatesModel.Classificacao;

public class Pergunta
{
    public int PerguntaId { get; set; }
    public string TextoPergunta { get; set; }
    public int? CategoriaPerguntaId { get; set; }
}

