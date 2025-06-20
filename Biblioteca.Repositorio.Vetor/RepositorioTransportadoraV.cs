using System;
using System.ComponentModel;
using System.Globalization;
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

    public String ConsultarTransportadora(int id)
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
}
