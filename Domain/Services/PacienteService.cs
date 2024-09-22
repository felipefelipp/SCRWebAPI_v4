using AutoMapper;
using Domain.AggregatesModel.Cliente;
using Domain.Services.Interfaces;
using Infrastructure.Repositories.Interfaces;
using SCRWebAPI_v4.Domain.AggregatesModel.Extensions;
using SCRWebAPI_v4.Domain.Dto;
using SCRWebAPI_v4.Domain.Services;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;

namespace Domain.Services
{
    public class PacienteService : IPacienteService 
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        public PacienteService(IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Paciente>> AdicionarPacienteAsync(PacienteDto pacienteDto)
        {
            var paciente = _mapper.Map<Paciente>(pacienteDto);

            var response = new ServiceResponse<Paciente>();

            if (paciente == null)
            {
                response.Success = false;
                response.Message = "Paciente não pode ser nulo";
                return response;
            };

            var pacienteAdd = await _pacienteRepository.AdicionarPacienteAsync(paciente);

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

        public async Task<ServiceResponse<Paciente>> AtualizarPacienteAsync(int id, PacienteDto pacienteDto)
        {
            var paciente = _mapper.Map<Paciente>(pacienteDto);
            paciente.PacienteId = id;

            var response = new ServiceResponse<Paciente>();

            if (paciente == null)
            {
                response.Success = false;
                response.Message = "Paciente não pode ser nulo";
                return response;
            };

            var pacienteFoiAtualizado = await _pacienteRepository.AtualizarPacienteAsync(paciente);

            if (pacienteFoiAtualizado == false)
            {
                response.Success = false;
                response.Message = "Não foi possível atualizar o paciente, tente novamente";
                return response;
            };

            var pacienteAtualizado = await _pacienteRepository.ObterPacienteAsync(id: paciente.PacienteId);

            response.Success = true;
            response.Data = pacienteAtualizado;
            response.Message = "Paciente atualizado com sucesso";
            return response;
        }

        public async Task<ServiceResponse<Paciente>> ObterPacienteAsync(int? id = null,
                                                                   string? cpf = null,
                                                                   string? rg = null,
                                                                   string? celular = null,
                                                                   string? email = null,
                                                                   string? telefone = null)
        {
            var response = new ServiceResponse<Paciente>();

            if (id == null && cpf == null && rg == null && celular == null && email == null && telefone == null)
            {
                response.Success = false;
                response.Message = "É necessário informar algum valor para realizar a busca";
                return response;
            };

            var pacienteEncontrado = await _pacienteRepository.ObterPacienteAsync(id: id, cpf: cpf, rg: rg, celular: celular, email: email, telefone: telefone);

            if (pacienteEncontrado == null)
            {
                response.Success = false;
                response.Message = "Paciente não encontrado";
                return response;
            };

            response.Data = pacienteEncontrado;
            response.Success = true;
            response.Message = "Paciente encontrado";

            return response;
        }

        public async Task<ServiceResponse<List<Paciente>>> ObterPacientesAsync(int pageNumber, int pageSize)
        {
            var parameters = new Parameters()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            parameters.CalculateOffSet();

            var response = new ServiceResponse<List<Paciente>>();

            if (parameters == null)
            {
                response.Success = false;
                response.Message = "Os parâmetros para busca dos pacientes não pode ser nulos";
            }

            var pacientes = await _pacienteRepository.ObterPacientesAsync(parameters);

            response.Data = pacientes;
            response.Success = true;
            response.Message = "Lista de pacientes";

            return response;
        }
    }
}
