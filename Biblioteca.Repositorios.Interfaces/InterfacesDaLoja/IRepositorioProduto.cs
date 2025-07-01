using System;
using ProjetoLoja;

namespace Biblioteca.Repositorios.Interfaces;

public interface IRepositorioProduto : IRepositorioBase<Produto>
{
    string ConsultarProduto(int id);
    void RemocaoDeFornecedor(int idRemocao, Fornecedor fornecedor);
    bool VerificaExistenciaProduto();
    void AlteraNome(string novoNome, Produto ProdutoAlterado);
    void AlterarValor(double novoValor, Produto ProdutoAlterado);
    void AlterarEstoque(int novaQnt, Produto ProdutoAlterado);
    void AlterarFornecedor(Fornecedor fornecedor, Produto ProdutoAlterado);
    IList<Produto> FiltroNomeProduto(string ProdutoConsultado);
    void SalvaProdutos();
    void CarregaProdutos();
}
