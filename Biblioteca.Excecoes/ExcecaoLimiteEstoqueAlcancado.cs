using System;

namespace Biblioteca.Excecoes;

public class ExcecaoLimiteEstoqueAlcancado : Exception
{
    public ExcecaoLimiteEstoqueAlcancado(string msg) : base(msg)
    {
        
    }
}
