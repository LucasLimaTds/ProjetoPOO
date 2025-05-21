using System;
using System.Security.Principal;
using ProjetoLoja;

namespace ProjetoLoja;

public class GerenciadorDeMenus
{
    public GerenciadorDeMenus()
    {
        MenuInicial();
    }


    private void MenuInicial()
    {

        Console.WriteLine("[1] - FAZER LOGIN");
        Console.WriteLine("[2] - CRIAR USUÁRIO");
        Console.WriteLine("[0] - FINALIZAR O PROGRAMA");

        int OpcaoUsuario;
        OpcaoUsuario = int.Parse(Console.ReadLine());

        switch (OpcaoUsuario)
        {
            case 1:
                {
                    FazerLogin();
                    break;
                }
            case 2:
                {
                    // Implementar metodo de criar
                    break;
                }
            case 0:
                {
                    Environment.Exit(0);
                    break;
                }
        }
    }
    private void FazerLogin()
    {
        Console.Write("Usuário: ");
        String Usuario = Console.ReadLine();

        Console.Write("Senha: ");
        String Senha = Console.ReadLine();
    }
}
