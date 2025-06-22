using System;
using Bilbioteca.Base;

namespace ProjetoLoja;

public class Cliente : IObjetoComId
{
    public int ID { get; set; }
    public Usuario UsuarioDoCliente { get; set; }
    public Endereco EnderecoDoCliente { get; set; }
    public String Telefone;
    public String Nome;
    public Cliente(String telefone, String nome, Endereco endereco, Usuario usuario)
    {
        Telefone = telefone;
        Nome = Nome;
        EnderecoDoCliente = endereco;
        UsuarioDoCliente = usuario;
    }  
}
