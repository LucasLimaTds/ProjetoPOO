using System;
using System.ComponentModel;
using System.Globalization;

namespace ProjetoLoja;

public class RepositorioFornecedor
{
    private Fornecedor[] TodosFornecedores = new Fornecedor[1];
    private int idFornecedor = 0;

    public RepositorioFornecedor()
    {
        TodosFornecedores[0] = new Fornecedor("Sem Fornecedor", "", "", idFornecedor++);
    }

    public void CadastrarFornecedor(Fornecedor NovoFornecedor)
    {
        Fornecedor[] novosFornecedores = new Fornecedor[TodosFornecedores.Length + 1];

        for (int i = 0; i < TodosFornecedores.Length; i++)
        {
            novosFornecedores[i] = TodosFornecedores[i];
        }

        NovoFornecedor.ID = idFornecedor++;
        novosFornecedores[novosFornecedores.Length - 1] = NovoFornecedor;
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
            Console.WriteLine($"Fornecedor ID: {TodosFornecedores[i].ID} | Nome: {TodosFornecedores[i].Nome} | Email: {TodosFornecedores[i].Email} | Telefone: {TodosFornecedores[i].Telefone} | Descrição: {TodosFornecedores[i].Descricao}");
            TodosFornecedores[i].ListarEndereço();
            Console.WriteLine("-------------------------------------------------------------------");
        }
    }

    public bool VerificaExistenciaFornecedor()
    {
        if (idFornecedor > 1)
        {
            return true;
        }

        return false;
    }

    public void AlterarNome(string novoNome, int i)
    {
        TodosFornecedores[i].Nome = novoNome;
    }

    public void AlterarDescricao(string novaDescricao, int i)
    {
        TodosFornecedores[i].Descricao = novaDescricao;
    }

    public void AlterarTelefone(string novoTelefone, int i)
    {
        TodosFornecedores[i].Telefone = novoTelefone;
    }
    public void AlterarEmail(string novoEmail, int i)
    {
        TodosFornecedores[i].Email = novoEmail;
    }
    public void AlterarEndereco(string novaRua, string novoNumero, string novoComplemento, string novoBairro, string novoCEP, string novaCidade, string novoEstado, int i)
    {
        TodosFornecedores[i].Rua = novaRua;
        TodosFornecedores[i].Numero = novoNumero;
        TodosFornecedores[i].Complemento = novoComplemento;
        TodosFornecedores[i].Bairro = novoBairro;
        TodosFornecedores[i].CEP = novoCEP;
        TodosFornecedores[i].Cidade = novaCidade;
        TodosFornecedores[i].Estado = novoEstado;
    }

    public Fornecedor RetornaFornecedor(int id)
    {
        return TodosFornecedores[id];
    }
}
