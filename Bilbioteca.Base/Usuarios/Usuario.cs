using System;
using Bilbioteca.Base;

namespace ProjetoLoja;

public class Usuario : IObjetoComId
{
    public string Email { get; set; }
    public string Senha { get; set; }
    public int DireitosDeUsuario { get; set; }
    public int ID { get; set; }

    public Usuario()
    {
        
    }
    
    public Usuario(string email, string senha, int direito)
    {
        Email = email;
        Senha = senha;
        DireitosDeUsuario = direito;
    }

    public Usuario(string email, string senha, int direito, int id)
    {
        Email = email;
        Senha = senha;
        DireitosDeUsuario = direito;
        ID = id;
    }
    
    public override string ToString()
    {
        return $"ID: {ID} | Email: {Email}";
    }
}
