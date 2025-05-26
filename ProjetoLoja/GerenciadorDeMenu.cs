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
        Console.Write("Email do usuário: ");
        string Email = Console.ReadLine();

        Console.Write("Senha: ");
        string Senha = Console.ReadLine();

        if (GerenciadorDeUsuario.ValidarUsuario(Email, Senha) == 0)
        {
            MenuAdmin(); //mostra as opções para usuarios admin
        }
        else if (GerenciadorDeUsuario.ValidarUsuario(Email, Senha) == 1)
        {
            MenuCliente(); //mostra opcoes para clientes 
        }
        else
        {
            Console.WriteLine("Email ou senha incorretos!");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }
    }

    private void CriarUsuario()
    {
        Console.Write("Digite o nome do novo usuário: ");
        string novoNome = Console.ReadLine();

        Console.Write("Digite o email do novo usuário: ");
        string novoEmail = Console.ReadLine();

        Console.Write("Digite o telefone do novo usuário: ");
        string novoTelefone = Console.ReadLine();

        string novaSenha;
        string confirmarSenha;

        do
        {
            Console.Write("Digita a senha: ");
            novaSenha = Console.ReadLine();

            Console.Write("Confirmar senha: ");
            confirmarSenha = Console.ReadLine();

            if (novaSenha != confirmarSenha)
            {
                Console.WriteLine("As senhas não coincidem");
                Console.WriteLine("Pressione qualquer tecla para tentar novamente");
                Console.ReadKey();
            }

        } while (novaSenha != confirmarSenha);


        string novaRua="";
        string novoNumero="";
        string novoComplemento="";
        string novoBairro="";
        string novoCEP="";
        string novaCidade="";
        string novoEstado="";

        CadastroEndereco(ref novaRua, ref novoNumero, ref novoComplemento, ref novoBairro, ref novoCEP, ref novaCidade, ref novoEstado);

        GerenciadorDeUsuario.CriarUsuario(novoNome, novoEmail, novoTelefone, novaSenha, novaRua, novoNumero, novoComplemento, novoBairro, novoCEP, novaCidade, novoEstado);
        GerenciadorDeUsuario.ListarUsuarios(); //só uma função pra mostrar os nomes dos usuarios, para testar o cadastro
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
    }

    private void CadastroEndereco(ref string novaRua, ref string novoNumero, ref string novoComplemento, ref string novoBairro, ref string novoCEP, ref string novaCidade, ref string novoEstado)
    {
        Console.WriteLine("Digite os dados do endereço:");

        Console.Write("Rua: ");
        novaRua=Console.ReadLine();

        Console.Write("Número: ");
        novoNumero=Console.ReadLine();

        Console.Write("Complemento: ");
        novoComplemento=Console.ReadLine();

        Console.Write("Bairro: ");
        novoBairro=Console.ReadLine();

        Console.Write("CEP: ");
        novoCEP=Console.ReadLine();

        Console.Write("Cidade: ");
        novaCidade=Console.ReadLine();

        Console.Write("Estado: ");
        novoEstado=Console.ReadLine();
    }

    private void MenuAdmin()
    {
        while (true)
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
                        return;
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
        while (true)
        {
            Console.Clear();
            Console.WriteLine("OPÇÕES DE CADASTRO DE FORNECEDORES:\n");

            OpcoesDoCadastro();

            int OpcaoFornecedor = int.Parse(Console.ReadLine());
            string nome;
            string email;
            string descricao;
            string novaRua="";
            string novoNumero="";
            string novoComplemento="";
            string novoBairro="";
            string novoCEP="";
            string novaCidade="";
            string novoEstado="";
            int idRemocao;

            switch (OpcaoFornecedor)
            {
                case 1:
                    {
                        Console.WriteLine("Insira o nome do novo fornecedor: ");
                        nome = Console.ReadLine();

                        Console.WriteLine("Insira o email do novo fornecedor: ");
                        email = Console.ReadLine();
                        
                        Console.WriteLine("Insira a descrição do novo fornecedor: ");
                        descricao = Console.ReadLine();

                        Console.WriteLine("Insira o telefone do novo fornecedor: ");
                        string telefoneFornecedor = Console.ReadLine();

                        CadastroEndereco(ref novaRua, ref novoNumero, ref novoComplemento, ref novoBairro, ref novoCEP, ref novaCidade, ref novoEstado);
                        GerenciadorDeFornecedor.CadastrarFornecedor(nome, email, descricao, telefoneFornecedor, novaRua, novoNumero, novoComplemento, novoBairro, novoCEP, novaCidade, novoEstado);
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
                        return;
                    }

            }
        }

    }

    private void MenuCadastroProduto()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("OPÇÕES DE CADASTRO DE PRODUTOS:\n");

            OpcoesDoCadastro();

            int OpcaoProduto=int.Parse(Console.ReadLine());
            string nome;
            int quantidade;
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
                        Console.WriteLine("Insira a quantidade do produto: ");
                        quantidade = int.Parse(Console.ReadLine());
                        GerenciadorDeProduto.CadastrarProduto(nome, valor, quantidade);
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
                        return;
                    }
            }
        }
        
    }
    
    private void MenuCadastroTransportadora()
    {
        while (true)
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
                        return;
                    }

            }
        }
        
    }

    private void MenuCliente()
    {
        //aqui terá os menus das opções de clientes
    }
}
