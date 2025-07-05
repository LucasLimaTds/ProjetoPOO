using System;

namespace Biblioteca.Excecoes;

public class ExcecaoLimiteEstoqueAlcancado : Exception
{
    public ExcecaoLimiteEstoqueAlcancado(String msg) : base(msg)
    {
        
    }
}
