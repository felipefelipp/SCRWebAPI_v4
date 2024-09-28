namespace SCRWebAPI_v4.Infrastructure.Scripts
{
    public class PerguntaScript
    {
        public const string ObterPergunta = "SELECT PerguntaId, DescricaoPergunta, CategoriaPerguntaId FROM Pergunta WITH (NOLOCK) WHERE PerguntaId = @PerguntaId";
        public const string AdicionarPergunta = @"INSERT INTO Pergunta 
                                                  (DescricaoPergunta,CategoriaPerguntaId,InseridoEm,InseridoPor,ModificadoEm,ModificadoPor)
                                                  OUTPUT INSERTED.PerguntaId
                                                  VALUES 
                                                  (@DescricaoPergunta, @CategoriaPerguntaId, @InseridoEm, @InseridoPor, @ModificadoEm, @ModificadoPor)";
        public const string ObterPerguntas = "SELECT * FROM Pergunta WITH (NOLOCK)";
        public const string ExcluirPergunta = "DELETE FROM Pergunta WHERE PerguntaId = @PerguntaId";
    }
}
