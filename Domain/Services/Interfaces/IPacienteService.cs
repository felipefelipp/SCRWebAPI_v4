using Domain.AggregatesModel.Cliente;
using SCRWebAPI_v4.Domain.Dto;
using SCRWebAPI_v4.Domain.Services;

namespace Domain.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<ServiceResponse<Paciente>> ObterPacienteAsync(int? id = null,
                                                       string? cpf = null,
                                                       string? rg = null,
                                                       string? celular = null,
                                                       string? email = null,
                                                       string? telefone = null);
        Task<ServiceResponse<Paciente>> AdicionarPacienteAsync(PacienteDto paciente);
        Task<ServiceResponse<List<Paciente>>> ObterPacientesAsync(int pageNumber, int pageSize);
        Task<ServiceResponse<Paciente>> AtualizarPacienteAsync(int id, PacienteDto paciente);
    }
}
