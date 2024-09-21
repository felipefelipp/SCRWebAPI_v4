using Domain.AggregatesModel.Cliente;

namespace Infrastructure.Scripts
{
    public class PacienteScripts
    {
        public const string ObterPaciente = "SELECT * FROM Paciente WHERE 1=1";
        public const string AdicionarPaciente = @"INSERT INTO Paciente (Nome, DataNascimento, CPF, RG, Celular, Email, Telefone, Rua, Numero, Bairro, Municipio, UF, CEP, Sexo, Profissao) " +
                                                "VALUES (@Nome, @DataNascimento, @CPF, @RG, @Celular, @Email, @Telefone, @Rua, @Numero, @Bairro, @Municipio, @UF, @CEP, @Sexo, @Profissao)";
        public const string ObterPacientes = "SELECT * FROM Paciente ORDER BY PacienteId OFFSET @offset ROWS FETCH NEXT @PageSize ROWS ONLY";
    }
}
