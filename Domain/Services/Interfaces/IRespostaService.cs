using Domain.AggregatesModel.Classificacao;
using SCRWebAPI_v4.Domain.Dto;

namespace SCRWebAPI_v4.Domain.Services.Interfaces
{
    public interface IRespostaService
    {
        Task<ServiceResponse<Resposta>> AdicionarRespostaAsync(RespostaDto respostaDto);
        Task<ServiceResponse<Resposta>> AtualizarRespostaAsync(int respostaId, RespostaDto respostaDto);
        Task<ServiceResponse<Resposta>> ObterRespostaPorIdAsync(int id);
        Task<ServiceResponse<List<Resposta>>> ObterRespostasAsync(int pageNumber, int pageSize);
        Task<ServiceResponse<bool>> ExcluirRespostaAsync(int id);
    }
}
