using System;

namespace ProjetoLoja;

public class RepositorioFornecedor
{
    public Fornecedor[] TodosFornecedores = new Fornecedor[1];
    private int idFornecedor = 1;

    public RepositorioFornecedor()
    {
        TodosFornecedores[0] = new Fornecedor("Fornecedor1", "55 54 999999999", idFornecedor++); 
    }

    public void CadastrarFornecedor(String nome, String telefone)
    {
        Fornecedor[] novosFornecedores = new Fornecedor[TodosFornecedores.Length + 1];

        for (int i = 0; i < TodosFornecedores.Length; i++)
        {
            novosFornecedores[i] = TodosFornecedores[i];
        }

        novosFornecedores[novosFornecedores.Length - 1] = new Fornecedor(nome, telefone, idFornecedor);
        TodosFornecedores = novosFornecedores;
    }

}
