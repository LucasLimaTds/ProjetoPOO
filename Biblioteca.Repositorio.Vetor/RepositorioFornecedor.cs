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

    protected int ObterId()
    {
        return idFornecedor++;
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

    public Fornecedor[] ListarFornecedores()
    {
        return TodosFornecedores;
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

    public Fornecedor ProcuraFornecedor(int id)
    {
        for (int i = 0; i < TodosFornecedores.Length; i++)
        {
            if (TodosFornecedores[i].ID == id)
            {
                return TodosFornecedores[i];
            }
        }
        return null;
    }

    public String ConsultarFornecedor(int id)
    {
        Fornecedor Fornecedor = ProcuraFornecedor(id);
        if (Fornecedor.ID == 0)
        {
            return $"Fornecedor ID: {Fornecedor.ID} | Nome: {Fornecedor.Nome} | Email: {Fornecedor.Email} | Telefone: {Fornecedor.Telefone} | Descrição: {Fornecedor.Descricao}";
        }
        if (Fornecedor != null)
        {
            return $"Fornecedor ID: {Fornecedor.ID} | Nome: {Fornecedor.Nome} | Email: {Fornecedor.Email} | Telefone: {Fornecedor.Telefone} | Descrição: {Fornecedor.Descricao}\nEndereço:  Rua: {Fornecedor.EnderecoDoFornecedor.Rua} | Número: {Fornecedor.EnderecoDoFornecedor.Numero} | Complemento: {Fornecedor.EnderecoDoFornecedor.Complemento} | Bairro: {Fornecedor.EnderecoDoFornecedor.Bairro} | CEP: {Fornecedor.EnderecoDoFornecedor.CEP} | Cidade: {Fornecedor.EnderecoDoFornecedor.Cidade} | Estado: {Fornecedor.EnderecoDoFornecedor.Estado}\n";
        }
        return "Não há fornecedores cadastrados!";
    }

    public bool VerificaExistenciaFornecedor()
    {
        if (idFornecedor > 1)
        {
            return true;
        }

        return false;
    }

    public void AlterarNome(string novoNome, Fornecedor FornecedorEditar)
    {
        FornecedorEditar.Nome = novoNome;
    }

    public void AlterarDescricao(string novaDescricao, Fornecedor FornecedorEditar)
    {
        FornecedorEditar.Descricao = novaDescricao;
    }

    public void AlterarTelefone(string novoTelefone, Fornecedor FornecedorEditar)
    {
        FornecedorEditar.Telefone = novoTelefone;
    }
    public void AlterarEmail(string novoEmail, Fornecedor FornecedorEditar)
    {
        FornecedorEditar.Email = novoEmail;
    }
    public void AlterarEndereco(Endereco endereco, Fornecedor FornecedorEditar)
    {
        FornecedorEditar.EnderecoDoFornecedor = endereco;
    }
}
