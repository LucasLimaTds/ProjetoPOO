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

    public void CadastrarProduto(string nome, double valor, int quantidade, Fornecedor fornecedor)
    {
        Produto[] novosProdutos = new Produto[TodosProdutos.Length + 1];

        for (int i = 0; i < TodosProdutos.Length; i++)
        {
            novosProdutos[i] = TodosProdutos[i];
        }

        novosProdutos[novosProdutos.Length - 1] = new Produto(nome, valor, idProduto++, quantidade, fornecedor);
        TodosProdutos = novosProdutos;
    }

    public void ListarProdutos()
    {
        int i;
        Console.WriteLine("Produtos cadastrados:");
        for (i = 0; i < TodosProdutos.Length; i++)
        {
            Console.WriteLine($"Produto ID: {TodosProdutos[i].ID} | Nome: {TodosProdutos[i].Nome}");
        }

        Console.WriteLine("-------------------------------------------------------------------");
    }

    public void RemoverProduto(int idRemocao)
    {
        Produto[] novosProdutos = new Produto[TodosProdutos.Length - 1];
        int j = 0;
        for (int i = 0; j < TodosProdutos.Length; i++, j++)
        {
            if (TodosProdutos[j].ID == idRemocao)
            {
                if ((j + 1) < TodosProdutos.Length)
                {
                    novosProdutos[i] = TodosProdutos[j + 1];
                    j++;
                }
                else break;
            }
            else
            {
                novosProdutos[i] = TodosProdutos[j];
            }
        }
        TodosProdutos = novosProdutos;
    }
    
    public void ConsultarProduto(int id)
    {
        for (int i = 0; i < TodosProdutos.Length; i++)
        {
            if (TodosProdutos[i].ID == id)
            {
                Console.WriteLine($"Produto ID: {TodosProdutos[i].ID} | Nome: {TodosProdutos[i].Nome} | Valor do produto: R$ {TodosProdutos[i].Valor} | Fornecedor do produto: {TodosProdutos[i].FornecedorDoProduto.Nome}");
                Console.WriteLine("-------------------------------------------------------------------");
                return;
            }
        }

        Console.WriteLine("Produto não encontrado!");
        Console.WriteLine("-------------------------------------------------------------------");
    }
}
