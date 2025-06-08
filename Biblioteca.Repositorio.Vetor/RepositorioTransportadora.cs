using System;

namespace ProjetoLoja;

public class RepositorioTransportadora
{
    public Transportadora[] TodasTransportadoras = new Transportadora[1];
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

    public void ListarTransportadoras()
    {
        int i;
        Console.WriteLine("Transportadoras cadastradas:");
        for (i = 0; i < TodasTransportadoras.Length; i++)
        {
            Console.WriteLine($"Transportadora ID: {TodasTransportadoras[i].ID} | Nome: {TodasTransportadoras[i].Nome}");
        }

        Console.WriteLine("-------------------------------------------------------------------");
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

    public int ProcuraTransportadora(int id)
    {
        for (int i = 0; i < TodasTransportadoras.Length; i++)
        {
            if (TodasTransportadoras[i].ID == id)
            {
                return i;
            }
        }
        Console.WriteLine("Transportadora não encontrada!");
        Console.WriteLine("-------------------------------------------------------------------");
        return -1;
    }

    public void ConsultarTransportadora(int id)
    {
        int i;
        i = ProcuraTransportadora(id);
        if (i != -1)
        {
            Console.WriteLine($"Transportadora ID: {TodasTransportadoras[i].ID} | Nome: {TodasTransportadoras[i].Nome} | Preço do km: R$ {TodasTransportadoras[i].PrecoPorKM}");
            Console.WriteLine("-------------------------------------------------------------------");
        }

    }

    public bool VerificaExistenciaTransprtadora()
    {
        if (idTransportadora > 1)
        {
            return true;
        }
        return false;
    }
}
