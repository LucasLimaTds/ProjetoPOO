using System;
using System.ComponentModel;
using System.Security.Principal;
using ProjetoLoja;
using Biblioteca.Repositorio.Vetor;
using Biblioteca.Repositorios.Interfaces;
using Bilbioteca.Base;
using Biblioteca.Base.EstruturaDaLoja;
using Biblioteca.Repositorios.Interfaces.InterfacesPedidos;
using System.Text.Json;
using System.Net.Http.Headers;
using Microsoft.VisualBasic;
using Biblioteca.Excecoes;
using System.Linq.Expressions;


namespace ProjetoLoja;

public class GerenciadorDeMenus
{
    private IRepositorioUsuario GerenciadorDeUsuario;
    private IRepositorioFornecedor GerenciadorDeFornecedor;
    private IRepositorioProduto GerenciadorDeProduto;
    private IRepositorioTransportadora GerenciadorDeTransportadora;
    private IRepositorioCliente GerenciadorDeCliente;
    private IRepositorioPedido GerenciadorDePedido;


    public GerenciadorDeMenus()
    {
        
    }
    public GerenciadorDeMenus(IRepositorioUsuario GU, IRepositorioFornecedor GF, IRepositorioProduto GP, IRepositorioTransportadora GT, IRepositorioCliente GC, IRepositorioPedido GPE)
    {
        GerenciadorDeUsuario = GU;
        GerenciadorDeFornecedor = GF;
        GerenciadorDeProduto = GP;
        GerenciadorDeTransportadora = GT;
        GerenciadorDeCliente = GC;
        GerenciadorDePedido = GPE;
        CarregaDados();
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

            int OpcaoUsuario = LerInteiro(0, 2);

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
                        SalvaDados();
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

        Usuario UsuarioAtual = null;

        if (GerenciadorDeUsuario.ValidarUsuario(Email, Senha, UsuarioAtual) == 0)
        {
            MenuAdmin(); //mostra as opções para usuarios admin
        }
        else if (GerenciadorDeUsuario.ValidarUsuario(Email, Senha, UsuarioAtual) == 1)
        {
            MenuCliente(UsuarioAtual); //mostra opcoes para clientes 
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
            OpcaoUsuario = LerInteiro(0, 4);

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
        Console.WriteLine("[2] - REALIZAR ALTERAÇÃO DE USUÁRIO");
        Console.WriteLine("[3] - CONSULTAR USUÁRIOS CADASTRADOS");
        Console.WriteLine("[4] - ACESSAR PEDIDOS DE CLIENTES");
        Console.WriteLine("[0] - VOLTAR AO MENU");
    }

    private void MenuCadastroUsuarios()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("OPÇÕES DE CADASTRO DE USUÁRIOS:\n");

            OpcoesDoCadastroDeUsuarios();

            int OpcaoUsuario = LerInteiro(0, 4);

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
                        int id = LerInteiro(-1, -1);
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
                case 4:
                    {
                        AcessarPedidos();
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
            int opcaoAlteracao = LerInteiro(0, 2);
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

    private void AcessarPedidos()
    {
        Console.Clear();
        int consultaPedido = 1;
        do
        {
            Console.WriteLine("CONSULTAR PEDIDOS:");
            Console.WriteLine("[1] - LISTAR TODOS");
            Console.WriteLine("[2] - POR NÚMERO");
            Console.WriteLine("[3] - POR DATA DE REALIZACAO");
            int opcaoUsuario = LerInteiro(1, 3);

            if (opcaoUsuario == 1)
            {
                foreach (var pedido in GerenciadorDePedido.Listar())
                {
                    Console.WriteLine(pedido.ToString());
                }
                opcaoUsuario = 0;
            }

            if (opcaoUsuario == 3)
            {
                Console.WriteLine("Digite a data de realização a ser consultada");
                DateTime dataConsulta = DateTime.Parse(Console.ReadLine());
                IList<Pedido> pedidosFiltrados = GerenciadorDePedido.FiltroDataRealizacao(dataConsulta);
                foreach (var pedido in pedidosFiltrados)
                {
                    Console.WriteLine(pedido.ToString());
                }
            }

            Console.WriteLine("Digite o número do pedido que deseja consultar:");
            int Npedido = LerInteiro(-1, -1);
            Pedido PedidoConsultado = GerenciadorDePedido.Procura(Npedido);
            if (PedidoConsultado != null)
            {
                EscreveDetalhesPedido(PedidoConsultado);
                Console.WriteLine("[1] - CONSULTAR NOVO PEDIDO");
                Console.WriteLine("[2] - EDITAR O PEDIDO CONSULTADO");
                Console.WriteLine("[0] - VOLTAR AO MENU");
                consultaPedido = LerInteiro(0, 2);

                if (consultaPedido == 2)
                {
                    EditarPedido(PedidoConsultado);
                }
            }
            else
            {
                Console.WriteLine("Pedido não encontrado!");
                Console.WriteLine("-------------------------------------------------------------------");
                PressioneQualquerTecla();
            }
        }
        while (consultaPedido == 1);
    }

    private void EditarPedido(Pedido PedidoConsultado)
    {
        Console.WriteLine("Escolha a nova situação do pedido:");
        Console.WriteLine("[1] - Em trânsito");
        Console.WriteLine("[2] - Entregue");
        Console.WriteLine("[3] - Cancelado");

        int opcaoSituacao = LerInteiro(1, 3);
        GerenciadorDePedido.AlterarSituacao(opcaoSituacao, PedidoConsultado);
        Console.WriteLine("Situação atualizada!");
        PressioneQualquerTecla();
        Console.Clear();
    }

    private void MenuCadastroFornecedores()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("OPÇÕES DE CADASTRO DE FORNECEDORES:\n");

            OpcoesDoCadastro();

            int OpcaoFornecedor = LerInteiro(0, 4);
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
                            int id = LerInteiro(-1, -1);
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
                            idRemocao = LerInteiro(-1, -1);
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
                            int idFornecedor = LerInteiro(-1, -1);
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
        Console.WriteLine("\nFornecedores cadastrados:");
        foreach (var item in TodosFornecedores)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("-------------------------------------------------------------------");
    }

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

            int opcaoAlteracao = LerInteiro(0, 5);
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

            int OpcaoProduto = LerInteiro(0, 4);
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
                        do
                        {
                            bool FlagValor = true;
                            try
                            {
                                valor = double.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Valor digitado inválido! Digite novamente:");
                                valor = -1;
                                FlagValor = false;
                            }
                            if (valor <= 0 && FlagValor)
                            {
                                Console.WriteLine("Valor digitado inválido! Digite novamente:");
                                valor = -1; 
                            }
                        }
                        while (valor == -1);

                        Console.WriteLine("Insira a quantidade do produto: ");
                        do
                        {
                            bool FlagQnt = true;
                            try
                            {
                                quantidade = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Valor digitado inválido! Digite novamente:");
                                quantidade = -1;
                                FlagQnt = false;
                            }
                            if (quantidade < 0 && FlagQnt)
                            {
                                Console.WriteLine("Valor digitado inválido! Digite novamente:");
                                quantidade = -1; 
                            }
                        }
                        while (quantidade == -1);

                        Console.WriteLine("Escolha o fornecedor para o produto:");
                        ExibirListaFornecedores();
                        idfornecedor = LerInteiro(-1, -1);

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
                            int id = LerInteiro(-1, -1);
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
                            idRemocao = LerInteiro(-1, -1);
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
                            int idProduto = LerInteiro(-1, -1);
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

            int opcaoAlteracao = LerInteiro(0, 4);
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
                        do
                        {
                            bool FlagValor = true;
                            try
                            {
                                novoValor = double.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Valor digitado inválido! Digite novamente:");
                                novoValor = -1;
                                FlagValor = false;
                            }
                            if (novoValor <= 0 && FlagValor)
                            {
                                Console.WriteLine("Valor digitado inválido! Digite novamente:");
                                novoValor = -1; 
                            }
                        }
                        while (novoValor == -1);

                        GerenciadorDeProduto.AlterarValor(novoValor, ProdutoAlterado);
                        Console.WriteLine("Valor alterado!");
                        PressioneQualquerTecla();
                        Console.Clear();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Insira a nova quantidade em estoque:");
                        do
                        {
                            bool FlagQnt = true;
                            try
                            {
                                novaQnt = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Valor digitado inválido! Digite novamente:");
                                novaQnt = -1;
                                FlagQnt = false;
                            }
                            if (novaQnt < 0 && FlagQnt)
                            {
                                Console.WriteLine("Valor digitado inválido! Digite novamente:");
                                novaQnt = -1; 
                            }
                        }
                        while (novaQnt == -1);

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
                        novoId = LerInteiro(-1, -1);
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

            int OpcaoTransportadora = LerInteiro(0, 4);
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
                        do
                        {
                            bool FlagValor = true;
                            try
                            {
                                valor = double.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Valor digitado inválido! Digite novamente:");
                                valor = -1;
                                FlagValor = false;
                            }
                            if (valor <= 0 && FlagValor)
                            {
                                Console.WriteLine("Valor digitado inválido! Digite novamente:");
                                valor = -1; 
                            }
                        }
                        while (valor == -1);
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
                            int id = LerInteiro(-1, -1);
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
                            idRemocao = LerInteiro(-1, -1);
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
                            int idTransportadora = LerInteiro(-1, -1);
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

            int opcaoAlteracao = LerInteiro(0, 2);
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
                        do
                        {
                            bool FlagValor = true;
                            try
                            {
                                novoValor = double.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Valor digitado inválido! Digite novamente:");
                                novoValor = -1;
                                FlagValor = false;
                            }
                            if (novoValor <= 0 && FlagValor)
                            {
                                Console.WriteLine("Valor digitado inválido! Digite novamente:");
                                novoValor = -1; 
                            }
                        }
                        while (novoValor == -1);
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

    private void MenuCliente(Usuario UsuarioAtual)
    {
        Cliente ClienteAtual = GerenciadorDeCliente.ProcuraCliente(UsuarioAtual);
        while (true)
        {
            Console.Clear();
            Console.WriteLine("MENU DE CLIENTES\n");

            Console.WriteLine("[1] - CARRINHO DE COMPRAS");
            Console.WriteLine("[2] - CONSULTAR PEDIDOS");
            Console.WriteLine("[0] - FAZER LOGOUT");

            int OpcaoCliente = LerInteiro(0, 2);

            switch (OpcaoCliente)
            {
                case 1:
                    {
                        CarrinhoDeCompras(ClienteAtual);
                        break;
                    }
                case 2:
                    {
                        ConsultarPedidos(ClienteAtual);
                        break;
                    }
                case 0:
                    {
                        return;
                    }
            }
        }
    }

    private void CarrinhoDeCompras(Cliente ClienteAtual)
    {
        Pedido NovoPedido = new Pedido();
        CriarPedido(ClienteAtual, ref NovoPedido);
        // lógica de edição do carrinho
        if (NovoPedido.Itens.Count != 0)
        {
            GerenciadorDePedido.Cadastrar(NovoPedido);
            for (int i = 0; i < NovoPedido.Itens.Count; i++) //Decrementa estoque dos produtos do pedido
            {
                NovoPedido.Itens[i].ProdutoPedido.QuantidadeEmEstoque -= NovoPedido.Itens[i].Quantidade;
            }
            Console.WriteLine("\nResumo do seu carrinho:");
            EscreveDetalhesPedido(NovoPedido);
            PressioneQualquerTecla();
        }
    }

    private void ConsultarPedidos(Cliente ClienteAtual)
    {
        Console.Clear();
        Console.WriteLine("Escolha a opção de consulta:");
        Console.WriteLine("[1] - POR NÚMERO");
        Console.WriteLine("[2] - POR INTERVALO DE DATAS");
        int opcaoUsuario = LerInteiro(1, 2);

        if (opcaoUsuario == 2)
        {
            Console.WriteLine("Digite a data inicial e final do filtro");
            Console.Write("Data inicial: ");
            DateTime dataInicial = DateTime.Parse(Console.ReadLine());
            Console.Write("Data final: ");
            DateTime dataFinal = DateTime.Parse(Console.ReadLine());
            IList<Pedido> PedidosDoClientePorData = GerenciadorDePedido.FiltroIntervaloDatas(dataInicial, dataFinal, ClienteAtual);
            foreach (var pedido in PedidosDoClientePorData)
            {
                Console.WriteLine(pedido.ToString());
            }
            Console.WriteLine("-------------------------------------------------------------------");
        }

        Pedido pedidoConsultado;
        do
        {
            Console.WriteLine("Digite o número do pedido que deseja consultar:");
            int Npedido = LerInteiro(-1, -1);
            pedidoConsultado = GerenciadorDePedido.ProcuraComCliente(Npedido, ClienteAtual);
            if (pedidoConsultado == null)
            {
                Console.WriteLine("Número de pedido inválido! Tente novamente.");
            }
        }
        while (pedidoConsultado == null);

        EscreveDetalhesPedido(pedidoConsultado);
        PressioneQualquerTecla();
    }

    private void CriarPedido(Cliente ClienteAtual, ref Pedido NovoPedido)
    {
        while (true)
        {
            NovoPedido.ClienteDoPedido = ClienteAtual;
            int OpcaoCarrinho;
            int confirma = 1;

            do
            {
                Console.Clear();
                Console.WriteLine("CONSULTA DE PRODUTOS\n");
                IList<Produto> ProdutosFiltrados;
                do
                {
                    Console.WriteLine("Digite a palavra-chave ou o código do produto que deseja consultar:");
                    string ProdutoConsultado = Console.ReadLine();

                    ProdutosFiltrados = GerenciadorDeProduto.FiltroNomeProduto(ProdutoConsultado);
                    if (ProdutosFiltrados.Count == 0)
                        Console.WriteLine("Nenhum item corresponde a sua consulta! Tente novamente.");

                }
                while (ProdutosFiltrados.Count == 0);

                foreach (var produto in ProdutosFiltrados)
                {
                    Console.WriteLine(produto.ToString());
                }
                Console.WriteLine("-------------------------------------------------------------------");

                Produto ProdutoPedido;
                do
                {
                    Console.WriteLine("Digite o ID do produto que deseja adicionar ao carrinho:");
                    int IdProdutoSelecionado = LerInteiro(-1, -1);
                    ProdutoPedido = GerenciadorDeProduto.Procura(IdProdutoSelecionado);
                    if (ProdutoPedido == null)
                        Console.WriteLine("Não há produtos com o código digitado! Tente novamente.");
                }
                while (ProdutoPedido == null);

                Console.WriteLine("Digite a quantidade que deseja adicionar ao carrinho:");
                int QntProdutoSelecionado;
                do
                {
                    bool FlagQnt = true;
                    try
                    {
                        QntProdutoSelecionado = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Valor digitado inválido! Digite novamente:");
                        FlagQnt = false;
                        QntProdutoSelecionado = -1;
                    }
                    if (QntProdutoSelecionado < 1 && FlagQnt)
                    {
                        Console.WriteLine("Valor digitado inválido! Digite novamente:");
                        QntProdutoSelecionado = -1;
                    }
                }
                while (QntProdutoSelecionado == -1);

                PedidoItem NovoItem = new PedidoItem();
                try
                {
                    NovoItem = new PedidoItem(QntProdutoSelecionado, ProdutoPedido.Valor * QntProdutoSelecionado, ProdutoPedido);
                }
                catch (ExcecaoEstoqueZero ez)
                {
                    Console.WriteLine(ez.Message);
                    Console.WriteLine("[1] - IR PARA FINALIZAÇÃO DO PEDIDO");
                    Console.WriteLine("[2] - ESCOLHER OUTRO PRODUTO");
                    int OpcaoPedidoZero = LerInteiro(1, 2);
                    if (OpcaoPedidoZero == 1)
                    {
                        if (NovoPedido.Itens.Count != 0)
                        {
                            break;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Escolha um novo produto.");
                        PressioneQualquerTecla();
                        confirma = 2;                        
                    }
                }
                catch (ExcecaoLimiteEstoqueAlcancado la)
                {
                    Console.WriteLine(la.Message);
                    Console.WriteLine("No momento há somente " + ProdutoPedido.QuantidadeEmEstoque + " itens em estoque.\nDeseja adicionar todos ao carrinho?");
                    Console.WriteLine("[1] - SIM");
                    Console.WriteLine("[2] - NÃO");
                    int adiciona = LerInteiro(1, 2);
                    if (adiciona == 1)
                        NovoItem = new PedidoItem(ProdutoPedido.QuantidadeEmEstoque, ProdutoPedido.Valor * ProdutoPedido.QuantidadeEmEstoque, ProdutoPedido);
                    else
                    {
                        confirma = 2;   
                    }
                }

                if (confirma != 2)
                {
                    Console.WriteLine("Total do item " + NovoItem.ProdutoPedido.Nome + ": R$" + NovoItem.PrecoTotal + "\n" + "Confirmar inclusão?");
                    Console.WriteLine("[1] - SIM");
                    Console.WriteLine("[2] - NÃO");
                    confirma = LerInteiro(1, 2);
                }

                if (confirma == 1 || NovoPedido.Itens.Count != 0)
                {
                    if (confirma == 1)
                        NovoPedido.Itens.Add(NovoItem);

                    Console.WriteLine("[1] - ADICIONAR MAIS ITENS AO CARRINHO");
                    Console.WriteLine("[2] - FINALIZAR CARRINHO");
                    OpcaoCarrinho = LerInteiro(1, 2);
                }

                else
                {
                    OpcaoCarrinho = 1;
                    confirma = 1;
                }

            } while (OpcaoCarrinho == 1);

            Console.WriteLine("Selecione a transportadora:");
            IList<Transportadora> SelecionarTRansportadora = GerenciadorDeTransportadora.Listar();
            foreach (var transportadora in SelecionarTRansportadora)
            {
                Console.WriteLine(transportadora.ToString());
            }
            Console.WriteLine("-------------------------------------------------------------------");

            Console.WriteLine("Digite o ID da transportadora que deseja utilizar:");
            int IdTransportadoraSelecionada = LerInteiro(-1, -1);

            Transportadora TransportadoraSelecionada = GerenciadorDeTransportadora.Procura(IdTransportadoraSelecionada);

            NovoPedido.TransportadoraPedido = TransportadoraSelecionada;
            Console.WriteLine("Digite a quilometragem:");
            double kms;
            do
            {
                bool FlagKm = true;
                try
                {
                    kms = double.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Valor digitado inválido! Digite novamente:");
                    kms = -1;
                    FlagKm = false;
                }
                if (kms <= 0 && FlagKm)
                {
                    Console.WriteLine("Valor digitado inválido! Digite novamente:");
                    kms = -1; 
                }
            }
            while (kms == -1);

            NovoPedido.PrecoFrete = kms * TransportadoraSelecionada.PrecoPorKM;
            NovoPedido.PrecoTotal = NovoPedido.PrecoFrete;
            for (int i = 0; i < NovoPedido.Itens.Count; i++)
            {
                NovoPedido.PrecoTotal += NovoPedido.Itens[i].PrecoTotal;
            }

            NovoPedido.DataHoraPedido = DateTime.Now;
            return;
        }
    }

    private void EscreveDetalhesPedido(Pedido PedidoConsultado)
    {
        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine(PedidoConsultado.DetalhesPedido());
        Console.WriteLine("------------------------------------------------------------------------------------");
        foreach (var descricaoPedido in PedidoConsultado.Itens)
        {
            Console.WriteLine(descricaoPedido.ToString());
        }
        Console.WriteLine("------------------------------------------------------------------------------------");
    }

    private void CarregaDados()
    {
        // Testa se o Json é nulo para cada repositório
        try
        {
            GerenciadorDeUsuario.CarregaUsuarios();
        }
        catch (JsonException)
        {

        }
        // ============================================================        
        try
        {
            GerenciadorDeProduto.CarregaProdutos();
        }
        catch (JsonException)
        {

        }
        // ============================================================
        try
        {
            GerenciadorDeFornecedor.CarregaFornecedores();
        }
        catch (JsonException)
        {

        }
        // ============================================================
        try
        {
            GerenciadorDeTransportadora.CarregaTransportadoras();
        }
        catch (JsonException)
        {

        }
        // ============================================================
        try
        {
            GerenciadorDeCliente.CarregaClientes();
        }
        catch (JsonException)
        {

        }
        // ============================================================
        try
        {
            GerenciadorDePedido.CarregaPedidos();
        }
        catch (JsonException)
        {

        }
    }

    private void SalvaDados()
    {
        GerenciadorDeUsuario.SalvaUsuarios();
        GerenciadorDeProduto.SalvaProdutos();
        GerenciadorDeFornecedor.SalvaFornecedores();
        GerenciadorDeTransportadora.SalvaTransportadoras();
        GerenciadorDeCliente.SalvaClientes();
        GerenciadorDePedido.SalvaPedidos();
    }

    public int LerInteiro(int LimiteMenor, int LimiteMaior)
    {
        int ValorSelecionado;
        do
        {
            bool Flag = true;
            try
            {
                ValorSelecionado = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Valor digitado inválido! Digite novamente:");
                ValorSelecionado = -1;
                Flag = false;
            }
            if (LimiteMenor == -1 && LimiteMaior == -1 && Flag)
            {
                // Está verificando os ID's dos objetos.
                if (ValorSelecionado == -1)
                {
                    ValorSelecionado = -2;
                }
            }
            else if ((ValorSelecionado > LimiteMaior || ValorSelecionado < LimiteMenor) && Flag)
            {
                // Está verificando as opções dos menus.
                Console.WriteLine("Valor digitado inválido! Digite novamente: ");
                ValorSelecionado = -1;
            }
        }
        while (ValorSelecionado == -1);


        return ValorSelecionado;
    }
}
