using System;

namespace ProjetoLoja;

public class Usuario
{
    public string Nome { get; set; }
    public string Senha { get; set; }
    public int DireitosDeUsuario { get; set; }
    public int ID { get; set; }

    public Usuario(string nome, string senha, int direito, int id)
    {
        Nome = nome;
        Senha = senha;
        DireitosDeUsuario = direito;
        ID = id;
    }
}
