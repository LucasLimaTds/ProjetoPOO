using System;
using System.Security.Principal;
using ProjetoLoja;

namespace ProjetoLoja;

public class GerenciadorDeMenus
{
    public GerenciadorDeMenus()
    {
        
        Console.WriteLine("[1] - FAZER LOGIN");
        Console.WriteLine("[2] - CADASTRAR USUÁRIO");
        Console.WriteLine("[0] - SAIR");
        
        int OpcaoUsuario;
        OpcaoUsuario=int.Parse(Console.ReadLine());

        switch(OpcaoUsuario)
        {
            case 1:
            {
                // Implementar metodo de login
                break;
            }
            case 2:
            {
                // Implementar metodo de cadastro
                break;
            }
            case 0:
            {
                Environment.Exit(0);
                break;
            }
        }
    }

}
