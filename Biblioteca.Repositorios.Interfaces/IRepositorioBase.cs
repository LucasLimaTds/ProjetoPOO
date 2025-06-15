using System;

namespace Biblioteca.Repositorios.Interfaces;

public interface IRepositorioBase<T>
{
    void Cadastra();
    void Lista();
    void Remove();

    //<T> Procura(); Não dá pra retornar um tipo generico aqui?
    void Consulta();
}
