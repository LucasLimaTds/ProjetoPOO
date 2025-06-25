using System;
using Biblioteca.Base.EstruturaDaLoja;
using Bilbioteca.Base;

namespace ProjetoLoja;

public class Cliente : IObjetoComId
{
    public int ID { get; set; }
    public Usuario UsuarioDoCliente { get; set; }
    public Endereco EnderecoDoCliente { get; set; }
    public string Telefone;
    public string Nome;
    public Cliente(string telefone, string nome, Endereco endereco, Usuario usuario)
    {
        Telefone = telefone;
        Nome = nome;
        EnderecoDoCliente = endereco;
        UsuarioDoCliente = usuario;
    }  
}
