using System;
using System.Text.Json;
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
    public void SalvaClientes()
    {
        string SalvaJson = JsonSerializer.Serialize(Valores);
        File.WriteAllText("dados_clientes.json", SalvaJson);
        SalvaJson = JsonSerializer.Serialize(idCliente);
        File.WriteAllText("id_cliente.json", SalvaJson);
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
            if (CarregaJson != null)
            {
                Valores = JsonSerializer.Deserialize<List<Cliente>>(CarregaJson);
            }
        }

        if (!File.Exists("id_cliente.json"))
        {
            File.WriteAllText("id_cliente.json", null);
        }
        else
        {
            string CarregaJson = File.ReadAllText("id_cliente.json");
            if (CarregaJson != null)
            {
                idCliente = JsonSerializer.Deserialize<int>(CarregaJson);
            }
        }
    }
}
