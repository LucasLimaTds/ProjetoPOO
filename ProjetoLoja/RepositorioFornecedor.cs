using System;
using System.ComponentModel;
using System.Globalization;

namespace ProjetoLoja;

public class RepositorioFornecedor
{
    public Fornecedor[] TodosFornecedores = new Fornecedor[1];
    private int idFornecedor = 1;

    public RepositorioFornecedor()
    {
        TodosFornecedores[0] = new Fornecedor("Fornecedor1", "fornecedor1@gmail.com", "55 54 999999999", idFornecedor++);
    }

    public void CadastrarFornecedor(string nome, string email, string descricao, string telefone, string rua, string numero, string complemento, string bairro, string CEP, string cidade, string estado)
    {
        Fornecedor[] novosFornecedores = new Fornecedor[TodosFornecedores.Length + 1];

        for (int i = 0; i < TodosFornecedores.Length; i++)
        {
            novosFornecedores[i] = TodosFornecedores[i];
        }

        novosFornecedores[novosFornecedores.Length - 1] = new Fornecedor(nome, email, descricao, telefone, idFornecedor++, rua, numero, complemento, bairro, CEP, cidade, estado);
        TodosFornecedores = novosFornecedores;
    }

    public void ListarFornecedores()
    {
        int i;
        Console.WriteLine("\nFornecedores cadastrados:");
        for (i = 0; i < TodosFornecedores.Length; i++)
        {
            Console.WriteLine($"Fornecedor ID: {TodosFornecedores[i].ID} | Nome: {TodosFornecedores[i].Nome}");
        }

        Console.WriteLine("-------------------------------------------------------------------");
    }

    public void RemoverFornecedor(int idRemocao)
    {
        Fornecedor[] novosFornecedores = new Fornecedor[TodosFornecedores.Length - 1];
        int j = 0;
        for (int i = 0; j < TodosFornecedores.Length; i++, j++)
        {
            if (TodosFornecedores[j].ID == idRemocao)
            {
                if ((j + 1) < TodosFornecedores.Length)
                {
                    novosFornecedores[i] = TodosFornecedores[j + 1];
                    j++;
                }
                else break;
            }
            else
            {
                novosFornecedores[i] = TodosFornecedores[j];
            }
        }
        TodosFornecedores = novosFornecedores;
    }

    public int ProcuraFornecedor(int id)
    {
        for (int i = 0; i < TodosFornecedores.Length; i++)
        {
            if (TodosFornecedores[i].ID == id)
            {
                return i;
            }
        }
        Console.WriteLine("Fornecedor não encontrado!");
        Console.WriteLine("-------------------------------------------------------------------");
        return -1;
    }

    public void ConsultarFornecedor(int id)
    {
        int i;
        i = ProcuraFornecedor(id);
        if (i != -1)
        {
            Console.WriteLine($"Fornecedor ID: {TodosFornecedores[i].ID} | Nome: {TodosFornecedores[i].Nome} | Email: {TodosFornecedores[i].Email} | Descrição: {TodosFornecedores[i].Descricao}");
            TodosFornecedores[i].ListarEndereço();
            Console.WriteLine("-------------------------------------------------------------------");
        }
    }
}
