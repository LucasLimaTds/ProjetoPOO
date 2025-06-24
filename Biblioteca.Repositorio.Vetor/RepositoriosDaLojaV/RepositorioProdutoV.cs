using System;
using System.ComponentModel;
using System.Globalization;
using Biblioteca.Repositorio.Vetor;
using Biblioteca.Repositorios.Interfaces;

namespace ProjetoLoja;

public class RepositorioProdutoV : RepositorioBaseV<Produto>, IRepositorioProduto
{
    private int idProduto = 1;

    protected override int ObterId()
    {
        return idProduto++;
    }

    public String ConsultarProduto(int id)
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
    
    public IList<Produto> Filtro(String ProdutoConsultado)
    {
        return Listar().Where(p => p.Nome.Contains(ProdutoConsultado, StringComparison.OrdinalIgnoreCase) || p.ID.ToString().Contains(ProdutoConsultado)).ToArray();
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
