using Infrastructure.Models.Cliente;

namespace Infrastructure.Models.Funcionario;

public class UsuarioModel : PessoaModel
{
    public int UsuarioId { get; set; }
    public string COREN { get; set; }
    public string CRM { get; set; }
    public string Senha { get; set; }
    //public Usuario(string nome,
    //               DateTime dtNascimento,
    //               string CPF,
    //               string RG,
    //               string celular,
    //               string email,
    //               string senha,
    //               string coren,
    //               string crm) : base(nome, dtNascimento, CPF, RG, celular, email)
    //{
    //    COREN = coren;
    //    CRM = crm;
    //    Senha = senha;
    //}

    public UsuarioModel() { }
}
