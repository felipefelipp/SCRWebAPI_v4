namespace Infrastructure.Models.Classificacao
{
    public class RespostaModel
    {
        public int RespostaId { get; set; }
        public bool RespostaTexto { get; set; }
        public bool RespostaTextoArea { get; set; }
        public string RespostaCheckBox { get; set; }
        public string RespostaComboBox { get; set; }
        public string RespostaRadioButtom { get; set; }
        public DateTime? RespostaData { get; set; }
        public int ValorTipoResposta { get; set; } // Tipo da resposta 
        public string TipoResposta { get; set; }
        public int ValorResposta { get; set; } // Pontuação da resposta
        public int? IdPergunta { get; set; }
    }
}
