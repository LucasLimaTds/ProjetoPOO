using System;

namespace Biblioteca.Repositorios.Interfaces;

public interface IRepositorioBase<T> where T : class
{
    void Cadastrar(T NovoCadastro);
    IList<T> Listar();
    void Remover(int Id);
    T Procura(int Id);
    // String Consulta(int Id, T[] Vetor); //IMPLEMENTAR CASO PRECISE DEPOIS
}
