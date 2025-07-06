using System;
using Biblioteca.Repositorios.Interfaces;
using Bilbioteca.Base;

namespace Biblioteca.Repositorio.Vetor;

public abstract class RepositorioBaseV<T> : IRepositorioBase<T> 
    where T : class, IObjetoComId
{
    protected abstract int ObterId();

    protected T[] Valores = new T[1];

    public void Cadastrar(T NovoCadastro)
    {
        if (Valores[0] == null)
        {
            Valores[0] = NovoCadastro;
            NovoCadastro.ID = ObterId();
            return;
        }
        T[] NovoVetor = new T[Valores.Length + 1];

        for (int i = 0; i < Valores.Length; i++)
        {
            NovoVetor[i] = Valores[i];
        }

        NovoCadastro.ID = ObterId();
        NovoVetor[NovoVetor.Length - 1] = NovoCadastro;
        Valores = NovoVetor;
    }

    public IList<T> Listar()
    {
        return Valores;
    }

    public void Remover(int Id)
    {
        T[] NovoVetor = new T[Valores.Length - 1];
        int j = 0;
        for (int i = 0; j < Valores.Length; i++, j++)
        {
            if (Valores[j].ID == Id)
            {
                if ((j + 1) < Valores.Length)
                {
                    NovoVetor[i] = Valores[j + 1];
                    j++;
                }
                else break;
            }
            else
            {
                NovoVetor[i] = Valores[j];
            }
        }
        Valores = NovoVetor;
    }

    public T Procura(int Id)
    {
        for (int i = 0; i < Valores.Length; i++)
        {
            if (Valores[i].ID == Id)
            {
                return Valores[i];
            }
        }
        return null;
    }
}
