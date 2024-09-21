using Domain.AggregatesModel.Cliente;
using SCRWebAPI_v4.Domain.AggregatesModel.Parameters;
using SCRWebAPI_v4.Domain.Services;

namespace Domain.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<ServiceResponse<Paciente>> ObterPaciente(Paciente paciente);
        Task<ServiceResponse<Paciente>> AdicionarPaciente(Paciente paciente);
        Task<ServiceResponse<List<Paciente>>> ObterPacientes(ParametersQuery parameters);
        Task<ServiceResponse<Paciente>> AtualizarPaciente(Paciente paciente);
    }
}
