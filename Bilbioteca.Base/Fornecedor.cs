using System;

namespace ProjetoLoja;

public class Fornecedor : Endereco
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public int ID { get; set; }
    
    public Fornecedor(string nome, string email, string telefone, int id)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        ID = id;
    }

    public Fornecedor(string nome, string email, string descricao, string telefone, string[] endereco)
    {
        Nome = nome;
        Email = email;
        Descricao = descricao;
        Telefone = telefone;
        Rua = endereco[0];
        Numero = endereco[1];
        Complemento = endereco[2];
        Bairro = endereco[3];
        CEP = endereco[4];
        Cidade = endereco[5];
        Estado = endereco[6];
    }
    

}
