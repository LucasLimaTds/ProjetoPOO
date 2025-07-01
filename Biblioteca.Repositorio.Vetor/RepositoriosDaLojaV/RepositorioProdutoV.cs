using System;
using System.ComponentModel;
using System.Globalization;
using Biblioteca.Repositorio.Vetor;
using Biblioteca.Repositorios.Interfaces;
using System.Text.Json;

namespace ProjetoLoja;

public class RepositorioProdutoV : RepositorioBaseV<Produto>, IRepositorioProduto
{
    private int idProduto = 1;

    protected override int ObterId()
    {
        return idProduto++;
    }

    public string ConsultarProduto(int id)
    {
        Produto Produto = Procura(id);
        if (Produto != null)
        {
            return $"Produto ID: {Produto.ID} | Nome: {Produto.Nome} | Preço: R$ {Produto.Valor} | Fornecedor: {Produto.FornecedorDoProduto.Nome}";
        }
        return "Produto não encontrado!";
    }
    public void RemocaoDeFornecedor(int idRemocao, Fornecedor fornecedor)
    {
        for (int i = 0; i < Valores.Length; i++)
        {
            if (idRemocao == Valores[i].FornecedorDoProduto.ID)
            {
                Valores[i].FornecedorDoProduto = fornecedor;
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

    public IList<Produto> FiltroNomeProduto(string ProdutoConsultado)
    {
        return Valores.Where(p => p.Nome.Contains(ProdutoConsultado, StringComparison.OrdinalIgnoreCase) || p.ID.ToString().Contains(ProdutoConsultado)).ToArray();
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

   public void SalvaProdutos()
    {
        string SalvaJson = JsonSerializer.Serialize(Valores);
        File.WriteAllText("dados_produtos.json", SalvaJson);
        SalvaJson = JsonSerializer.Serialize(idProduto);
        File.WriteAllText("id_produto.json", SalvaJson);
    }

    public void CarregaProdutos()
    {
        if (!File.Exists("dados_produtos.json"))
        {
            File.WriteAllText("dados_produtos.json", null);
        }
        else
        {
            string CarregaJson = File.ReadAllText("dados_produtos.json");
            if (CarregaJson != null)
            {
                Valores = JsonSerializer.Deserialize<Produto[]>(CarregaJson);                
            }
        }

        if (!File.Exists("id_produto.json"))
        {
            File.WriteAllText("id_produto.json", null);
        }
        else
        {
            string CarregaId = File.ReadAllText("id_produto.json");
            if (CarregaId != null)
            {
                idProduto = JsonSerializer.Deserialize<int>(CarregaId);
            }
        }
    }
}
