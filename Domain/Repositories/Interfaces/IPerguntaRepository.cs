using Domain.AggregatesModel.Classificacao;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;

namespace SCRWebAPI_v4.Domain.Repositories.Interfaces
{
    public interface IPerguntaRepository
    {
        Task<Pergunta> ObterPerguntaPorIdAsync(int id);
        Task<List<Pergunta>> ObterPerguntasAsync(Parameters parameters);
        Task<Pergunta> AdicionarPerguntaAsync(Pergunta pergunta);
        Task<bool> AtualizarPerguntaAsync(Pergunta pergunta);
        Task<bool> ExcluirPerguntaAsync(int perguntaId);
    }
}
