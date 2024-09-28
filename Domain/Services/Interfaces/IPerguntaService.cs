using Domain.AggregatesModel.Classificacao;
using SCRWebAPI_v4.Domain.Dto;

namespace SCRWebAPI_v4.Domain.Services.Interfaces
{
    public interface IPerguntaService
    {
        Task<ServiceResponse<Pergunta>> ObterPerguntaPorIdAsync(int id);
        Task<ServiceResponse<List<Pergunta>>> ObterPerguntasAsync(int pageNumber, int pageSize);
        Task<ServiceResponse<Pergunta>> AdicionarPerguntaAsync(PerguntaDto pergunta);
        Task<ServiceResponse<Pergunta>> AtualizarPerguntaAsync(int perguntaId, PerguntaDto perguntaDto);
        Task<ServiceResponse<bool>> ExcluirPerguntaAsync(int id);
    }
}
