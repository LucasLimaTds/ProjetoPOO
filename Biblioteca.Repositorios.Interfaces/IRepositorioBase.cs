using System;

namespace Biblioteca.Repositorios.Interfaces;

public interface IRepositorioBase<T>
{
    int ID { get; set; }
    void Cadastra(T NovoCadastro, T[] Vetor);
    T[] Lista(T[] Vetor);
    void Remover(int IdRemocao, T[] Vetor);
    T Procura(int Id, T[] Vetor);
    String Consulta(int Id, T[] Vetor);
}
