using Domain.AggregatesModel.Extensions;
using System.ComponentModel.DataAnnotations;

namespace SCRWebAPI_v4.Domain.Dto;

public class AtendimentoDto
{
    [Required]
    public int PacienteId { get; set; }
}
