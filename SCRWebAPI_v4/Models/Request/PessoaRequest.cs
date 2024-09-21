namespace SCRWebAPI_v4.Api.Models.Request
{
    public class PessoaRequest
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
    }
}
