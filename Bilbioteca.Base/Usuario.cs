using System;
using Bilbioteca.Base;

namespace ProjetoLoja;

public class Usuario : IObjetoComId
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone{ get; set; }
    public string Senha { get; set; }
    public int DireitosDeUsuario { get; set; }
    public int ID { get; set; }

    public Endereco EnderecoDoUsuario;

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
        EnderecoDoUsuario = endereco;
    }
}
