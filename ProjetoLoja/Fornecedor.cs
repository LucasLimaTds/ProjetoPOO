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

    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public int ID { get; set; }
}
