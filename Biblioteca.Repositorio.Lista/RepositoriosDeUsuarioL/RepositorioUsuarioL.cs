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
        Cadastrar(new Usuario("1", "Admin", 0, idUsuario++)); 
    }

    protected override int ObterId()
    {
        return idUsuario++;
    }

    public int ValidarUsuario(string email, string senha, Usuario usuario)
    {
        for (int i = 0; i < Valores.Count; i++)
        {
            if (email == Valores[i].Email)
            {
                if (senha == Valores[i].Senha)
                {
                    usuario = Valores[i];
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

    public Usuario RetornaUltimo()
    {
        return Valores[Valores.Count-1];
    }

    public void AlterarEmail(String novoEmail, Usuario usuario)
    {
        usuario.Email = novoEmail;
    }
    
    public void AlterarSenha (String novoSenha, Usuario usuario)
    {
        usuario.Senha = novoSenha;
    }
}
