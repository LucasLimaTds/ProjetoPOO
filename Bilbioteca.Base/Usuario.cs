using System;

namespace ProjetoLoja;

public class Usuario : Endereco
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone{ get; set; }
    public string Senha { get; set; }
    public int DireitosDeUsuario { get; set; }
    public int ID { get; set; }

    public Usuario(string nome, string email, string senha, int direito, int id)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        DireitosDeUsuario = direito;
        ID = id;
    }

    public Usuario(string nome, string email, string telefone, string senha, int direito, string rua, string numero, string complemento, string bairro, string cep, string cidade, string estado)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Senha = senha;
        DireitosDeUsuario = direito;
        Rua = rua;
        Numero = numero;
        Complemento = complemento;
        Bairro = bairro;
        CEP = cep;
        Cidade = cidade;
        Estado = estado;
    }
}
