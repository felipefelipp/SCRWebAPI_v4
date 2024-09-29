using Domain.AggregatesModel.Classificacao;
using SCRWebAPI_v4.Domain.Dto;

namespace SCRWebAPI_v4.Domain.Services.Interfaces
{
    public interface IRespostaSelecionadaService
    {
        Task<ServiceResponse<RespostaSelecionada>> ObterRespostaSelecionadaPorIdAsync(int id);
        Task<ServiceResponse<List<RespostaSelecionada>>> ObterRespostasSelecionadasAsync(int pageNumber, int pageSize);
        Task<ServiceResponse<RespostaSelecionada>> AdicionarRespostaSelecionadaAsync(RespostaSelecionadaDto respostaSelecionadaDto);
        Task<ServiceResponse<RespostaSelecionada>> AtualizarRespostaSelecionadaAsync(int respostaSelecionadaId, RespostaSelecionadaDto respostaSelecionadaDto);
        Task<ServiceResponse<bool>> ExcluirRespostaSelecionadaAsync(int id);
    }
}
