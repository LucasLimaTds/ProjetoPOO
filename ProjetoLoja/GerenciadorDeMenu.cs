using System;
using System.Security.Principal;
using ProjetoLoja;

namespace ProjetoLoja;

public class GerenciadorDeMenus
{

    private RepositorioUsuario GerenciadorDeUsuario = new RepositorioUsuario();
    private RepositorioFornecedor GerenciadorDeFornecedor = new RepositorioFornecedor();
    private RepositorioProduto GerenciadorDeProduto = new RepositorioProduto();
    private RepositorioTransportadora GerenciadorDeTransportadora = new RepositorioTransportadora();

    public GerenciadorDeMenus()
    {
        MenuInicial();
    }

    private void MenuInicial()
    {
        Console.Clear();
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
        bool flag=true;
        while (flag)
        {
            Console.Clear();
            Console.WriteLine("[1] - LISTAR USUÁRIOS");
            Console.WriteLine("[2] - EDITAR USUÁRIOS");
            Console.WriteLine("[3] - CADASTRO DE FORNECEDORES");
            Console.WriteLine("[4] - CADASTRO DE PRODUTOS");
            Console.WriteLine("[5] - CADASTRO DE TRANSPORTADORAS");
            Console.WriteLine("[0] - FAZER LOGOUT");

            int OpcaoUsuario;
            OpcaoUsuario = int.Parse(Console.ReadLine());

            switch (OpcaoUsuario)
            {
                case 1:
                    {
                        GerenciadorDeUsuario.ListarUsuarios();
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadKey();
                        /* o retorno das opcoes sera dado pelo loop, sem necessidade 
                        de realizar chamadas de funcoes nao necessarias*/
                        break;
                    }
                case 2:
                    {
                        //chama metodo de editar usuario
                        break;
                    }
                case 3:
                case 4:
                case 5:
                    {
                        MenuDeCadastros(OpcaoUsuario);
                        break;
                    }
                case 0:
                    {
                        flag = false;
                        break;
                    }
            }
            
        }
        MenuInicial();
    }

    private void MenuDeCadastros(int OpcaoUsuario) //deve existir um jeito um pouco melhor de fazer, mas como os tres tipos de cadastros tem as mesmas opções, achei de tentar
    //abstrair em um metodo só ao invés de tres metodos diferentes mas parecidos
    {
        if (OpcaoUsuario == 3)
            Console.WriteLine("OPÇÕES DE CADASTRO DE FORNECEDORES:");

        if (OpcaoUsuario == 4)
            Console.WriteLine("OPÇÕES DE CADASTRO DE PRODUTOS:");

        if (OpcaoUsuario == 5)
            Console.WriteLine("OPÇÕES DE CADASTRO DE TRANSPORTADORAS:");


        Console.WriteLine("[1] - REALIZAR INCLUSÃO");
        Console.WriteLine("[2] - REALIZAR ALTERAÇÃO");
        Console.WriteLine("[3] - REALIZAR EXCLUSÃO");
        Console.WriteLine("[4] - CONSULTA CADASTRADOS");

        int OpcaoCadastro;
        OpcaoCadastro = int.Parse(Console.ReadLine());
        String nome;
        double valor;
        int idRemocao;

        switch (OpcaoCadastro)
        {
            case 1:
                {
                    if (OpcaoUsuario == 3)
                    {
                        Console.WriteLine("Insira o nome do novo fornecedor: ");
                        nome = Console.ReadLine();
                        Console.WriteLine("Insira o telefone do novo fornecedor: ");
                        String telefoneFornecedor = Console.ReadLine();
                        GerenciadorDeFornecedor.CadastrarFornecedor(nome, telefoneFornecedor);
                        GerenciadorDeFornecedor.ListarFornecedores();
                    }

                    else if (OpcaoUsuario == 4)
                    {
                        Console.WriteLine("Insira o nome do novo produto: ");
                        nome = Console.ReadLine();
                        Console.WriteLine("Insira o valor do novo produto: ");
                        valor = int.Parse((Console.ReadLine()));
                        GerenciadorDeProduto.CadastrarProduto(nome, valor);
                        GerenciadorDeProduto.ListarProdutos();
                    }

                    else
                    {
                        Console.WriteLine("Insira o nome da nova transportadora: ");
                        nome = Console.ReadLine();
                        Console.WriteLine("Insira o preço cobrado por Km: ");
                        valor = int.Parse((Console.ReadLine()));
                        GerenciadorDeTransportadora.CadastrarTransportadora(nome, valor);
                        GerenciadorDeTransportadora.ListarTransportadoras();
                    }
                    Console.WriteLine("Inclusão realizada com sucesso!");
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    break;
                }
            case 2:
                {
                    break;
                }
            case 3:
                {
                    if (OpcaoUsuario == 3)
                    {
                        Console.WriteLine("Escolha o fornecedor que deseja remover: ");
                        GerenciadorDeFornecedor.ListarFornecedores();
                        Console.WriteLine("Insira o ID do fornecedor a ser removido: ");
                        idRemocao = int.Parse (Console.ReadLine());
                        GerenciadorDeFornecedor.RemoverFornecedor(idRemocao);
                        GerenciadorDeFornecedor.ListarFornecedores();
                    }

                    else if (OpcaoUsuario == 4)
                    {
                        Console.WriteLine("Escolha o produto que deseja remover: ");
                        GerenciadorDeProduto.ListarProdutos();
                        Console.WriteLine("Insira o ID do produto a ser removido: ");
                        idRemocao = int.Parse (Console.ReadLine());
                        GerenciadorDeProduto.RemoverProduto(idRemocao);
                        GerenciadorDeProduto.ListarProdutos();
                    }

                    else
                    {
                        Console.WriteLine("Escolha a transportadora que deseja remover: ");
                        GerenciadorDeTransportadora.ListarTransportadoras();
                        Console.WriteLine("Insira o ID do fornecedor a ser removido: ");
                        idRemocao = int.Parse (Console.ReadLine());
                        GerenciadorDeTransportadora.RemoverTransportadora(idRemocao);
                        GerenciadorDeTransportadora.ListarTransportadoras();
                    }
                    Console.WriteLine("Remoção realizada com sucesso!");
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    break;
                }
            case 4:
                {
                    break;
                }
        }
    }

    private void MenuCliente()
    {
        //aqui terá os menus das opções de clientes
    }
}
