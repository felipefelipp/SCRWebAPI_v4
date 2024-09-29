using AutoMapper;
using Domain.AggregatesModel.Classificacao;
using SCRWebAPI_v4.Domain.AggregatesModel.Extensions;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;
using SCRWebAPI_v4.Domain.Dto;
using SCRWebAPI_v4.Domain.Repositories.Interfaces;
using SCRWebAPI_v4.Domain.Services.Interfaces;

namespace SCRWebAPI_v4.Domain.Services
{
    public class RespostaService : IRespostaService
    {
        public readonly IRespostaRepository _respostaRepository;
        private readonly IMapper _mapper;

        public RespostaService(IRespostaRepository respostaRepository, IMapper mapper)
        {
            _respostaRepository = respostaRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Resposta>> AdicionarRespostaAsync(RespostaDto respostaDto)
        {
            var resposta = _mapper.Map<Resposta>(respostaDto);

            var response = new ServiceResponse<Resposta>();

            if (resposta == null)
            {
                response.Success = false;
                response.Message = "Resposta não pode ser nula";
                return response;
            }

            var respostaAdd = await _respostaRepository.AdicionarRespostaAsync(resposta);

            if (respostaAdd == null)
            {
                response.Success = false;
                response.Message = "Não foi possível adicionar a resposta, tente novamente";
                return response;
            }

            response.Data = respostaAdd;
            response.Success = true;
            response.Message = "Resposta adicionada com sucesso";

            return response;
        }

        public async Task<ServiceResponse<Resposta>> AtualizarRespostaAsync(int respostaId, RespostaDto respostaDto)
        {
            var resposta = _mapper.Map<Resposta>(respostaDto);
            resposta.RespostaId = respostaId;

            var response = new ServiceResponse<Resposta>();

            if (resposta == null)
            {
                response.Success = false;
                response.Message = "Resposta não pode ser nula";
                return response;
            }

            var respostaFoiAtualizada = await _respostaRepository.AtualizarRespostaAsync(resposta);

            if (respostaFoiAtualizada == false)
            {
                response.Success = false;
                response.Message = "Não foi possível atualizar a resposta, tente novamente";
                return response;
            }

            var respostaAtualizada = await _respostaRepository.ObterRespostaPorIdAsync(respostaId);

            response.Success = true;
            response.Data = respostaAtualizada;
            response.Message = "Resposta atualizada com sucesso";
            return response;
        }

        public async Task<ServiceResponse<Resposta>> ObterRespostaPorIdAsync(int id)
        {
            var response = new ServiceResponse<Resposta>();

            if (id < 0)
            {
                response.Success = false;
                response.Message = "É necessário informar algum valor para realizar a busca";
                return response;
            }

            var respostaEncontrada = await _respostaRepository.ObterRespostaPorIdAsync(id);

            if (respostaEncontrada == null)
            {
                response.Success = false;
                response.Message = "Resposta não encontrada";
                return response;
            }

            response.Data = respostaEncontrada;
            response.Success = true;
            response.Message = "Resposta encontrada";

            return response;
        }

        public async Task<ServiceResponse<List<Resposta>>> ObterRespostasAsync(int pageNumber, int pageSize)
        {
            var parameters = new Parameters()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            parameters.CalculateOffSet();

            var response = new ServiceResponse<List<Resposta>>();

            if (parameters == null)
            {
                response.Success = false;
                response.Message = "Os parâmetros para busca das respostas não podem ser nulos";
                return response;
            }

            var respostas = await _respostaRepository.ObterRespostasAsync(parameters);

            response.Data = respostas;
            response.Success = true;
            response.Message = "Lista de respostas";

            return response;
        }

        public async Task<ServiceResponse<bool>> ExcluirRespostaAsync(int id)
        {
            var response = new ServiceResponse<bool>();

            if (id < 0)
            {
                response.Success = false;
                response.Message = "É necessário informar algum valor para realizar a busca";
                return response;
            }

            var respostaExcluida = await _respostaRepository.ExcluirRespostaAsync(id);

            if (!respostaExcluida)
            {
                response.Success = false;
                response.Message = "Não foi possível excluir a resposta, tente novamente";
                return response;
            }

            response.Success = true;
            response.Message = "Resposta excluída";

            return response;
        }
    }
}
