namespace SCRWebAPI_v4.Infrastructure.Scripts
{
    public class RespostaSelecionadaScript
    {
        public const string AdicionarRespostaSelecionada = @"
                INSERT INTO RespostaSelecionada (
                    PerguntaId, RespostaId, ValorRespostaTexto, ValorRespostaTextoArea, 
                    ClassificacaoPacienteId, InseridoEm, InseridoPor, ModificadoEm, ModificadoPor, RespostaDateTime
                ) OUTPUT INSERTED.RespostaSelecionadaId
                VALUES (
                    @PerguntaId, @RespostaId, @ValorRespostaTexto, @ValorRespostaTextoArea, 
                    @ClassificacaoPacienteId, @InseridoEm, @InseridoPor, @ModificadoEm, @ModificadoPor, @RespostaDateTime
                )";

        public const string ObterRespostaSelecionada = "SELECT * FROM RespostaSelecionada WHERE RespostaSelecionadaId = @RespostaSelecionadaId";
        
        public const string ObterRespostasSelecionadas = "SELECT * FROM RespostaSelecionada";

        public const string ExcluirRespostaSelecionada = "DELETE FROM RespostaSelecionada WHERE RespostaSelecionadaId = @RespostaSelecionadaId";

    }
}
