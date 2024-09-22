using AutoMapper;
using Dapper;
using Domain.AggregatesModel.Cliente;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Scripts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;
using System.Data;
using System.Text;
using static Dapper.SqlMapper;

namespace Infrastructure.Repositories.SqlServer
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ILogger<PacienteRepository> _logger;
        private readonly IMapper _mapper;
        private readonly DapperContext _context;
        public PacienteRepository(DapperContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Paciente> AdicionarPaciente(Paciente paciente)
        {
            try
            {
                var query = PacienteScripts.AdicionarPaciente;
                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("Nome", paciente.Nome, DbType.String);
                parameters.Add("DataNascimento", paciente.DataNascimento, DbType.DateTime);
                parameters.Add("CPF", paciente.CPF, DbType.String);
                parameters.Add("RG", paciente.RG, DbType.String);
                parameters.Add("Celular", paciente.Celular, DbType.String);
                parameters.Add("Email", paciente.Email, DbType.String);
                parameters.Add("Telefone", paciente.Telefone, DbType.String);
                parameters.Add("Rua", paciente.Rua, DbType.String);
                parameters.Add("Numero", paciente.Numero, DbType.String);
                parameters.Add("Bairro", paciente.Bairro, DbType.String);
                parameters.Add("Municipio", paciente.Municipio, DbType.String);
                parameters.Add("UF", paciente.UF, DbType.String);
                parameters.Add("CEP", paciente.CEP, DbType.String);
                parameters.Add("Sexo", paciente.Sexo, DbType.String);
                parameters.Add("Profissao", paciente.Profissao, DbType.String);

                await connection.ExecuteAsync(query, parameters);

                var pacienteInserido = await ObterPaciente(cpf: paciente.CPF);

                return pacienteInserido;
            }
            catch (SqlException ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao acessar o banco de dados", ex);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao adicionar paciente", ex);
            }
        }


        public async Task<Paciente> ObterPaciente(int? id = null,
                                                  string? cpf = null,
                                                  string? nome = null,
                                                  DateTime? dataNascimento = null,
                                                  string? rg = null,
                                                  string? celular = null,
                                                  string? email = null,
                                                  string? telefone = null,
                                                  string? rua = null,
                                                  int? numero = null,
                                                  string? bairro = null,
                                                  string? municipio = null,
                                                  string? uf = null,
                                                  string? cep = null,
                                                  char? sexo = null,
                                                  string? profissao = null)
        {
            try
            {
                var query = new StringBuilder(PacienteScripts.ObterPaciente);
                var parameters = new DynamicParameters();

                if (id.HasValue)
                {
                    query.Append(" AND PacienteId = @PacienteId");
                    parameters.Add("PacienteId", id.Value, DbType.Int32);
                }

                if (!string.IsNullOrEmpty(cpf))
                {
                    query.Append(" AND CPF = @CPF");
                    parameters.Add("CPF", cpf, DbType.String);
                }

                if (!string.IsNullOrEmpty(nome))
                {
                    query.Append(" AND Nome LIKE @Nome");
                    parameters.Add("Nome", $"%{nome}%", DbType.String);
                }

                if (dataNascimento.HasValue)
                {
                    query.Append(" AND DataNascimento = @DataNascimento");
                    parameters.Add("DataNascimento", dataNascimento.Value, DbType.DateTime);
                }

                if (!string.IsNullOrEmpty(rg))
                {
                    query.Append(" AND RG = @RG");
                    parameters.Add("RG", rg, DbType.String);
                }

                if (!string.IsNullOrEmpty(celular))
                {
                    query.Append(" AND Celular = @Celular");
                    parameters.Add("Celular", celular, DbType.String);
                }

                if (!string.IsNullOrEmpty(email))
                {
                    query.Append(" AND Email = @Email");
                    parameters.Add("Email", email, DbType.String);
                }

                if (!string.IsNullOrEmpty(telefone))
                {
                    query.Append(" AND Telefone = @Telefone");
                    parameters.Add("Telefone", telefone, DbType.String);
                }

                if (!string.IsNullOrEmpty(rua))
                {
                    query.Append(" AND Rua = @Rua");
                    parameters.Add("Rua", rua, DbType.String);
                }

                if (numero.HasValue)
                {
                    query.Append(" AND Numero = @Numero");
                    parameters.Add("Numero", numero.Value, DbType.Int32);
                }

                if (!string.IsNullOrEmpty(bairro))
                {
                    query.Append(" AND Bairro = @Bairro");
                    parameters.Add("Bairro", bairro, DbType.String);
                }

                if (!string.IsNullOrEmpty(municipio))
                {
                    query.Append(" AND Municipio = @Municipio");
                    parameters.Add("Municipio", municipio, DbType.String);
                }

                if (!string.IsNullOrEmpty(uf))
                {
                    query.Append(" AND UF = @UF");
                    parameters.Add("UF", uf, DbType.String);
                }

                if (!string.IsNullOrEmpty(cep))
                {
                    query.Append(" AND CEP = @CEP");
                    parameters.Add("CEP", cep, DbType.String);
                }

                if (sexo.HasValue)
                {
                    query.Append(" AND Sexo = @Sexo");
                    parameters.Add("Sexo", sexo.Value, DbType.String);
                }

                if (!string.IsNullOrEmpty(profissao))
                {
                    query.Append(" AND Profissao = @Profissao");
                    parameters.Add("Profissao", profissao, DbType.String);
                }

                using var connection = _context.CreateConnection();
                var result = await connection.QueryAsync<Paciente>(query.ToString(), parameters);

                return result.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao acessar o banco de dados", ex);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao obter paciente", ex);
            }
        }


        public async Task<List<Paciente>> ObterPacientes(Parameters parameters)
        {
            try
            {
                var query = new StringBuilder(PacienteScripts.ObterPacientes);
                using var connection = _context.CreateConnection();
                var result = await connection.QueryAsync<Paciente>(query.ToString(), new { Offset = parameters.OffSet, PageSize = parameters.PageSize });
                return result.ToList();
            }
            catch (SqlException ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao acessar o banco de dados", ex);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao obter pacientes", ex);
            }
        }

        public async Task<bool> AtualizarPaciente(Paciente paciente)
        {
            try
            {
                var parameters = new DynamicParameters();
                var updateFields = new List<string>();
                var conditionFields = new List<string>();

                if (!string.IsNullOrEmpty(paciente.Nome))
                {
                    updateFields.Add(" Nome = @Nome");
                    parameters.Add("Nome", paciente.Nome, DbType.String);
                }

                if (paciente.DataNascimento.HasValue)
                {
                    updateFields.Add(" DataNascimento = @DataNascimento");
                    parameters.Add("DataNascimento", paciente.DataNascimento, DbType.DateTime);
                }

                if (!string.IsNullOrEmpty(paciente.Celular))
                {
                    updateFields.Add(" Celular = @Celular");
                    parameters.Add("Celular", paciente.Celular, DbType.String);
                }

                if (!string.IsNullOrEmpty(paciente.Email))
                {
                    updateFields.Add(" Email = @Email");
                    parameters.Add("Email", paciente.Email, DbType.String);
                }

                if (!string.IsNullOrEmpty(paciente.Telefone))
                {
                    updateFields.Add(" Telefone = @Telefone");
                    parameters.Add("Telefone", paciente.Telefone, DbType.String);
                }

                if (!string.IsNullOrEmpty(paciente.Rua))
                {
                    updateFields.Add(" Rua = @Rua");
                    parameters.Add("Rua", paciente.Rua, DbType.String);
                }

                if (paciente.Numero.HasValue)
                {
                    updateFields.Add(" Numero = @Numero");
                    parameters.Add("Numero", paciente.Numero, DbType.Int32);
                }

                if (!string.IsNullOrEmpty(paciente.Bairro))
                {
                    updateFields.Add(" Bairro = @Bairro");
                    parameters.Add("Bairro", paciente.Bairro, DbType.String);
                }

                if (!string.IsNullOrEmpty(paciente.Municipio))
                {
                    updateFields.Add(" Municipio = @Municipio");
                    parameters.Add("Municipio", paciente.Municipio, DbType.String);
                }

                if (!string.IsNullOrEmpty(paciente.UF))
                {
                    updateFields.Add(" UF = @UF");
                    parameters.Add("UF", paciente.UF, DbType.String);
                }

                if (!string.IsNullOrEmpty(paciente.CEP))
                {
                    updateFields.Add(" CEP = @CEP");
                    parameters.Add("CEP", paciente.CEP, DbType.String);
                }

                if (paciente.Sexo.HasValue)
                {
                    updateFields.Add(" Sexo = @Sexo");
                    parameters.Add("Sexo", paciente.Sexo.Value, DbType.String);
                }

                if (!string.IsNullOrEmpty(paciente.Profissao))
                {
                    updateFields.Add(" Profissao = @Profissao");
                    parameters.Add("Profissao", paciente.Profissao, DbType.String);
                }


                if (!string.IsNullOrEmpty(paciente.CPF))
                {
                    updateFields.Add(" CPF = @CPF");
                    parameters.Add("CPF", paciente.CPF, DbType.String);
                }

                if (!string.IsNullOrEmpty(paciente.RG))
                {
                    updateFields.Add(" RG = @RG");
                    parameters.Add("RG", paciente.RG, DbType.String);
                }

                if (paciente.PacienteId.HasValue)
                {
                    conditionFields.Add(" AND PacienteId = @PacienteId");
                    parameters.Add("PacienteId", paciente.PacienteId, DbType.Int32);
                }

                var query = $@"
                    UPDATE Paciente
                    SET {string.Join(", ", updateFields)}
                    WHERE 1=1
                    {string.Join(" AND ", conditionFields)}";

                using var connection = _context.CreateConnection();
                var rowsAffected = await connection.ExecuteAsync(query, parameters);

                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao acessar o banco de dados", ex);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao atualizar paciente", ex);
            }
        }
    }
}
