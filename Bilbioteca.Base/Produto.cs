using System;

namespace ProjetoLoja;

public class Produto
{
    public string Nome { get; set; }
    public double Valor { get; set; }
    public int QuantidadeEmEstoque { get; set; }
    public int ID{ get; set; }
    public Fornecedor FornecedorDoProduto;

    public Produto(string nome, double valor, int quantidade, Fornecedor fornecedor)
    {
        Nome = nome;
        Valor = valor;
        QuantidadeEmEstoque = quantidade;
        FornecedorDoProduto = fornecedor;
    }

}
