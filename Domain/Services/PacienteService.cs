using Domain.AggregatesModel.Cliente;
using Domain.Services.Interfaces;
using Infrastructure.Repositories.Interfaces;
using SCRWebAPI_v4.Domain.AggregatesModel.Extensions;
using SCRWebAPI_v4.Domain.AggregatesModel.Parameters;
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

            var pacienteAdd = await _pacienteRepository.AdicionarPaciente(paciente);

            if (pacienteAdd == null)
            {
                response.Success = false;
                response.Message = "Não foi possível adicionar o paciente, tente novamente";
                return response;
            };

            response.Data = pacienteAdd;
            response.Success = true;
            response.Message = "Paciente adicionado com sucesso";

            return response;
        }

        public async Task<ServiceResponse<Paciente>> AtualizarPaciente(Paciente paciente)
        {
            var response = new ServiceResponse<Paciente>();

            if (paciente == null)
            {
                response.Success = false;
                response.Message = "Paciente não pode ser nulo";
                return response;
            };

            var pacienteFoiAtualizado = await _pacienteRepository.AtualizarPaciente(paciente);

            if (pacienteFoiAtualizado == false)
            {
                response.Success = false;
                response.Message = "Não foi possível atualizar o paciente, tente novamente";
                return response;
            };

            var pacienteAtualizado = await _pacienteRepository.ObterPaciente(id: paciente.PacienteId);

            response.Success = true;
            response.Data = pacienteAtualizado;
            response.Message = "Paciente atualizado com sucesso";
            return response;
        }

        public async Task<ServiceResponse<Paciente>> ObterPaciente(Paciente paciente)
        {

            var response = new ServiceResponse<Paciente>();

            if (paciente == null)
            {
                response.Success = false;
                response.Message = "Paciente não pode ser nulo";
                return response;
            };

            var pacienteEncontrado = await _pacienteRepository.ObterPaciente(  paciente.PacienteId,
                                                                               paciente.CPF,
                                                                               paciente.Nome,
                                                                               paciente.DataNascimento,
                                                                               paciente.RG,
                                                                               paciente.Celular,
                                                                               paciente.Email,
                                                                               paciente.Telefone,
                                                                               paciente.Rua,
                                                                               paciente.Numero,
                                                                               paciente.Bairro,
                                                                               paciente.Municipio,
                                                                               paciente.UF,
                                                                               paciente.CEP,
                                                                               paciente.Sexo,
                                                                               paciente.Profissao);

            if (pacienteEncontrado == null)
            {
                response.Success = false;
                response.Message = "Paciente não encontrado";
                return response;
            };

            response.Data = pacienteEncontrado;
            response.Success = true;
            response.Message = "Paciente adicionado com sucesso";

            return response;
        }

        public async Task<ServiceResponse<List<Paciente>>> ObterPacientes(ParametersQuery parameters)
        {
            parameters.CalculateOffSet();

            var response = new ServiceResponse<List<Paciente>>();

            if (parameters == null)
            {
                response.Success = false;
                response.Message = "Os parâmetros para busca dos pacientes não pode ser nullo";
            }

            var pacientes = await _pacienteRepository.ObterPacientes(parameters);

            response.Data = pacientes;
            response.Success = true;
            response.Message = "Lista de pacientes";

            return response;
        }
    }
}
