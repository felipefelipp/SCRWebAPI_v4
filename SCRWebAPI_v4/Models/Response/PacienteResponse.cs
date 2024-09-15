namespace SCRWebAPI_v4.Api.Models.Response;

public class PacienteResponse
{
    public string Telefone { get; set; }
    public string Rua { get; set; }
    public int Numero { get; set; }
    public string Bairro { get; set; }
    public string Municipio { get; set; }
    public string UF { get; set; }
    public string CEP { get; set; }
    public char Sexo { get; set; }
    public string Profissao { get; set; }
}
