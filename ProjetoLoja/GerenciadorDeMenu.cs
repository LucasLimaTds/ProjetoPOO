using System;
using System.ComponentModel;
using System.Security.Principal;
using ProjetoLoja;
using Biblioteca.Repositorio.Vetor;
using Biblioteca.Repositorios.Interfaces;
using Bilbioteca.Base;
using Biblioteca.Base.EstruturaDaLoja;


namespace ProjetoLoja;

public class GerenciadorDeMenus //<T> where T : class
{

    private IRepositorioUsuario GerenciadorDeUsuario;
    private IRepositorioFornecedor GerenciadorDeFornecedor;
    private IRepositorioProduto GerenciadorDeProduto;
    private IRepositorioTransportadora GerenciadorDeTransportadora;
    private IRepositorioCliente GerenciadorDeCliente;

    public GerenciadorDeMenus(IRepositorioUsuario GU, IRepositorioFornecedor GF, IRepositorioProduto GP, IRepositorioTransportadora GT, IRepositorioCliente GC)
    {
        GerenciadorDeUsuario = GU;
        GerenciadorDeFornecedor = GF;
        GerenciadorDeProduto = GP;
        GerenciadorDeTransportadora = GT;
        GerenciadorDeCliente = GC;
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
                        CriarCliente();
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
            PressioneQualquerTecla();
        }
    }
    private void CriarCliente()
    {
        GerenciadorDeUsuario.Cadastrar(ValidarNovoUsuario(1));
        Console.Write("Digite o nome do novo cliente: ");
        string novoNome = Console.ReadLine();
        Console.Write("Digite o telefone do novo cliente: ");
        string novoTelefone = Console.ReadLine();
        GerenciadorDeCliente.Cadastrar(new Cliente(novoTelefone, novoNome, CadastroEndereco(), GerenciadorDeUsuario.RetornaUltimo()));
        PressioneQualquerTecla();
    }

    private Usuario ValidarNovoUsuario(int direito)
    {
        string novoEmail;
        bool testeEmail;
        do
        {
            Console.Write("Digite o email do novo usuário: ");
            novoEmail = Console.ReadLine();

            testeEmail = GerenciadorDeUsuario.VerificaEmailExistente(novoEmail);
            if (!testeEmail)
            {
                Console.WriteLine("Endereço de email já existente!");
                PressioneQualquerTecla();
            }

        } while (!testeEmail);

        string novaSenha;
        string confirmarSenha;
        bool testeSenha;
        do
        {
            Console.Write("Digita a senha: ");
            novaSenha = Console.ReadLine();

            Console.Write("Confirmar senha: ");
            confirmarSenha = Console.ReadLine();

            if (novaSenha != confirmarSenha)
            {
                testeSenha = false;
                Console.WriteLine("As senhas não coincidem");
                Console.WriteLine("Pressione qualquer tecla para tentar novamente");
                Console.ReadKey();
            }
            else
            {
                testeSenha = true;
            }

        } while (!testeSenha);
        return new Usuario(novoEmail, novaSenha, direito);
    }

    private Endereco CadastroEndereco()
    {
        Endereco endereco = new Endereco();
        Console.WriteLine("Digite os dados do endereço:");

        Console.Write("Rua: ");
        endereco.Rua = Console.ReadLine();

        Console.Write("Número: ");
        endereco.Numero = Console.ReadLine();

        Console.Write("Complemento: ");
        endereco.Complemento = Console.ReadLine();

        Console.Write("Bairro: ");
        endereco.Bairro = Console.ReadLine();

        Console.Write("CEP: ");
        endereco.CEP = Console.ReadLine();

        Console.Write("Cidade: ");
        endereco.Cidade = Console.ReadLine();

        Console.Write("Estado: ");
        endereco.Estado = Console.ReadLine();

        return endereco;
    }

    private void MenuAdmin()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("MENU DO ADMINISTRADOR\n");

            Console.WriteLine("[1] - CADASTRO DE USUÁRIOS");
            Console.WriteLine("[2] - CADASTRO DE FORNECEDORES");
            Console.WriteLine("[3] - CADASTRO DE PRODUTOS");
            Console.WriteLine("[4] - CADASTRO DE TRANSPORTADORAS");
            Console.WriteLine("[0] - FAZER LOGOUT");

            int OpcaoUsuario;
            OpcaoUsuario = int.Parse(Console.ReadLine());

            switch (OpcaoUsuario)
            {
                case 1:
                    {
                        MenuCadastroUsuarios();
                        break;
                    }
                case 2:
                    {
                        MenuCadastroFornecedores();
                        break;
                    }
                case 3:
                    {
                        MenuCadastroProduto();
                        break;
                    }
                case 4:
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

    private void ExibirListaUsuarios()
    {
        IList<Usuario> TodosUsuarios = GerenciadorDeUsuario.Listar();
        Console.WriteLine("\nUsuários cadastrados:");

        foreach (var item in TodosUsuarios)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("-------------------------------------------------------------------");
    }

    private void OpcoesDoCadastro()
    {
        Console.WriteLine("[1] - REALIZAR INCLUSÃO");
        Console.WriteLine("[2] - REALIZAR ALTERAÇÃO");
        Console.WriteLine("[3] - REALIZAR EXCLUSÃO");
        Console.WriteLine("[4] - CONSULTAR CADASTRADOS");
        Console.WriteLine("[0] - VOLTAR AO MENU");
    }

    private void OpcoesDoCadastroDeUsuarios()
    {
        Console.WriteLine("[1] - REALIZAR INCLUSÃO DE ADMIN");
        Console.WriteLine("[2] - REALIZAR ALTERAÇÃO");
        Console.WriteLine("[3] - CONSULTAR CADASTRADOS");
        Console.WriteLine("[0] - VOLTAR AO MENU");
    }

    private void MenuCadastroUsuarios()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("OPÇÕES DE CADASTRO DE USUÁRIOS:\n");

            OpcoesDoCadastroDeUsuarios();

            int OpcaoUsuario = int.Parse(Console.ReadLine());

            switch (OpcaoUsuario)
            {
                case 1:
                    {
                        GerenciadorDeUsuario.Cadastrar(ValidarNovoUsuario(0));
                        Console.WriteLine("Usuário cadastrado com sucesso!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Escolha o usuário que deseja editar:");
                        ExibirListaUsuarios();
                        int id = int.Parse(Console.ReadLine());
                        Usuario UsuarioEditar = GerenciadorDeUsuario.Procura(id);
                        if (UsuarioEditar != null)
                        {
                            AlterarUsuario(UsuarioEditar);
                        }
                        else
                        {
                            Console.WriteLine("Usuario não encontrado!");
                            Console.WriteLine("-------------------------------------------------------------------");
                            PressioneQualquerTecla();
                        }

                        break;
                    }
                case 3:
                    {
                        ExibirListaUsuarios();
                        PressioneQualquerTecla();
                        break;
                    }
                case 0:
                    {
                        return;
                    }

            }
        }
    }

    private void AlterarUsuario(Usuario UsuarioEditar)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("OPÇÕES DE ALTERAÇÃO DE USUÁRIO:\n");

            Console.WriteLine("[1] - ALTERAR EMAIL");
            Console.WriteLine("[2] - ALTERAR SENHA");
            Console.WriteLine("[0] - VOLTAR AO MENU");
            int opcaoAlteracao = int.Parse(Console.ReadLine());
            string novoEmail;
            string novaSenha;

            switch (opcaoAlteracao)
            {
                case 1:
                    {
                        Console.WriteLine("Insira o novo email:");
                        novoEmail = Console.ReadLine();
                        GerenciadorDeUsuario.AlterarEmail(novoEmail, UsuarioEditar);
                        Console.WriteLine("Email alterado!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Insira a nova senha:");
                        novaSenha = Console.ReadLine();
                        GerenciadorDeUsuario.AlterarEmail(novaSenha, UsuarioEditar);
                        Console.WriteLine("Senha alterada!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 0:
                    {
                        return;
                    }
            }
        }
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
            string[] endereco;
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

                        GerenciadorDeFornecedor.Cadastrar(new Fornecedor(nome, email, descricao, telefoneFornecedor, CadastroEndereco()));
                        ExibirListaFornecedores();

                        Console.WriteLine("Inclusão realizada com sucesso!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 2:
                    {
                        if (GerenciadorDeFornecedor.VerificaExistenciaFornecedor())
                        {
                            Console.WriteLine("Escolha o fornecedor que deseja editar:");
                            ExibirListaFornecedores();
                            int id = int.Parse(Console.ReadLine());
                            if (id == 0)
                            {
                                Console.WriteLine("Fornecedor padrão do sistema! Impossível alterar");
                            }
                            else
                            {
                                Fornecedor FornecedorEditar = GerenciadorDeFornecedor.Procura(id);
                                if (FornecedorEditar != null)
                                {
                                    AlterarFornecedor(FornecedorEditar);
                                }
                                else
                                {
                                    Console.WriteLine("Fornecedor não encontrado!");
                                    Console.WriteLine("-------------------------------------------------------------------");
                                    PressioneQualquerTecla();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Não há fornecedores cadastrados!");
                            PressioneQualquerTecla();
                        }
                        break;
                    }
                case 3:
                    {
                        if (GerenciadorDeFornecedor.VerificaExistenciaFornecedor())
                        {
                            Console.WriteLine("Escolha o fornecedor que deseja remover: ");
                            ExibirListaFornecedores();
                            Console.WriteLine("Insira o ID do fornecedor a ser removido: ");
                            idRemocao = int.Parse(Console.ReadLine());
                            if (idRemocao == 0)
                            {
                                Console.WriteLine("Fornecedor padrão do sistema! Impossível remover");
                            }
                            else
                            {
                                GerenciadorDeProduto.RemocaoDeFornecedor(idRemocao, GerenciadorDeFornecedor.Procura(0));
                                Fornecedor FornecedorRemocao = GerenciadorDeFornecedor.Procura(idRemocao);
                                if (FornecedorRemocao != null)
                                {
                                    GerenciadorDeFornecedor.Remover(idRemocao);
                                    ExibirListaFornecedores();
                                    Console.WriteLine("Remoção realizada com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Fornecedor não encontrado!");
                                    Console.WriteLine("-------------------------------------------------------------------");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Não há fornecedores cadastrados!");
                        }
                        PressioneQualquerTecla();
                        break;
                    }
                case 4:
                    {
                        if (GerenciadorDeFornecedor.VerificaExistenciaFornecedor())
                        {
                            Console.WriteLine("Escolha o fornecedor a ser consultado:");
                            ExibirListaFornecedores();
                            Console.WriteLine("Digite o ID do fornecedor: ");
                            int idFornecedor = int.Parse(Console.ReadLine());
                            Console.WriteLine(GerenciadorDeFornecedor.ConsultarFornecedor(idFornecedor));
                            Console.WriteLine("-------------------------------------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Não há fornecedores cadastrados!");
                        }
                        PressioneQualquerTecla();

                        break;
                    }
                case 0:
                    {
                        return;
                    }

            }
        }

    }

    private void ExibirListaFornecedores()
    {
        IList<Fornecedor> TodosFornecedores = GerenciadorDeFornecedor.Listar();
        int i;
        Console.WriteLine("\nFornecedores cadastrados:");

        foreach (var item in TodosFornecedores)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("-------------------------------------------------------------------");
    }

    //PENSAR EM IMPLEMENTAR DESSA FORMA A LISTAGEM DE CADASTRADOS:
    // private void ExibirCadastrados(IList<T> valores) //recebe direto o vetor/lista genérico
    // {
    //     Console.WriteLine("\nCadastrados:");
    //     foreach (var item in valores)
    //     {
    //        Console.WriteLine(item.ToString());
    //     }
    //     Console.WriteLine("-------------------------------------------------------------------");
    // }

    private void AlterarFornecedor(Fornecedor FornecedorEditar)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("OPÇÕES DE ALTERAÇÃO DE FORNECEDOR:\n");

            Console.WriteLine("[1] - ALTERAR NOME");
            Console.WriteLine("[2] - ALTERAR DESCRIÇÃO");
            Console.WriteLine("[3] - ALTERAR TELEFONE");
            Console.WriteLine("[4] - ALTERAR EMAIL");
            Console.WriteLine("[5] - ALTERAR ENDEREÇO");
            Console.WriteLine("[0] - VOLTAR AO MENU");

            int opcaoAlteracao = int.Parse(Console.ReadLine());
            string novoNome;
            string novaDescricao;
            string novoTelefone;
            string novoEmail;

            string[] endereco;

            switch (opcaoAlteracao)
            {
                case 1:
                    {
                        Console.WriteLine("Insira o novo nome:");
                        novoNome = Console.ReadLine();
                        GerenciadorDeFornecedor.AlterarNome(novoNome, FornecedorEditar);
                        Console.WriteLine("Nome alterado!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Insira a nova descrição:");
                        novaDescricao = Console.ReadLine();
                        GerenciadorDeFornecedor.AlterarDescricao(novaDescricao, FornecedorEditar);
                        Console.WriteLine("Descrição alterada!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Insira o novo telefone:");
                        novoTelefone = Console.ReadLine();
                        GerenciadorDeFornecedor.AlterarTelefone(novoTelefone, FornecedorEditar);
                        Console.WriteLine("Telefone alterado!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Insira o novo email:");
                        novoEmail = Console.ReadLine();
                        GerenciadorDeFornecedor.AlterarEmail(novoEmail, FornecedorEditar);
                        Console.WriteLine("Email alterado!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 5:
                    {
                        GerenciadorDeFornecedor.AlterarEndereco(CadastroEndereco(), FornecedorEditar);

                        Console.WriteLine("Endereço alterado!");
                        PressioneQualquerTecla();
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

            int OpcaoProduto = int.Parse(Console.ReadLine());
            string nome;
            int quantidade;
            int idRemocao;
            double valor;
            int idfornecedor;

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

                        Console.WriteLine("Escolha o fornecedor para o produto:");
                        ExibirListaFornecedores();
                        idfornecedor = int.Parse(Console.ReadLine());

                        Fornecedor FornecedorDoProduto = GerenciadorDeFornecedor.Procura(idfornecedor);
                        if (FornecedorDoProduto != null)
                        {
                            GerenciadorDeProduto.Cadastrar(new Produto(nome, valor, quantidade, FornecedorDoProduto));
                            ExibirListaProdutos();
                            Console.WriteLine("Inclusão realizada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Fornecedor não encontrado!");
                            Console.WriteLine("-------------------------------------------------------------------");
                        }

                        PressioneQualquerTecla();
                        break;
                    }
                case 2:
                    {
                        if (GerenciadorDeProduto.VerificaExistenciaProduto())
                        {
                            Console.WriteLine("Escolha o produto que deseja editar:");
                            ExibirListaProdutos();
                            int id = int.Parse(Console.ReadLine());
                            Produto ProdutoEditar = GerenciadorDeProduto.Procura(id);
                            if (ProdutoEditar != null)
                            {
                                AlterarProduto(ProdutoEditar);
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado!");
                                Console.WriteLine("-------------------------------------------------------------------");
                                PressioneQualquerTecla();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Não há produtos cadastrados!");
                            PressioneQualquerTecla();
                        }
                        break;
                    }
                case 3:
                    {
                        if (GerenciadorDeProduto.VerificaExistenciaProduto())
                        {
                            Console.WriteLine("Escolha o produto que deseja remover: ");
                            ExibirListaProdutos();
                            Console.WriteLine("Insira o ID do produto a ser removido: ");
                            idRemocao = int.Parse(Console.ReadLine());
                            Produto ProdutoRemover = GerenciadorDeProduto.Procura(idRemocao);
                            if (ProdutoRemover != null)
                            {
                                GerenciadorDeProduto.Remover(idRemocao);
                                ExibirListaProdutos();
                                Console.WriteLine("Remoção realizada com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado!");
                                Console.WriteLine("-------------------------------------------------------------------");

                            }
                        }
                        else
                        {
                            Console.WriteLine("Não há produtos cadastrados!");
                        }
                        PressioneQualquerTecla();
                        break;
                    }
                case 4:
                    {
                        if (GerenciadorDeProduto.VerificaExistenciaProduto())
                        {
                            Console.WriteLine("Escolha o produto a ser consultado:");
                            ExibirListaProdutos();
                            Console.WriteLine("Digite o ID do produto: ");
                            int idProduto = int.Parse(Console.ReadLine());
                            Console.WriteLine(GerenciadorDeProduto.ConsultarProduto(idProduto));
                            Console.WriteLine("-------------------------------------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Não há produtos cadastrados!");
                        }
                        PressioneQualquerTecla();
                        break;
                    }
                case 0:
                    {
                        return;
                    }
            }
        }

    }

    private void ExibirListaProdutos()
    {
        IList<Produto> TodosProdutos = GerenciadorDeProduto.Listar();
        int i;
        Console.WriteLine("Produtos cadastrados:");
        foreach (var item in TodosProdutos)
        {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine("-------------------------------------------------------------------");
    }

    private void AlterarProduto(Produto ProdutoAlterado)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("OPÇÕES DE ALTERAÇÃO DE PRODUTO:\n");

            Console.WriteLine("[1] - ALTERAR NOME");
            Console.WriteLine("[2] - ALTERAR VALOR");
            Console.WriteLine("[3] - ALTERAR QUANTIDADE EM ESTOQUE");
            Console.WriteLine("[4] - ALTERAR FORNECEDOR");
            Console.WriteLine("[0] - VOLTAR AO MENU");

            int opcaoAlteracao = int.Parse(Console.ReadLine());
            string novoNome;
            double novoValor;
            int novaQnt, novoId;
            switch (opcaoAlteracao)
            {
                case 1:
                    {
                        Console.WriteLine("Insira o novo nome:");
                        novoNome = Console.ReadLine();
                        GerenciadorDeProduto.AlteraNome(novoNome, ProdutoAlterado);
                        Console.WriteLine("Nome alterado!");
                        PressioneQualquerTecla();
                        Console.Clear();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Insira o novo valor:");
                        novoValor = double.Parse(Console.ReadLine());
                        GerenciadorDeProduto.AlterarValor(novoValor, ProdutoAlterado);
                        Console.WriteLine("Valor alterado!");
                        PressioneQualquerTecla();
                        Console.Clear();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Insira a nova quantidade em estoque:");
                        novaQnt = int.Parse(Console.ReadLine());
                        GerenciadorDeProduto.AlterarEstoque(novaQnt, ProdutoAlterado);
                        Console.WriteLine("Quantidade alterada!");
                        PressioneQualquerTecla();
                        Console.Clear();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Escolha o novo fornecedor:");
                        ExibirListaFornecedores();
                        Console.WriteLine("Insira o ID do novo fornecedor:");
                        novoId = int.Parse(Console.ReadLine());
                        Fornecedor FornecedorAlterado = GerenciadorDeFornecedor.Procura(novoId);
                        if (FornecedorAlterado != null)
                        {
                            GerenciadorDeProduto.AlterarFornecedor(FornecedorAlterado, ProdutoAlterado);
                            Console.WriteLine("Fornecedor alterado!");
                        }
                        else
                        {
                            Console.WriteLine("Fornecedor não encontrado!");
                            Console.WriteLine("-------------------------------------------------------------------");
                        }
                        PressioneQualquerTecla();
                        Console.Clear();
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

            int OpcaoTransportadora = int.Parse(Console.ReadLine());
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
                        GerenciadorDeTransportadora.Cadastrar(new Transportadora(nome, valor));
                        ExibirListaTransportadoras();

                        Console.WriteLine("Inclusão realizada com sucesso!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 2:
                    {
                        if (GerenciadorDeTransportadora.VerificaExistenciaTransportadora())
                        {
                            Console.WriteLine("Escolha a transportadora que deseja editar");
                            ExibirListaTransportadoras();
                            int id = int.Parse(Console.ReadLine());
                            Transportadora TransportadoraEditada = GerenciadorDeTransportadora.Procura(id);

                            if (TransportadoraEditada != null)
                            {
                                AlteraTransportadora(TransportadoraEditada);
                            }
                            else
                            {
                                Console.WriteLine("Transportadora não encontrada!");
                                Console.WriteLine("-------------------------------------------------------------------");
                                PressioneQualquerTecla();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Não há transportadoras cadastradas!");
                            PressioneQualquerTecla();
                        }
                        break;
                    }
                case 3:
                    {
                        if (GerenciadorDeTransportadora.VerificaExistenciaTransportadora())
                        {
                            Console.WriteLine("Escolha a transportadora que deseja remover: ");
                            ExibirListaTransportadoras();
                            Console.WriteLine("Insira o ID da transportadora a ser removida: ");
                            idRemocao = int.Parse(Console.ReadLine());
                            Transportadora TransportadoraRemover = GerenciadorDeTransportadora.Procura(idRemocao);
                            if (TransportadoraRemover != null)
                            {
                                GerenciadorDeTransportadora.Remover(idRemocao);
                                ExibirListaTransportadoras();
                                Console.WriteLine("Remoção realizada com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Transportadora não encontrada!");
                                Console.WriteLine("-------------------------------------------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Não há transportadoras cadastradas!");
                        }
                        PressioneQualquerTecla();
                        break;
                    }
                case 4:
                    {
                        if (GerenciadorDeTransportadora.VerificaExistenciaTransportadora())
                        {
                            Console.WriteLine("Escolha a transportadora a ser consultada:");
                            ExibirListaTransportadoras();
                            Console.WriteLine("Digite o ID da transportadora: ");
                            int idTransportadora = int.Parse(Console.ReadLine());
                            Console.WriteLine(GerenciadorDeTransportadora.ConsultarTransportadora(idTransportadora));
                            Console.WriteLine("-------------------------------------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Não há transportadoras cadastradas!");
                        }
                        PressioneQualquerTecla();
                        break;
                    }
                case 0:
                    {
                        return;
                    }

            }
        }

    }

    private void ExibirListaTransportadoras()
    {
        IList<Transportadora> TodasTransportadoras = GerenciadorDeTransportadora.Listar();
        int i;
        Console.WriteLine("Transportadoras cadastradas:");
        foreach (var item in TodasTransportadoras)
        {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine("-------------------------------------------------------------------");
    }

    private void AlteraTransportadora(Transportadora TransportadoraEditar)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("OPÇÕES DE ALTERAÇÃO DE TRANSPORTADORA:\n");

            Console.WriteLine("[1] - ALTERAR NOME");
            Console.WriteLine("[2] - ALTERAR VALOR POR KM");
            Console.WriteLine("[0] - VOLTAR AO MENU");

            int opcaoAlteracao = int.Parse(Console.ReadLine());
            string novoNome;
            double novoValor;
            switch (opcaoAlteracao)
            {
                case 1:
                    {
                        Console.WriteLine("Insira o novo nome:");
                        novoNome = Console.ReadLine();
                        GerenciadorDeTransportadora.AlteraNome(novoNome, TransportadoraEditar);
                        Console.WriteLine("Nome alterado!");
                        PressioneQualquerTecla();
                        Console.Clear();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Insira o novo valor por km:");
                        novoValor = double.Parse(Console.ReadLine());
                        GerenciadorDeTransportadora.AlteraPrecoPorKm(novoValor, TransportadoraEditar);
                        Console.WriteLine("Valor alterado!");
                        PressioneQualquerTecla();
                        Console.Clear();
                        break;
                    }
                case 0:
                    {
                        return;
                    }
            }
        }
    }

    private void PressioneQualquerTecla()
    {
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
    }

    private void MenuCliente()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("MENU DE CLIENTES\n");

            Console.WriteLine("[1] - CARRINHO DE COMPRAS");
            Console.WriteLine("[2] - CONSULTAR PEDIDOS");
            Console.WriteLine("[3] - CONSULTAR PRODUTOS");
            Console.WriteLine("[0] - FAZER LOGOUT");

            int OpcaoCliente = int.Parse(Console.ReadLine());

            switch (OpcaoCliente)
            {
                case 1:
                    {
                        // CARRINHO DE COMPRAS
                        break;
                    }
                case 2:
                    {
                        // CONSULTAR PEDIDOS
                        break;
                    }
                case 3:
                    {
                        ConsultarProdutos();
                        break;
                    }
                case 0:
                    {
                        return;
                    }
            }
        }
    }

    private void ConsultarProdutos()
    {
        while (true)
        {
            Pedido NovoPedido = new Pedido();
            int OpcaoCarrinho;

            do
            {
                Console.Clear();
                Console.WriteLine("CONSULTA DE PRODUTOS\n");
                Console.WriteLine("Digite a palavra-chave do produto que deseja consultar:");
                string ProdutoConsultado = Console.ReadLine();

                IList<Produto> ProdustosFiltrados = GerenciadorDeProduto.Listar().Where(p => p.Nome.Contains(ProdutoConsultado, StringComparison.OrdinalIgnoreCase)).ToArray();

                foreach (var produto in ProdustosFiltrados)
                {
                    Console.WriteLine(produto.ToString());
                }
                Console.WriteLine("-------------------------------------------------------------------");

                Console.WriteLine("Digite o ID do produto que deseja adicionar ao carrinho:");
                int IdProdutoSelecionado = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a quantidade que deseja adicionar ao carrinho:");
                int QntProdutoSelecionado = int.Parse(Console.ReadLine());

                Produto ProdutoPedido = GerenciadorDeProduto.Procura(IdProdutoSelecionado);

                PedidoItem NovoItem = new PedidoItem();

                NovoItem.ProdutoPedido = ProdutoPedido;
                NovoItem.PrecoTotal = ProdutoPedido.Valor * QntProdutoSelecionado;
                NovoItem.Quantidade = QntProdutoSelecionado;

                NovoPedido.ListaDeItens.Add(NovoItem);

                Console.WriteLine("[1] - ADICIONAR MAIS ITENS AO CARRINHO");
                Console.WriteLine("[2] - FINALIZAR CARRINHO");
                OpcaoCarrinho = int.Parse(Console.ReadLine());
            } while (OpcaoCarrinho == 1);

            Console.WriteLine("Selecione a transportadora:");
            IList<Transportadora> SelecionarTRansportadora = GerenciadorDeTransportadora.Listar();
            foreach (var transportadora in SelecionarTRansportadora)
            {
                Console.WriteLine(transportadora.ToString());
            }
            Console.WriteLine("-------------------------------------------------------------------");

            Console.WriteLine("Digite o ID da transportadora que deseja utilizar:");
            int IdTransportadoraSelecionada = int.Parse(Console.ReadLine());

            Transportadora TransportadoraSelecionada = GerenciadorDeTransportadora.Procura(IdTransportadoraSelecionada);

            NovoPedido.TransportadoraPedido = TransportadoraSelecionada;

            return;
        }
    }
}
