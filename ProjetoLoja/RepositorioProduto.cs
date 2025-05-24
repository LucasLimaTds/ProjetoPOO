using System;

namespace ProjetoLoja;

public class RepositorioProduto
{
    public Produto[] TodosProdutos = new Produto[1];
    private int idProduto = 1;

    public RepositorioProduto()
    {
        TodosProdutos[0] = new Produto("Produto1", 2, idProduto++);
    }

    public void CadastrarProduto(String nome, double valor)
    {
        Produto[] novosProdutos = new Produto[TodosProdutos.Length + 1];

        for (int i = 0; i < TodosProdutos.Length; i++)
        {
            novosProdutos[i] = TodosProdutos[i];
        }

        novosProdutos[novosProdutos.Length - 1] = new Produto(nome, valor, idProduto++);
        TodosProdutos = novosProdutos;
    }
    
    public void ListarProdutos()
    {
        int i;
        Console.WriteLine("Produtos cadastrados:");
        for (i = 0; i < TodosProdutos.Length; i++)
        {
            Console.WriteLine("Produto ID " + TodosProdutos[i].ID + " | Nome: " + TodosProdutos[i].Nome + " | Valor do Produto: " + TodosProdutos[i].Valor);
        }

        Console.WriteLine("-------------------------------------------------------------------");
    }
}
