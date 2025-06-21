using System;
using ProjetoLoja;

namespace Biblioteca.Repositorios.Interfaces;

public interface IRepositorioUsuario : IRepositorioBase<Usuario>
{
    int ValidarUsuario(string email, string senha);
    bool VerificaEmailExistente(string email);
    void AlterarEmail(String novoEmail, Usuario usuario);
    void AlterarSenha(String senha, Usuario usuario);
}
