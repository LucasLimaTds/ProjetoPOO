using System;
using System.ComponentModel;
using System.Globalization;
using Biblioteca.Repositorio.Vetor;
using Biblioteca.Repositorios.Interfaces;

namespace ProjetoLoja;

public class RepositorioFornecedor : RepositorioBase<Fornecedor>, IRepositorioFornecedor
{
    private int idFornecedor = 0;

    public RepositorioFornecedor()
    {
        Valores[0] = new Fornecedor("Sem Fornecedor", "", "", idFornecedor++);
    }

    protected override int ObterId()
    {
        return idFornecedor++;
    }

    public String ConsultarFornecedor(int id)
    {
        Fornecedor Fornecedor = Procura(id);
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
