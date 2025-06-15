using System;
using Biblioteca.Repositorios.Interfaces;

namespace Biblioteca.Repositorio.Vetor;

public class RepositorioBase<T> : IRepositorioBase<T> where T : IRepositorioBase<T>
{
    int IRepositorioBase<T>.ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //muito ruim assim? Existe modo melhor de fazer? Tem que ter o ID pra poder fazer a pesquisa de remocao

    public void Cadastra(T NovoCadastro, T[] Vetor)
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
        //Trocar o lugar do id dos repositórios para as classes bases, para que o objeto já venha pronto
        Vetor = NovoVetor;
    }

    public T[] Lista(T[] Vetor) //Ajustar na GerenciadorDeMenus pra percorrer o vetor e escrever
    {
        return Vetor;
    }

    public void Remover(int IdRemocao, T[] Vetor)
    {
        T[] NovoVetor = new T[Vetor.Length - 1];
        int j = 0;
        for (int i = 0; j < Vetor.Length; i++, j++)
        {
            if (Vetor[j].ID == IdRemocao)
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
        return Vetor[0]; //Só pra não ficar dando erro
        //return null; //erro Tipo T pode não ser nullable
    }

    public String Consulta(int Id, T[] Vetor)
    {
        T ObjConsulta = Procura(Id, Vetor);
        return "";
        //vale a pena manter isso dentro da interface base, já que sempre vai ter que ser override?
    }
}
