using System;
using System.ComponentModel;
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
            PressioneQualquerTecla();
        }
    }

    private void CriarUsuario()
    {
        Console.Write("Digite o nome do novo usuário: ");
        string novoNome = Console.ReadLine();

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
        
        Console.Write("Digite o telefone do novo usuário: ");
        string novoTelefone = Console.ReadLine();

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
       
        GerenciadorDeUsuario.CriarUsuario(new Usuario(novoNome, novoEmail, novoTelefone, novaSenha, 1, CadastroEndereco()));
        GerenciadorDeUsuario.ListarUsuarios();
        PressioneQualquerTecla();
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
                        PressioneQualquerTecla();
                        break;
                    }
                case 2:
                    {
                        MenuCadastroUsuarios();
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

    private void MenuCadastroUsuarios()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("OPÇÕES DE CADASTRO DE USUÁRIOS:\n");

            OpcoesDoCadastro();

            int OpcaoUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("SERÁ IMPLEMENTADO NA SEGUNDA PARTE");
            PressioneQualquerTecla();
            return;

            // CONTINUA
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

                        GerenciadorDeFornecedor.CadastrarFornecedor(new Fornecedor(nome, email, descricao, telefoneFornecedor, CadastroEndereco()));
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
                                Fornecedor FornecedorEditar = GerenciadorDeFornecedor.ProcuraFornecedor(id);
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
                                GerenciadorDeProduto.RemocaoDeFornecedor(idRemocao, GerenciadorDeFornecedor.ProcuraFornecedor(0));
                                Fornecedor FornecedorRemocao = GerenciadorDeFornecedor.ProcuraFornecedor(idRemocao);
                                if (FornecedorRemocao != null)
                                {
                                    GerenciadorDeFornecedor.RemoverFornecedor(idRemocao);
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
                            GerenciadorDeFornecedor.ConsultarFornecedor(idFornecedor);
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
        Fornecedor[] TodosFornecedores = GerenciadorDeFornecedor.ListarFornecedores();
        int i;
        Console.WriteLine("\nFornecedores cadastrados:");
        for (i = 0; i < TodosFornecedores.Length; i++)
        {
            Console.WriteLine($"Fornecedor ID: {TodosFornecedores[i].ID} | Nome: {TodosFornecedores[i].Nome}");
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

                        Fornecedor FornecedorDoProduto = GerenciadorDeFornecedor.ProcuraFornecedor(idfornecedor);
                        if (FornecedorDoProduto != null)
                        {
                            GerenciadorDeProduto.CadastrarProduto(new Produto(nome, valor, quantidade, FornecedorDoProduto));
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
                            Produto ProdutoEditar = GerenciadorDeProduto.ProcuraProduto(id);
                            if (ProdutoEditar != null)
                            {
                                AlterarProduto(ProdutoEditar);
                            }
                            else
                            {
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
                            Produto ProdutoRemover = GerenciadorDeProduto.ProcuraProduto(idRemocao);
                            if (ProdutoRemover != null)
                            {
                                GerenciadorDeProduto.RemoverProduto(idRemocao);
                                ExibirListaProdutos();
                                Console.WriteLine("Remoção realizada com sucesso!");
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
                            GerenciadorDeProduto.ConsultarProduto(idProduto);
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
        Produto[] TodosProdutos = GerenciadorDeProduto.ListarProdutos();
        int i;
        Console.WriteLine("Produtos cadastrados:");
        for (i = 0; i < TodosProdutos.Length; i++)
        {
            Console.WriteLine($"Produto ID: {TodosProdutos[i].ID} | Nome: {TodosProdutos[i].Nome}");
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
                        Fornecedor FornecedorAlterado = GerenciadorDeFornecedor.ProcuraFornecedor(novoId);
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
                        GerenciadorDeTransportadora.CadastrarTransportadora(new Transportadora(nome, valor));
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
                            Transportadora TransportadoraEditada = GerenciadorDeTransportadora.ProcuraTransportadora(id);

                            if (TransportadoraEditada != null)
                            {
                                AlteraTransportadora(TransportadoraEditada);
                            }
                            else
                            {
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
                            Transportadora TransportadoraRemover = GerenciadorDeTransportadora.ProcuraTransportadora(idRemocao);
                            if (TransportadoraRemover != null)
                            {
                                GerenciadorDeTransportadora.RemoverTransportadora(idRemocao);
                                ExibirListaTransportadoras();
                                Console.WriteLine("Remoção realizada com sucesso!"); 
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
                            GerenciadorDeTransportadora.ConsultarTransportadora(idTransportadora);
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
        Transportadora[] TodasTransportadoras = GerenciadorDeTransportadora.ListarTransportadoras();
        int i;
        Console.WriteLine("Transportadoras cadastradas:");
        for (i = 0; i < TodasTransportadoras.Length; i++)
        {
            Console.WriteLine($"Transportadora ID: {TodasTransportadoras[i].ID} | Nome: {TodasTransportadoras[i].Nome}");
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
        //aqui terá os menus das opções de clientes
    }
}
