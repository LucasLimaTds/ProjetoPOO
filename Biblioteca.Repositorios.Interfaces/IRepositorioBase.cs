using System;

namespace Biblioteca.Repositorios.Interfaces;

public interface IRepositorioBase<T>
{
    int ID { get; set; }
    void Cadastra(T NovoCadastro, T[] Vetor);
    IList<T> Listar(T[] Vetor);
    void Remover(int Id, T[] Vetor);
    T Procura(int Id, T[] Vetor);
    String Consulta(int Id, T[] Vetor);
}
