using AutoMapper;
using Domain.AggregatesModel.Atendimento;
using Domain.AggregatesModel.Extensions;
using Infrastructure.Repositories.Interfaces;
using SCRWebAPI_v4.Domain.AggregatesModel.Extensions;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;
using SCRWebAPI_v4.Domain.Dto;
using SCRWebAPI_v4.Domain.Repositories.Interfaces;
using SCRWebAPI_v4.Domain.Services.Interfaces;

namespace SCRWebAPI_v4.Domain.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IAtendimentoRepository _atendimentoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        public AtendimentoService(IAtendimentoRepository atendimentoRepository, IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _atendimentoRepository = atendimentoRepository;
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AtendimentoPaciente>> AdicionarAtendimentoAsync(AtendimentoDto atendimentoDto)
        {
            var atendimento = new AtendimentoPaciente()
            {
                PacienteId = atendimentoDto.PacienteId,
                DataAtendimento = DateTime.Now,
                SenhaClassificacao = GerarSenha.Sequencia()
            };

            var response = new ServiceResponse<AtendimentoPaciente>();

            if (atendimento.PacienteId < 0)
            {
                response.Success = false;
                response.Message = "PacienteId não pode ser menor que 0";
                return response;
            };

            var atendimentoAdicionado = await _atendimentoRepository.AdicionarAtendimentoAsync(atendimento);

            if (atendimentoAdicionado == null)
            {
                response.Success = false;
                response.Message = "Não foi possível adicionar o atendimento, tente novamente";
                return response;
            };

            response.Data = atendimentoAdicionado;
            response.Success = true;
            response.Message = "Atendimento adicionado com sucesso";

            return response;
        }

        public async Task<ServiceResponse<AtendimentoPaciente>> AtualizarIdPacienteAtendimentoAsync(int atendimentoId, int pacienteId)
        {
            var response = new ServiceResponse<AtendimentoPaciente>();

            var pacienteEncontrado = await _pacienteRepository.ObterPacienteAsync(pacienteId);

            if (pacienteEncontrado == null)
            {
                response.Success = false;
                response.Message = "Paciente não existe";
                return response;
            };

            var atendimentoEncontrado = await _atendimentoRepository.ObterAtendimentoPorIdAsync(atendimentoId);

            if (atendimentoEncontrado == null)
            {
                response.Success = false;
                response.Message = "Atendimento não existe";
                return response;
            };

            var atendimentoFoiAtualizado = await _atendimentoRepository.AtualizarIdPacienteAtendimentoAsync(atendimentoId, pacienteId);

            if (atendimentoFoiAtualizado == false)
            {
                response.Success = false;
                response.Message = "Não foi possível atualizar o atendimento, tente novamente";
                return response;
            };

            var atendimentoAtualizado = await _atendimentoRepository.ObterAtendimentoPorIdAsync(atendimentoId);

            response.Success = true;
            response.Data = atendimentoAtualizado;
            response.Message = "Atendimento atualizado com sucesso";
            return response;
        }

        public async Task<ServiceResponse<AtendimentoPaciente>> ObterAtendimentoPorIdAsync(int atendimentoPacienteId)
        {
            var response = new ServiceResponse<AtendimentoPaciente>();

            if (atendimentoPacienteId < 0)
            {
                response.Success = false;
                response.Message = "Atendimento não pode ser menor que 0";
                return response;
            };

            var atendimentoEncontrado = await _atendimentoRepository.ObterAtendimentoPorIdAsync(atendimentoPacienteId);

            if (atendimentoEncontrado == null)
            {
                response.Success = false;
                response.Message = "Atendimento não encontrado";
                return response;
            };

            response.Data = atendimentoEncontrado;
            response.Success = true;
            response.Message = "Atendimento encontrado";

            return response;
        }

        public async Task<ServiceResponse<List<AtendimentoPaciente>>> ObterAtendimentosPacienteAsync(int pacienteId)
        {

            var response = new ServiceResponse<List<AtendimentoPaciente>>();

            if (pacienteId < 0)
            {
                response.Success = false;
                response.Message = "Paciente não pode ser menor que 0";
                return response;
            };

            var atendimentoEncontrado = await _atendimentoRepository.ObterAtendimentosPacienteAsync(pacienteId);

            response.Data = atendimentoEncontrado;
            response.Success = true;
            response.Message = "Lista de atendimentos do paciente";

            return response;
        }

        public async Task<ServiceResponse<List<AtendimentoPaciente>>> ObterAtendimentosAsync(int pageNumber, int pageSize)
        {
            var parameters = new Parameters()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            parameters.CalculateOffSet();

            var response = new ServiceResponse<List<AtendimentoPaciente>>();

            if (parameters == null)
            {
                response.Success = false;
                response.Message = "Os parâmetros para busca dos pacientes não pode ser nulos";
            }

            var pacientes = await _atendimentoRepository.ObterAtendimentosAsync(parameters);

            response.Data = pacientes;
            response.Success = true;
            response.Message = "Lista de atendimentos";

            return response;
        }

    }
}
