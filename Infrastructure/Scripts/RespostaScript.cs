namespace SCRWebAPI_v4.Infrastructure.Scripts
{
    public class RespostaScript
    {
        public const string ObterResposta = "SELECT * FROM Resposta WITH (nolock) WHERE RespostaId = @RespostaId ";

        public const string ObterRespostas = "SELECT * FROM Resposta WITH (nolock)";

        public const string ExcluirResposta = "DELETE FROM Resposta WHERE RespostaId = @RespostaId";
    }
}
