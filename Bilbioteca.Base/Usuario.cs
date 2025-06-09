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

    public Usuario(string nome, string email, string telefone, string senha, int direito, string[] endereco)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Senha = senha;
        DireitosDeUsuario = direito;
        Rua = endereco[0];
        Numero = endereco[1];
        Complemento = endereco[2];
        Bairro = endereco[3];
        CEP = endereco[4];
        Cidade = endereco[5];
        Estado = endereco[6];
    }
}
