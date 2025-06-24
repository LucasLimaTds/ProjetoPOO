using System;
using Biblioteca.Repositorios.Interfaces;
using Bilbioteca.Base;
using ProjetoLoja;

namespace Biblioteca.Repositorio.Lista;

public class RepositorioClienteL : RepositorioBaseL<Cliente>, IRepositorioCliente
{
    private int idCliente = 1;
    protected override int ObterId()
    {
        return idCliente++;
    }

    public Cliente ProcuraCliente(Usuario usuario)
    {
        for (int i = 0; i < Valores.Count; i++)
        {
            if (Valores[i].UsuarioDoCliente == usuario)
            {
                return Valores[i];
            }
        }
        return null;
    }
}
