using Domain.AggregatesModel.Atendimento;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;

namespace SCRWebAPI_v4.Domain.Repositories.Interfaces
{
    public interface IAtendimentoRepository
    {
        Task<AtendimentoPaciente> AdicionarAtendimentoAsync(AtendimentoPaciente atendimentoPaciente);
        Task<bool> AtualizarIdPacienteAtendimentoAsync(int atendimentoPacienteId, int pacienteId);
        Task<AtendimentoPaciente> ObterAtendimentoPorIdAsync(int atendimentoPacienteId);
        Task<List<AtendimentoPaciente>> ObterAtendimentosPacienteAsync(int pacienteId);
        Task<List<AtendimentoPaciente>> ObterAtendimentosAsync(Parameters parameters);
    }
}
