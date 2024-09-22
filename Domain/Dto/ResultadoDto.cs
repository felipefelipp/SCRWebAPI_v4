namespace SCRWebAPI_v4.Domain.Dto;

public abstract class ResultadoDto
{
    public int ResultadoId { get; set; }
    public int PacienteId { get; set; }
    public int ClassificacaoPacienteId { get; set; }
    public int ValorResultadoClassificacao { get; set; }
    public int ResultadoCor { get; set; }
    public string ResultadoClassificacaoCor { get; set; }

}
