using System;

namespace ProjetoLoja;

public class Fornecedor : Endereco
{
    public Fornecedor (String nome, String telefone, int id)
    {
        Nome = nome;
        Telefone = telefone;
        ID = id;
    }

    public String Nome { get; set; }
    public String Descricao { get; set; }
    public String Telefone { get; set; }
    public String Email { get; set; }
    public int ID { get; set; }
}
