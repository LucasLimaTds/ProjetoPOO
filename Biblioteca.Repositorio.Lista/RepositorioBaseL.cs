using System;
using Biblioteca.Repositorios.Interfaces;
using Bilbioteca.Base;

namespace Biblioteca.Repositorio.Lista;

public abstract class RepositorioBaseL<T> : IRepositorioBase<T>
    where T : class, IObjetoComId
{
    protected abstract int ObterId();
    protected List<T> Valores;

    public void Cadastrar(T NovoCadastro)
    {
        Valores.Add(NovoCadastro);
        NovoCadastro.ID = ObterId();
    }

    public IList<T> Listar()
    {
        return Valores;
    }

    public T Procura(int Id)
    {
        for (int i = 0; i < Valores.Count; i++)
        {
            if (Valores[i].ID == Id)
            {
                return Valores[i];
            }
        }
        return null;
    }

    public void Remover(int Id)
    {
        T Remocao = Procura(Id);
        Valores.Remove(Remocao);
    }
}
