using System;

namespace ProjetoLoja;

public class Fornecedor
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public int ID { get; set; }

    public Endereco EnderecoDoFornecedor;
    
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
    

}
