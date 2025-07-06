using System;

namespace Biblioteca.Excecoes;

public class ExcecaoEstoqueZero : Exception
{
    public ExcecaoEstoqueZero(string msg) : base(msg)
    {
        
    }
}
