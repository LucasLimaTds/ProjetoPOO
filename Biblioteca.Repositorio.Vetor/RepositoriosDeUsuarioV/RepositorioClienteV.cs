using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;
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
            if (Valores[i].UsuarioDoCliente.ID == usuario.ID)
            {
                return Valores[i];
            }
        }
        return null;
    }
    public void SalvaClientes()
    {
        if (Valores[0] != null)
        {
            string SalvaJson = JsonSerializer.Serialize(Valores);
            File.WriteAllText("dados_clientes.json", SalvaJson);
            SalvaJson = JsonSerializer.Serialize(idCliente);
            File.WriteAllText("id_cliente.json", SalvaJson);
        }
    }
    public void CarregaClientes()
    {
        if (!File.Exists("dados_clientes.json"))
        {
            File.WriteAllText("dados_clientes.json", null);
        }
        else
        {
            string CarregaJson = File.ReadAllText("dados_clientes.json");
            Valores = JsonSerializer.Deserialize<Cliente[]>(CarregaJson);
        }

        if (!File.Exists("id_cliente.json"))
        {
            File.WriteAllText("id_cliente.json", null);
        }
        else
        {
            string CarregaJson = File.ReadAllText("id_cliente.json");
            idCliente = JsonSerializer.Deserialize<int>(CarregaJson);
        }
    }
    public bool VerificaExistenciaClientes()
    {
        if (idCliente > 1)
        {
            return true;
        }
        return false;
    }
}
