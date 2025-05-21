using System;

namespace ProjetoLoja;

public class Usuario
{
    public String Nome { get; set; }
    public String Senha { get; set; }
    public int DireitosDeUsuario { get; set; }
    public int ID { get; set; }

    public Usuario(String nome, String senha, int direito, int id)
    {
        Nome = nome;
        Senha = senha;
        DireitosDeUsuario = direito;
        ID = id;
    }
}
