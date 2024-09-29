namespace Domain.AggregatesModel.Classificacao
{
    public class Resposta
    {
        public int RespostaId { get; set; }
        public string? RespostaTexto { get; set; }
        public string? RespostaTextoArea { get; set; }
        public string? RespostaCheckBox { get; set; }
        public string? RespostaComboBox { get; set; }
        public string? RespostaRadioButtom { get; set; }
        public DateTime? RespostaDateTime { get; set; }
        public int? RespostaNumeric { get; set; }
        public int? PontuacaoResposta { get; set; } // Pontuação da resposta
        public int? IdPergunta { get; set; }
        //Adotar a seguinte estratégia, adicionar outra classe para representar os tipos de resposta vinculados a uma pergunta,
        //    Por exemplo: Uma reposta do tipo texto que será utilizado em várias perguntas não terá idPergunta vinculada,
        //                 Uma resposta padrão combobox que tenha um (sim, não, talvez) deverá ser vinculado a uma idPergunta
        //                Deve ser criado uma reposta para cada uma das respostas possivel, 
        //                   por exemplo:  tipo da resposta radioButtom idPergunta 3 resposta sim,
        //                                    tipo da resposta radioButtom idPergunta 3 resposta não,
        //                                        tipo da resposta radioButtom idPergunta 3 resposta talvez,

    }
}
