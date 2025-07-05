using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;
using Biblioteca.Repositorio.Vetor;
using Biblioteca.Repositorios.Interfaces;

namespace ProjetoLoja;

public class RepositorioTransportadoraV : RepositorioBaseV<Transportadora>, IRepositorioTransportadora
{
    private int idTransportadora = 1;

    protected override int ObterId()
    {
        return idTransportadora++;
    }

    public string ConsultarTransportadora(int id)
    {
        Transportadora Transportadora = Procura(id);
        if (Transportadora != null)
        {
            return $"Transportadora ID: {Transportadora.ID} | Nome: {Transportadora.Nome} | Preço do km: R$ {Transportadora.PrecoPorKM}";
        }
        return "Transportadora não encontrada!";

    }

    public bool VerificaExistenciaTransportadora()
    {
        if (idTransportadora > 1)
        {
            return true;
        }
        return false;
    }

    public void AlteraNome(string novoNome, Transportadora TransportadoraEditar)
    {
        TransportadoraEditar.Nome = novoNome;
    }
    public void AlteraPrecoPorKm(double novoPreco, Transportadora TransportadoraEditar)
    {
        TransportadoraEditar.PrecoPorKM = novoPreco;
    }
    public void SalvaTransportadoras()
    {
        string SalvaJson = JsonSerializer.Serialize(Valores);
        File.WriteAllText("dados_transportadoras.json", SalvaJson);
        SalvaJson = JsonSerializer.Serialize(idTransportadora);
        File.WriteAllText("id_transportadora.json", SalvaJson);
    }
    public void CarregaTransportadoras()
    {
        if (!File.Exists("dados_transportadoras.json"))
        {
            File.WriteAllText("dados_transportadoras.json", null);
        }
        else
        {
            string CarregaJson = File.ReadAllText("dados_transportadoras.json");
            if (CarregaJson != null)
            {
                Valores = JsonSerializer.Deserialize<Transportadora[]>(CarregaJson);
            }
        }

        if (!File.Exists("id_transportadora.json"))
        {
            File.WriteAllText("id_transportadora.json", null);
        }
        else
        {
            string CarregaJson = File.ReadAllText("id_transportadora.json");
            if (CarregaJson != null)
            {
                idTransportadora = JsonSerializer.Deserialize<int>(CarregaJson);
            }
        }
    }
}
