using System;

namespace ProjetoLoja;

public class Usuario
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone{ get; set; }
    public string Senha { get; set; }
    public int DireitosDeUsuario { get; set; }
    public int ID { get; set; }

    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string CEP { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }

    public Usuario(string nome, string email, string senha, int direito, int id)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        DireitosDeUsuario = direito;
        ID = id;
    }

    public Usuario(string nome, string email, string telefone, string senha, int direito, Endereco endereco)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Senha = senha;
        DireitosDeUsuario = direito;
        Rua = endereco.Rua;
        Numero = endereco.Numero;
        Complemento = endereco.Complemento;
        Bairro = endereco.Bairro;
        CEP = endereco.CEP;
        Cidade = endereco.Cidade;
        Estado = endereco.Estado;
    }
}
