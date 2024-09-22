namespace SCRWebAPI_v4.Domain.Dto;

public abstract class RespostaDto
{
    public bool RespostaTexto { get; set; }
    public bool RespostaTextoArea { get; set; }
    public string RespostaCheckBox { get; set; }
    public string RespostaComboBox { get; set; }
    public string RespostaRadioButtom { get; set; }
    public DateTime? RespostaData { get; set; }
    public int ValorResposta { get; set; } // Pontuação da resposta
}
