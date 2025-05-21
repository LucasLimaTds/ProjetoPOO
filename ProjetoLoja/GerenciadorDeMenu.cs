using System;
using System.Security.Principal;
using ProjetoLoja;

namespace ProjetoLoja;

public class GerenciadorDeMenus
{

    private RepositorioUsuario GerenciadorDeUsuario = new RepositorioUsuario();

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
                    CriarUsuario();
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

        if (GerenciadorDeUsuario.ValidarUsuario(Usuario, Senha)==0)
        {
            Console.WriteLine("FOI CAMBADA");
        }
    }

    private void CriarUsuario()
    {
        Console.Write("Digite o nome do novo usuário: ");
        String NovoNome = Console.ReadLine();

        Console.Write("Digita a senha: ");
        String NovaSenha = Console.ReadLine();


    }
}
