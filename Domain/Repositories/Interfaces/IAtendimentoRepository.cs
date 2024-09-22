using Domain.AggregatesModel.Atendimento;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;

namespace SCRWebAPI_v4.Domain.Repositories.Interfaces
{
    public interface IAtendimentoRepository
    {
        Task<AtendimentoPaciente> AdicionarAtendimentoAsync(AtendimentoPaciente atendimentoPaciente);
        Task<bool> AtualizarIdPacienteAtendimentoAsync(AtendimentoPaciente atendimentoPaciente);
        Task<AtendimentoPaciente> ObterAtendimentoPorIdAsync(int atendimentoPacienteId);
        Task<List<AtendimentoPaciente>> ObterAtendimentosPacienteAsync(AtendimentoPaciente atendimentoPaciente);
        Task<List<AtendimentoPaciente>> ObterAtendimentosAsync(Parameters parameters);
    }
}
