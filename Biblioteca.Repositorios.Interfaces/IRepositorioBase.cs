using System;

namespace Biblioteca.Repositorios.Interfaces;

public interface IRepositorioBase<T> where T : class
{
    void Cadastrar(T NovoCadastro);
    IList<T> Listar();
    void Remover(int Id);
    T Procura(int Id);
}
