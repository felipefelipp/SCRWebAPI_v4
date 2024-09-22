using Domain.AggregatesModel.Classificacao;
using Domain.AggregatesModel.Extensions;

namespace Domain.AggregatesModel.Atendimento;

public class AtendimentoPaciente
{
    private string _senhaClassificacao;
    private DateTime _dataAtendimento;
    public int PacienteId { get; set; }
    public string SenhaClassificacao
    {
        get
        {
            return _senhaClassificacao;
        }
        set
        {
            _senhaClassificacao = GerarSenha.Sequencia();
        }
    }
    public DateTime DataAtendimento
    {
        get
        {
            return _dataAtendimento;
        }
        set
        {
            _dataAtendimento = DateTime.Now;
        }
    }
}
