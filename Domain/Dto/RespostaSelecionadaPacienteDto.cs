using System.ComponentModel.DataAnnotations;

namespace SCRWebAPI_v4.Domain.Dto;

public abstract class RespostaSelecionadaPacienteDto
{
    public int RespostaId { get; set; }
    public int PerguntaId { get; set; }

    [MaxLength(100, ErrorMessage = "O valorRespostaTexto não pode ter mais de 100 caracteres, " +
                                   "caso precise de mais espaço utilize o campo ValorRespostaTextoArea ")]
    public string ValorRespostaTexto { get; set; }
    public string ValorRespostaTextoArea { get; set; }
    public int PacienteId { get; set; }
    public int ClassificacaoPacienteId { get; set; }
}
