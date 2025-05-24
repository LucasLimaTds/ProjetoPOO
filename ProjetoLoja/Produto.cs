using System;

namespace ProjetoLoja;

public class Produto
{
    public Produto(String nome, double valor, int id)
    {
        Nome = nome;
        Valor = valor;
        ID = id;
    }

    public String Nome { get; set; }
    public double Valor { get; set; }
    public int QuantidadeEmEstoque { get; set; }
    public int ID{ get; set; }
    public Fornecedor FornecedorDoProduto;
}
