using System;
using System.ComponentModel;
using System.Globalization;
using Biblioteca.Repositorio.Vetor;
using Biblioteca.Repositorios.Interfaces;
using System.Text.Json;

namespace ProjetoLoja;

public class RepositorioUsuarioV : RepositorioBaseV<Usuario>, IRepositorioUsuario
{
    private int idUsuario = 1;

    public RepositorioUsuarioV()
    {
        Valores[0] = new Usuario("1", "Admin", 0, idUsuario++);
    }

    protected override int ObterId()
    {
        return idUsuario++;
    }

    public int ValidarUsuario(string email, string senha, ref Usuario usuario)
    {
        for (int i = 0; i < Valores.Length; i++)
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
        for (int i = 0; i < Valores.Length; i++)
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
        return Valores[Valores.Length - 1];
    }

    public void AlterarEmail(string novoEmail, Usuario usuario)
    {
        usuario.Email = novoEmail;
    }

    public void AlterarSenha(string novoSenha, Usuario usuario)
    {
        usuario.Senha = novoSenha;
    }
    
    public void SalvaUsuarios()
    {
        if (Valores[0] != null)
        {
            string SalvaJson = JsonSerializer.Serialize(Valores);
            File.WriteAllText("dados_usuarios.json", SalvaJson);
            SalvaJson = JsonSerializer.Serialize(idUsuario);
            File.WriteAllText("id_usuario.json", SalvaJson);
        }
    }

    public void CarregaUsuarios()
    {
        if (!File.Exists("dados_usuarios.json"))
        {
            File.WriteAllText("dados_usuarios.json", null);
        }
        else
        {
            string CarregaJson = File.ReadAllText("dados_usuarios.json");
            Valores = JsonSerializer.Deserialize<Usuario[]>(CarregaJson);
        }

        if (!File.Exists("id_usuario.json"))
        {
            File.WriteAllText("id_usuario.json", null);
        }
        else
        {
            string CarregaId = File.ReadAllText("id_usuario.json");
            idUsuario = JsonSerializer.Deserialize<int>(CarregaId);
        }
    }
}
