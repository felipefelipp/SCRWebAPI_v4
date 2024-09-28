using AutoMapper;
using Domain.AggregatesModel.Classificacao;
using SCRWebAPI_v4.Domain.AggregatesModel.Extensions;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;
using SCRWebAPI_v4.Domain.Dto;
using SCRWebAPI_v4.Domain.Repositories.Interfaces;
using SCRWebAPI_v4.Domain.Services.Interfaces;

namespace SCRWebAPI_v4.Domain.Services
{
    public class PerguntaService : IPerguntaService
    {
        public readonly IPerguntaRepository _perguntaRepository;
        private readonly IMapper _mapper;
        public PerguntaService(IPerguntaRepository perguntaRepository, IMapper mapper)
        {
            _perguntaRepository = perguntaRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Pergunta>> AdicionarPerguntaAsync(PerguntaDto perguntaDto)
        {
            var pergunta = _mapper.Map<Pergunta>(perguntaDto);

            var response = new ServiceResponse<Pergunta>();

            if (pergunta == null)
            {
                response.Success = false;
                response.Message = "Pergunta não pode ser nulo";
                return response;
            };

            var perguntaAdd = await _perguntaRepository.AdicionarPerguntaAsync(pergunta);

            if (perguntaAdd == null)
            {
                response.Success = false;
                response.Message = "Não foi possível adicionar a pergunta, tente novamente";
                return response;
            };

            response.Data = perguntaAdd;
            response.Success = true;
            response.Message = "Pergunta adicionada com sucesso";

            return response;
        }

        public async Task<ServiceResponse<Pergunta>> AtualizarPerguntaAsync(int perguntaId, PerguntaDto perguntaDto)
        {
            var pergunta = _mapper.Map<Pergunta>(perguntaDto);
            pergunta.PerguntaId = perguntaId;

            var response = new ServiceResponse<Pergunta>();

            if (pergunta == null)
            {
                response.Success = false;
                response.Message = "Pergunta não pode ser nulo";
                return response;
            };

            var perguntaFoiAtualizada = await _perguntaRepository.AtualizarPerguntaAsync(pergunta);

            if (perguntaFoiAtualizada == false)
            {
                response.Success = false;
                response.Message = "Não foi possível atualizar a pergunta, tente novamente";
                return response;
            };

            var perguntaAtualizada = await _perguntaRepository.ObterPerguntaPorIdAsync(perguntaId);

            response.Success = true;
            response.Data = perguntaAtualizada;
            response.Message = "Pergunta atualizada com sucesso";
            return response;
        }

        public async Task<ServiceResponse<Pergunta>> ObterPerguntaPorIdAsync(int id)
        {
            var response = new ServiceResponse<Pergunta>();

            if (id < 0)
            {
                response.Success = false;
                response.Message = "É necessário informar algum valor para realizar a busca";
                return response;
            };

            var perguntaEncontrada = await _perguntaRepository.ObterPerguntaPorIdAsync(id);

            if (perguntaEncontrada == null)
            {
                response.Success = false;
                response.Message = "Pergunta não encontrada";
                return response;
            };

            response.Data = perguntaEncontrada;
            response.Success = true;
            response.Message = "Pergunta encontrada";

            return response;
        }

        public async Task<ServiceResponse<List<Pergunta>>> ObterPerguntasAsync(int pageNumber, int pageSize)
        {
            var parameters = new Parameters()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            parameters.CalculateOffSet();

            var response = new ServiceResponse<List<Pergunta>>();

            if (parameters == null)
            {
                response.Success = false;
                response.Message = "Os parâmetros para busca dos perguntas não pode ser nulos";
            }

            var perguntas = await _perguntaRepository.ObterPerguntasAsync(parameters);

            response.Data = perguntas;
            response.Success = true;
            response.Message = "Lista de perguntas";

            return response;
        }

        public async Task<ServiceResponse<bool>> ExcluirPerguntaAsync(int id)
        {
            var response = new ServiceResponse<bool>();

            if (id < 0)
            {
                response.Success = false;
                response.Message = "É necessário informar algum valor para realizar a busca";
                return response;
            };

            var perguntaEncontrada = await _perguntaRepository.ExcluirPerguntaAsync(id);

            if (!perguntaEncontrada)
            {
                response.Success = false;
                response.Message = "Não foi possível excluir a pergunta, tente novamente";
                return response;
            };

            response.Data = perguntaEncontrada;
            response.Success = true;
            response.Message = "Pergunta excluída";

            return response;
        }
    }
}
