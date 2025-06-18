using System;

namespace Biblioteca.Repositorios.Interfaces;

public interface IRepositorioBase<T> where T : class
{
    void Cadastrar(T NovoCadastro, T[] Vetor);
    IList<T> Listar();
    void Remover(int Id, T[] Vetor);
    T Procura(int Id, T[] Vetor);
    // String Consulta(int Id, T[] Vetor); //IMPLEMENTAR CASO PRECISE DEPOIS
}
