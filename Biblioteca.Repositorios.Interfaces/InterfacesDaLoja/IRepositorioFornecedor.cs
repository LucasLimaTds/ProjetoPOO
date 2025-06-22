using System;
using ProjetoLoja;

namespace Biblioteca.Repositorios.Interfaces;

public interface IRepositorioFornecedor : IRepositorioBase<Fornecedor>
{
    String ConsultarFornecedor(int id);
    bool VerificaExistenciaFornecedor();
    void AlterarNome(string novoNome, Fornecedor FornecedorEditar);
    void AlterarDescricao(string novaDescricao, Fornecedor FornecedorEditar);
    void AlterarTelefone(string novoTelefone, Fornecedor FornecedorEditar);
    void AlterarEmail(string novoEmail, Fornecedor FornecedorEditar);
    void AlterarEndereco(Endereco endereco, Fornecedor FornecedorEditar);
}
