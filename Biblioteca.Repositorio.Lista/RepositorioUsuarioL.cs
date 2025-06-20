using System;
using Biblioteca.Repositorios.Interfaces;
using Bilbioteca.Base;
using ProjetoLoja;

namespace Biblioteca.Repositorio.Lista;

public class RepositorioUsuarioL : RepositorioBaseL<Usuario>, IRepositorioUsuario
{
    private int idUsuario = 1;

    public RepositorioUsuarioL()
    {
        Valores[0] = new Usuario("AdminMaster", "adminmaster@ucs.br", "Admin", 0, idUsuario++);
    }

    protected override int ObterId()
    {
        return idUsuario++;
    }

    public int ValidarUsuario(string email, string senha)
    {
        for (int i = 0; i < Valores.Count; i++)
        {
            if (email == Valores[i].Email)
            {
                if (senha == Valores[i].Senha)
                {
                    return Valores[i].DireitosDeUsuario;
                }
                else
                {
                    return -1;
                }
            }
        }
        return -1;
    }

    public bool VerificaEmailExistente(string email)
    {
        for (int i = 0; i < Valores.Count; i++)
        {
            if (email == Valores[i].Email)
            {
                return false;
            }
        }
        return true;
    }
}
