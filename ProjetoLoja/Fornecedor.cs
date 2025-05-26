using System;

namespace ProjetoLoja;

public class Fornecedor : Endereco
{
    public Fornecedor (string nome, string telefone, int id)
    {
        Nome = nome;
        Telefone = telefone;
        ID = id;
    }

    public Fornecedor(string nome, string telefone, int id, string rua, string numero, string complemento, string bairro, string cep, string cidade, string estado)
    {
        Nome = nome;
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
    

    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public int ID { get; set; }
}
