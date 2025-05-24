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

        if (GerenciadorDeUsuario.ValidarUsuario(Usuario, Senha) == 0)
        {
            MenuAdmin(); //mostra as opções para usuarios admin
        }
        if (GerenciadorDeUsuario.ValidarUsuario(Usuario, Senha) == 0)
        {
            MenuCliente(); //mostra opcoes para clientes 
        }
    }

    private void CriarUsuario()
    {
        Console.Write("Digite o nome do novo usuário: ");
        String NovoNome = Console.ReadLine();

        Console.Write("Digita a senha: ");
        String NovaSenha = Console.ReadLine();

        GerenciadorDeUsuario.CriarUsuario(NovoNome, NovaSenha);
        GerenciadorDeUsuario.ListarUsuarios();               //só uma função pra mostrar os nomes dos usuarios, para testar o cadastro
        MenuInicial();
    }

    private void MenuAdmin()
    {
        Console.WriteLine("[1] - LISTAR USUÁRIOS");
        Console.WriteLine("[0] - FAZER LOGOUT");

        int OpcaoUsuario;
        OpcaoUsuario = int.Parse(Console.ReadLine());

        switch (OpcaoUsuario)
        {
            case 1:
                {
                    GerenciadorDeUsuario.ListarUsuarios();
                    MenuAdmin(); //retorna para as opções depois de listar os usuarios
                    break;
                }
            case 0:
                {
                    MenuInicial();
                    break;
                }
        }
    }

    private void MenuCliente()
    {
        //aqui terá os menus das opções de clientes
    }
}
