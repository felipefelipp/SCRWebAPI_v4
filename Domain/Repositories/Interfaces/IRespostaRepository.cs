using Domain.AggregatesModel.Classificacao;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;

namespace SCRWebAPI_v4.Domain.Repositories.Interfaces
{
    public interface IRespostaRepository
    {
        Task<Resposta> AdicionarRespostaAsync(Resposta resposta);
        Task<bool> AtualizarRespostaAsync(Resposta resposta);
        Task<Resposta> ObterRespostaPorIdAsync(int id);
        Task<List<Resposta>> ObterRespostasAsync(Parameters parameters);
        Task<bool> ExcluirRespostaAsync(int respostaId);
    }
}
