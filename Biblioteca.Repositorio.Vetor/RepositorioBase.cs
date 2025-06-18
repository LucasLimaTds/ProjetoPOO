using System;
using Biblioteca.Repositorios.Interfaces;
using Bilbioteca.Base;

namespace Biblioteca.Repositorio.Vetor;

public abstract class RepositorioBase<T> : IRepositorioBase<T> 
    where T : class, IObjetoComId
{
    protected abstract int ObterId();
    protected abstract IList<T> ObterDados();

    private T[] Valores = new T[1];

    public void Cadastrar(T NovoCadastro, T[] Vetor)
    {
        if (Vetor[0] == null)
        {
            Vetor[0] = NovoCadastro;
            return;
        }
        T[] NovoVetor = new T[Vetor.Length + 1];

        for (int i = 0; i < Vetor.Length; i++)
        {
            NovoVetor[i] = Vetor[i];
        }

        NovoCadastro.ID = ObterId();
        NovoVetor[NovoVetor.Length - 1] = NovoCadastro;
        Vetor = NovoVetor;
    }

    public IList<T> Listar()
    {
        return ObterDados();
    }

    public void Remover(int Id, T[] Vetor)
    {
        T[] NovoVetor = new T[Vetor.Length - 1];
        int j = 0;
        for (int i = 0; j < Vetor.Length; i++, j++)
        {
            if (Vetor[j].ID == Id)
            {
                if ((j + 1) < Vetor.Length)
                {
                    NovoVetor[i] = Vetor[j + 1];
                    j++;
                }
                else break;
            }
            else
            {
                NovoVetor[i] = Vetor[j];
            }
        }
        Vetor = NovoVetor;
    }

    public T Procura(int Id, T[] Vetor)
    {
        for (int i = 0; i < Vetor.Length; i++)
        {
            if (Vetor[i].ID == Id)
            {
                return Vetor[i];
            }
        }
        return null;
    }

    // public String Consulta(int Id, T[] Vetor) //IMPLEMENTAR CASO PRECISE DEPOIS
    // {
    //     T ObjConsulta = Procura(Id, Vetor);
    //     return "";
    //     //vale a pena manter isso dentro da interface base, já que sempre vai ter que ser override nos repositorios?
    // }
}
