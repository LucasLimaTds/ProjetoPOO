using System;
using ProjetoLoja;

namespace Biblioteca.Repositorios.Interfaces;

public interface IRepositorioUsuario : IRepositorioBase<Usuario>
{
    int ValidarUsuario(string email, string senha);
    bool VerificaEmailExistente(string email);
}
