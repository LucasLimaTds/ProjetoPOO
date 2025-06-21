using System;
using ProjetoLoja;

namespace Bilbioteca.Base;

public class Cliente : IObjetoComId
{
    public int ID { get; set; }
    public Usuario UsuarioDoCliente { get; set; }
    public Endereco EnderecoDoCliente { get; set; }
    public String Telefone;
    public String Nome;
    public Cliente(String telefone, String nome, Endereco endereco)
    {
        Telefone = telefone;
        Nome = Nome;
        EnderecoDoCliente = endereco;
    }  
}
