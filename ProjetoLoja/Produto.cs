using System;

namespace ProjetoLoja;

public class Produto
{
    public String Nome { get; set; }
    public double Valor { get; set; }
    public int QuantidadeEmEstoque { get; set; }
    public Fornecedor FornecedorDoProduto;
}
