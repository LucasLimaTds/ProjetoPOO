using System;
using Bilbioteca.Base;

namespace ProjetoLoja;

public class Fornecedor : IObjetoComId
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public int ID { get; set; }

    public Endereco EnderecoDoFornecedor { get; set; }

    public Fornecedor()
    {
        
    }

    public Fornecedor(string nome, string email, string telefone, int id)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        ID = id;
    }

    public Fornecedor(string nome, string email, string descricao, string telefone, Endereco endereco)
    {
        Nome = nome;
        Email = email;
        Descricao = descricao;
        Telefone = telefone;
        EnderecoDoFornecedor = endereco;
    }

    public override string ToString()
    {
        return $"ID: {ID} | Nome: {Nome}";
    }
    

}
