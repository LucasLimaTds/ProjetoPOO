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
        while (true)
        {
            
            Console.Clear();
            Console.WriteLine("MENU INICIAL\n");

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
    }
    private void FazerLogin()
    {
        Console.Write("Usuário: ");
        string Usuario = Console.ReadLine();

        Console.Write("Senha: ");
        string Senha = Console.ReadLine();

        if (GerenciadorDeUsuario.ValidarUsuario(Usuario, Senha) == 0)
        {
            MenuAdmin(); //mostra as opções para usuarios admin
        }
        else if (GerenciadorDeUsuario.ValidarUsuario(Usuario, Senha) == 1)
        {
            MenuCliente(); //mostra opcoes para clientes 
        }
    }

    private void CriarUsuario()
    {
        Console.Write("Digite o nome do novo usuário: ");
        string NovoNome = Console.ReadLine();

        Console.Write("Digita a senha: ");
        string NovaSenha = Console.ReadLine();

        GerenciadorDeUsuario.CriarUsuario(NovoNome, NovaSenha);
        GerenciadorDeUsuario.ListarUsuarios(); //só uma função pra mostrar os nomes dos usuarios, para testar o cadastro
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
    }

    private void MenuAdmin()
    {
        bool flagAdmin=true;
        while (flagAdmin)
        {
            Console.Clear();
            Console.WriteLine("MENU DO ADMINISTRADOR\n");

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
                    {
                        MenuCadastroFornecedores();
                        break;
                }
                case 4:
                    {
                        MenuCadastroProduto();
                        break;
                }
                case 5:
                    {
                        MenuCadastroTransportadora();
                        break;
                }
                case 0:
                    {
                        flagAdmin = false;
                        break;
                }
            }
            
        }
    }

    private void OpcoesDoCadastro()
    {
        Console.WriteLine("[1] - REALIZAR INCLUSÃO");
        Console.WriteLine("[2] - REALIZAR ALTERAÇÃO");
        Console.WriteLine("[3] - REALIZAR EXCLUSÃO");
        Console.WriteLine("[4] - CONSULTAR CADASTRADOS");
        Console.WriteLine("[0] - VOLTAR AO MENU");
    }
    
    private void MenuCadastroFornecedores()
    {
        bool flagFornecedor = true;
        while (flagFornecedor)
        {
            Console.Clear();
            Console.WriteLine("OPÇÕES DE CADASTRO DE FORNECEDORES:\n");

            OpcoesDoCadastro();

            int OpcaoFornecedor = int.Parse(Console.ReadLine());
            string nome;
            int idRemocao;

            switch (OpcaoFornecedor)
            {
                case 1:
                    {
                        Console.WriteLine("Insira o nome do novo fornecedor: ");
                        nome = Console.ReadLine();
                        Console.WriteLine("Insira o telefone do novo fornecedor: ");
                        string telefoneFornecedor = Console.ReadLine();
                        GerenciadorDeFornecedor.CadastrarFornecedor(nome, telefoneFornecedor);
                        GerenciadorDeFornecedor.ListarFornecedores();

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
                        Console.WriteLine("Escolha o fornecedor que deseja remover: ");
                        GerenciadorDeFornecedor.ListarFornecedores();
                        Console.WriteLine("Insira o ID do fornecedor a ser removido: ");
                        idRemocao = int.Parse(Console.ReadLine());
                        GerenciadorDeFornecedor.RemoverFornecedor(idRemocao);
                        GerenciadorDeFornecedor.ListarFornecedores();

                        Console.WriteLine("Remoção realizada com sucesso!");
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadKey();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Digite o ID do fornecedor: ");
                        int idFornecedor = int.Parse(Console.ReadLine());
                        GerenciadorDeFornecedor.ConsultarFornecedor(idFornecedor);
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadKey();

                        break;
                    }
                case 0:
                    {
                        flagFornecedor = false;
                        break;
                    }

            }
        }

    }

    private void MenuCadastroProduto()
    {
        bool flagPrduto = true;
        while (flagPrduto)
        {
            Console.Clear();
            Console.WriteLine("OPÇÕES DE CADASTRO DE PRODUTOS:\n");

            OpcoesDoCadastro();

            int OpcaoProduto=int.Parse(Console.ReadLine());
            string nome;
            int idRemocao;
            double valor;

            switch (OpcaoProduto)
            {
                case 1:
                    {
                        Console.WriteLine("Insira o nome do novo produto: ");
                        nome = Console.ReadLine();
                        Console.WriteLine("Insira o valor do novo produto: ");
                        valor = double.Parse(Console.ReadLine());
                        GerenciadorDeProduto.CadastrarProduto(nome, valor);
                        GerenciadorDeProduto.ListarProdutos();

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
                        Console.WriteLine("Escolha o produto que deseja remover: ");
                        GerenciadorDeProduto.ListarProdutos();
                        Console.WriteLine("Insira o ID do produto a ser removido: ");
                        idRemocao = int.Parse(Console.ReadLine());
                        GerenciadorDeProduto.RemoverProduto(idRemocao);
                        GerenciadorDeProduto.ListarProdutos();

                        Console.WriteLine("Remoção realizada com sucesso!");
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadKey();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Digite o ID do produto: ");
                        int idProduto = int.Parse(Console.ReadLine());
                        GerenciadorDeProduto.ConsultarProduto(idProduto);
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadKey();
                        break;
                    }
                case 0:
                    {
                        flagPrduto = false;
                        break;
                    }
            }
        }
        
    }
    
    private void MenuCadastroTransportadora()
    {
        bool flagTransportadora = true;
        while (flagTransportadora)
        {
            
            Console.Clear();
            Console.WriteLine("OPÇÕES DE CADASTRO DE TRANSPORTADORAS:\n");

            OpcoesDoCadastro();

            int OpcaoTransportadora=int.Parse(Console.ReadLine());
            string nome;
            int idRemocao;
            double valor;

            switch (OpcaoTransportadora)
            {
                case 1:
                    {
                        Console.WriteLine("Insira o nome da nova transportadora: ");
                        nome = Console.ReadLine();
                        Console.WriteLine("Insira o preço cobrado por Km: ");
                        valor = double.Parse(Console.ReadLine());
                        GerenciadorDeTransportadora.CadastrarTransportadora(nome, valor);
                        GerenciadorDeTransportadora.ListarTransportadoras();

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
                        Console.WriteLine("Escolha a transportadora que deseja remover: ");
                        GerenciadorDeTransportadora.ListarTransportadoras();
                        Console.WriteLine("Insira o ID da transportadora a ser removida: ");
                        idRemocao = int.Parse(Console.ReadLine());
                        GerenciadorDeTransportadora.RemoverTransportadora(idRemocao);
                        GerenciadorDeTransportadora.ListarTransportadoras();

                        Console.WriteLine("Remoção realizada com sucesso!");
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadKey();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Digite o ID da transportadora: ");
                        int idTransportadora = int.Parse(Console.ReadLine());
                        GerenciadorDeTransportadora.ConsultarTrasnportadora(idTransportadora);
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadKey();
                        break;
                    }
                case 0:
                    {
                        flagTransportadora = false;
                        break;
                    }

            }
        }
        
    }

    private void MenuCliente()
    {
        //aqui terá os menus das opções de clientes
    }
}
