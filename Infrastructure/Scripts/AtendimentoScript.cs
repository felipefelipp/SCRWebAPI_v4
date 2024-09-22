namespace SCRWebAPI_v4.Infrastructure.Scripts
{
    public class AtendimentoScript
    {
        public const string AdicionarAtendimento = @"INSERT INTO Atendimento (PacenteId, SenhaClassificacao, DataAtendimento, InseridoPor, InseridoEm) 
                                                     OUTPUT INSERTED.AtendimentoPacienteId
                                                     VALUES (@PacenteId, @SenhaClassificacao, @DataAtendimento, @InseridoPor, @InseridoEm)";

        public const string ObterAtendimentoPorId = "SELECT * FROM Atendimento WITH (NOLOCK) WHERE AtendimentoPacienteId = @AtendimentoPacienteId";
       
        public const string ObterAtendimentosPorIdPaciente = "SELECT * FROM Atendimento WITH (NOLOCK) WHERE PacenteId = @PacenteId";

        public const string ObterAtendimentos = "SELECT * FROM Atendimento WITH (NOLOCK) ORDER BY AtendimentoPacienteId OFFSET @offset ROWS FETCH NEXT @PageSize ROWS ONLY";

        public const string AtualizarIdPacienteAtendimento = "UPDATE Atendimento SET PacenteId = @PacenteId WHERE AtendimentoPacienteId = @AtendimentoPacienteId";


    }
}
