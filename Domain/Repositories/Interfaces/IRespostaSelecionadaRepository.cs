using Domain.AggregatesModel.Classificacao;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;

namespace SCRWebAPI_v4.Domain.Repositories.Interfaces
{
    public interface IRespostaSelecionadaRepository
    {
        Task<RespostaSelecionada> AdicionarRespostaSelecionadaAsync(RespostaSelecionada respostaSelecionada);
        Task<RespostaSelecionada> ObterRespostaSelecionadaPorIdAsync(int id);
        Task<List<RespostaSelecionada>> ObterRespostasSelecionadasAsync(Parameters parameters);
        Task<bool> AtualizarRespostaSelecionadaAsync(RespostaSelecionada respostaSelecionada);
        Task<bool> ExcluirRespostaSelecionadaAsync(int respostaSelecionadaPacienteId);
    }
}
