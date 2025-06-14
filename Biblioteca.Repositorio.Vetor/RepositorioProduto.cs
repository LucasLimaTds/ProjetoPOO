using System;

namespace ProjetoLoja;

public class RepositorioProduto
{
    private Produto[] TodosProdutos = new Produto[1];
    private int idProduto = 1;

    public void CadastrarProduto(Produto NovoProduto)
    {
        if (idProduto == 1)
        {

            NovoProduto.ID = idProduto++;
            TodosProdutos[0] = NovoProduto;
            return;
        }
        Produto[] novosProdutos = new Produto[TodosProdutos.Length + 1];

        for (int i = 0; i < TodosProdutos.Length; i++)
        {
            novosProdutos[i] = TodosProdutos[i];
        }

        NovoProduto.ID = idProduto++;
        novosProdutos[novosProdutos.Length - 1] = NovoProduto;
        TodosProdutos = novosProdutos;
    }

    public Produto[] ListarProdutos()
    {
        return TodosProdutos;
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

    public Produto ProcuraProduto(int id)
    {
        for (int i = 0; i < TodosProdutos.Length; i++)
        {
            if (TodosProdutos[i].ID == id)
            {
                return TodosProdutos[i];
            }
        }
        Console.WriteLine("Produto não encontrado!");
        Console.WriteLine("-------------------------------------------------------------------");
        return null;
    }

    public void ConsultarProduto(int id)
    {
        Produto Produto = ProcuraProduto(id);
        if (Produto != null)
        {
            Console.WriteLine($"Produto ID: {Produto.ID} | Nome: {Produto.Nome} | Preço: R$ {Produto.Valor} | Fornecedor: {Produto.FornecedorDoProduto.Nome}");
            Console.WriteLine("-------------------------------------------------------------------");
        }
    }

    public void RemocaoDeFornecedor(int idRemocao, Fornecedor fornecedor)
    {
        for (int i = 0; i < TodosProdutos.Length; i++)
        {
            if (idRemocao == TodosProdutos[i].FornecedorDoProduto.ID)
            {
                TodosProdutos[i].FornecedorDoProduto = fornecedor;
            }
        }
    }

    public bool VerificaExistenciaProduto()
    {
        if (idProduto > 1)
        {
            return true; // Há produtos cadastrados
        }
        return false; // Não há produtos cadastrados
    }

    public void AlteraNome(string novoNome, Produto ProdutoAlterado)
    {
        ProdutoAlterado.Nome = novoNome;
    }
    public void AlterarValor(double novoValor, Produto ProdutoAlterado)
    {
        ProdutoAlterado.Valor = novoValor;
    }
    public void AlterarEstoque(int novaQnt, Produto ProdutoAlterado)
    {
        ProdutoAlterado.QuantidadeEmEstoque = novaQnt;
    }
    public void AlterarFornecedor(Fornecedor fornecedor, Produto ProdutoAlterado)
    {
        ProdutoAlterado.FornecedorDoProduto = fornecedor;
    }
}
