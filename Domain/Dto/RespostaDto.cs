namespace SCRWebAPI_v4.Domain.Dto;

public class RespostaDto
{
    public string? RespostaTexto { get; set; }
    public string? RespostaTextoArea { get; set; }
    public string? RespostaCheckBox { get; set; }
    public string? RespostaComboBox { get; set; }
    public string? RespostaRadioButtom { get; set; }
    public DateTime? RespostaDateTime { get; set; }
    public int? RespostaNumeric { get; set; }
    public int? PontuacaoResposta { get; set; } // Pontuação da resposta
    public int? IdPergunta { get; set; }
}
