namespace SCRWebAPI_v4.Domain.Dto;

public abstract class PerguntaSelecionadaPacienteDto
{
    public int PerguntaId { get; set; }
    public int PacienteId { get; set; }
    public int ClassificacaoPacienteId { get; set; }
}
