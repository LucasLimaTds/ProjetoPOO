using System;

namespace ProjetoLoja;

public class RepositorioTransportadora
{
    private Transportadora[] TodasTransportadoras = new Transportadora[1];
    private int idTransportadora = 1;

    public void CadastrarTransportadora(Transportadora NovaTransportadora)
    {
        if (idTransportadora == 1)
        {
            NovaTransportadora.ID = idTransportadora++;
            TodasTransportadoras[0] = NovaTransportadora;
            return;
        }
        Transportadora[] novasTransportadoras = new Transportadora[TodasTransportadoras.Length + 1];

        for (int i = 0; i < TodasTransportadoras.Length; i++)
        {
            novasTransportadoras[i] = TodasTransportadoras[i];
        }

        NovaTransportadora.ID = idTransportadora++;
        novasTransportadoras[novasTransportadoras.Length - 1] = NovaTransportadora;
        TodasTransportadoras = novasTransportadoras;
    }

    public Transportadora[] ListarTransportadoras()
    {
        return TodasTransportadoras;
    }

    public void RemoverTransportadora(int idRemocao)
    {
        Transportadora[] novasTransportadoras = new Transportadora[TodasTransportadoras.Length - 1];
        int j = 0;
        for (int i = 0; j < TodasTransportadoras.Length; i++, j++)
        {
            if (TodasTransportadoras[j].ID == idRemocao)
            {
                if ((j + 1) < TodasTransportadoras.Length)
                {
                    novasTransportadoras[i] = TodasTransportadoras[j + 1];
                    j++;
                }
                else break;
            }
            else
            {
                novasTransportadoras[i] = TodasTransportadoras[j];
            }
        }
        TodasTransportadoras = novasTransportadoras;
    }

    public Transportadora ProcuraTransportadora(int id)
    {
        for (int i = 0; i < TodasTransportadoras.Length; i++)
        {
            if (TodasTransportadoras[i].ID == id)
            {
                return TodasTransportadoras[i];
            }
        }
        return null;
    }

    public String ConsultarTransportadora(int id)
    {
        Transportadora Transportadora = ProcuraTransportadora(id);
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
