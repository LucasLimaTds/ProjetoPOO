using System;

namespace Biblioteca.Excecoes;

public class ExcecaoEstoqueZero : Exception
{
    public ExcecaoEstoqueZero(String msg) : base(msg)
    {
        
    }
}
