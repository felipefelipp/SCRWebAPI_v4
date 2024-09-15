using Domain.AggregatesModel.Cliente;
using SCRWebAPI_v4.Domain.Services;

namespace Domain.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<Paciente> ObterPacienteById(int id);
        Task<ServiceResponse<Paciente>> AdicionarPaciente(Paciente paciente);
    }
}
