using Domain.AggregatesModel.Cliente;
using Domain.Services.Interfaces;
using Infrastructure.Repositories.Interfaces;
using SCRWebAPI_v4.Domain.Services;

namespace Domain.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<ServiceResponse<Paciente>> AdicionarPaciente(Paciente paciente)
        {
            var response = new ServiceResponse<Paciente>();

            if (paciente == null)
            {
                response.Success = false;
                response.Message = "Paciente não pode ser nulo";
                return response;
            };

            var pacienteAdd = await _pacienteRepository.Create(paciente);//AdicionarPaciente(paciente);
            response.Data = pacienteAdd;
            response.Success = true;
            response.Message = "Paciente adicionado com sucesso";

            return response;
        }

        public async Task<Paciente> ObterPacienteById(int id)
        {
            return await _pacienteRepository.ObterPacientePorId(id);
        }
    }
}
