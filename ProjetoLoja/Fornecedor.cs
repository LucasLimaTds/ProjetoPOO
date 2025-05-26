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

    public Fornecedor(string nome, string email, string telefone, int id, string rua, string numero, string complemento, string bairro, string cep, string cidade, string estado)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        ID = id;
        Rua = rua;
        Numero = numero;
        Complemento = complemento;
        Bairro = bairro;
        CEP = cep;
        Cidade = cidade;
        Estado = estado;
    }
    

}
