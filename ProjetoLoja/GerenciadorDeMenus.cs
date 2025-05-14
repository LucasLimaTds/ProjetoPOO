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
        
        int OpcaoUsuario;
        OpcaoUsuario=int.Parse(Console.ReadLine());

        if(OpcaoUsuario==1)
        {
            // IMplementar metodo do login
        }
        else
        {
            // implementar metodo do cadastro
        }


    }

}
