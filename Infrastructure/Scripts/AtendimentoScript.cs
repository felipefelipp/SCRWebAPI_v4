namespace SCRWebAPI_v4.Infrastructure.Scripts
{
    public class AtendimentoScript
    {
        public const string AdicionarAtendimento = @"INSERT INTO Atendimento (PacienteId, SenhaClassificacao, DataAtendimento, InseridoPor, InseridoEm, ModificadoEm, ModificadoPor) 
                                                     OUTPUT INSERTED.AtendimentoPacienteId
                                                     VALUES (@PacienteId, @SenhaClassificacao, @DataAtendimento, @InseridoPor, @InseridoEm,@ModificadoEm, @ModificadoPor)";

        public const string ObterAtendimentoPorId = "SELECT * FROM Atendimento WITH (NOLOCK) WHERE AtendimentoPacienteId = @AtendimentoPacienteId";
       
        public const string ObterAtendimentosPorIdPaciente = "SELECT * FROM Atendimento WITH (NOLOCK) WHERE PacienteId = @PacienteId";

        public const string ObterAtendimentos = "SELECT * FROM Atendimento WITH (NOLOCK) ORDER BY AtendimentoPacienteId OFFSET @offset ROWS FETCH NEXT @PageSize ROWS ONLY";

        public const string AtualizarIdPacienteAtendimento = "UPDATE Atendimento SET PacienteId = @PacienteId WHERE AtendimentoPacienteId = @AtendimentoPacienteId";


    }
}
