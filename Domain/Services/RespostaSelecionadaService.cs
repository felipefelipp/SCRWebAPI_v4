using AutoMapper;
using Domain.AggregatesModel.Classificacao;
using SCRWebAPI_v4.Domain.AggregatesModel.Extensions;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;
using SCRWebAPI_v4.Domain.Dto;
using SCRWebAPI_v4.Domain.Repositories.Interfaces;
using SCRWebAPI_v4.Domain.Services.Interfaces;

namespace SCRWebAPI_v4.Domain.Services
{
    public class RespostaSelecionadaService : IRespostaSelecionadaService
    {
        private readonly IRespostaSelecionadaRepository _respostaSelecionadaRepository;
        private readonly IMapper _mapper;

        public RespostaSelecionadaService(IRespostaSelecionadaRepository respostaSelecionadaRepository, IMapper mapper)
        {
            _respostaSelecionadaRepository = respostaSelecionadaRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RespostaSelecionada>> ObterRespostaSelecionadaPorIdAsync(int id)
        {
            var response = new ServiceResponse<RespostaSelecionada>();

            if (id <= 0)
            {
                response.Success = false;
                response.Message = "ID inválido";
                return response;
            }

            var respostaSelecionada = await _respostaSelecionadaRepository.ObterRespostaSelecionadaPorIdAsync(id);

            if (respostaSelecionada == null)
            {
                response.Success = false;
                response.Message = "Resposta selecionada não encontrada";
                return response;
            }

            response.Data = respostaSelecionada;
            response.Success = true;
            response.Message = "Resposta selecionada obtida com sucesso";
            return response;
        }

        public async Task<ServiceResponse<List<RespostaSelecionada>>> ObterRespostasSelecionadasAsync(int pageNumber, int pageSize)
        {
            var response = new ServiceResponse<List<RespostaSelecionada>>();

            var parameters = new Parameters()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            parameters.CalculateOffSet();

            var respostasSelecionadas = await _respostaSelecionadaRepository.ObterRespostasSelecionadasAsync(parameters);

            if (respostasSelecionadas == null || !respostasSelecionadas.Any())
            {
                response.Success = false;
                response.Message = "Nenhuma resposta selecionada encontrada";
                return response;
            }

            response.Data = respostasSelecionadas.ToList();
            response.Success = true;
            response.Message = "Respostas selecionadas obtidas com sucesso";
            return response;
        }

        public async Task<ServiceResponse<RespostaSelecionada>> AdicionarRespostaSelecionadaAsync(RespostaSelecionadaDto respostaSelecionadaDto)
        {
            var respostaSelecionada = _mapper.Map<RespostaSelecionada>(respostaSelecionadaDto);

            var response = new ServiceResponse<RespostaSelecionada>();

            if (respostaSelecionada == null)
            {
                response.Success = false;
                response.Message = "Resposta selecionada não pode ser nula";
                return response;
            }

            var respostaSelecionadaAdd = await _respostaSelecionadaRepository.AdicionarRespostaSelecionadaAsync(respostaSelecionada);

            if (respostaSelecionadaAdd == null)
            {
                response.Success = false;
                response.Message = "Não foi possível adicionar a resposta selecionada, tente novamente";
                return response;
            }

            response.Data = respostaSelecionadaAdd;
            response.Success = true;
            response.Message = "Resposta selecionada adicionada com sucesso";

            return response;
        }

        public async Task<ServiceResponse<RespostaSelecionada>> AtualizarRespostaSelecionadaAsync(int respostaSelecionadaId, RespostaSelecionadaDto respostaSelecionadaDto)
        {
            var respostaSelecionada = _mapper.Map<RespostaSelecionada>(respostaSelecionadaDto);
            respostaSelecionada.RespostaSelecionadaId = respostaSelecionadaId;

            var response = new ServiceResponse<RespostaSelecionada>();

            if (respostaSelecionada == null)
            {
                response.Success = false;
                response.Message = "Resposta selecionada não pode ser nula";
                return response;
            }

            var respostaSelecionadaFoiAtualizada = await _respostaSelecionadaRepository.AtualizarRespostaSelecionadaAsync(respostaSelecionada);

            if (respostaSelecionadaFoiAtualizada == false)
            {
                response.Success = false;
                response.Message = "Não foi possível atualizar a resposta selecionada, tente novamente";
                return response;
            }

            var respostaSelecionadaAtualizada = await _respostaSelecionadaRepository.ObterRespostaSelecionadaPorIdAsync(respostaSelecionadaId);

            response.Success = true;
            response.Data = respostaSelecionadaAtualizada;
            response.Message = "Resposta selecionada atualizada com sucesso";
            return response;
        }

        public async Task<ServiceResponse<bool>> ExcluirRespostaSelecionadaAsync(int id)
        {
            var response = new ServiceResponse<bool>();

            if (id <= 0)
            {
                response.Success = false;
                response.Message = "ID inválido";
                return response;
            }

            var respostaSelecionadaFoiExcluida = await _respostaSelecionadaRepository.ExcluirRespostaSelecionadaAsync(id);

            if (respostaSelecionadaFoiExcluida == false)
            {
                response.Success = false;
                response.Message = "Não foi possível excluir a resposta selecionada, tente novamente";
                return response;
            }

            response.Success = true;
            response.Data = true;
            response.Message = "Resposta selecionada excluída com sucesso";
            return response;
        }
    }
}
