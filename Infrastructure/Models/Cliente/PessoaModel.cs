namespace Infrastructure.Models.Cliente;

public abstract class PessoaModel
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }

}
