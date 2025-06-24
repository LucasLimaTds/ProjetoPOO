using System;
using System.ComponentModel;
using System.Globalization;
using Biblioteca.Repositorio.Vetor;
using Biblioteca.Repositorios.Interfaces;
using Bilbioteca.Base;

namespace ProjetoLoja;

public class RepositorioClienteV : RepositorioBaseV<Cliente>, IRepositorioCliente
{
    private int idCliente = 1;
    protected override int ObterId()
    {
        return idCliente++;
    }

    public Cliente ProcuraCliente(Usuario usuario)
    {
        for (int i = 0; i < Valores.Length; i++)
        {
            if (Valores[i].UsuarioDoCliente == usuario)
            {
                return Valores[i];
            }
        }
        return null;
    }
}
