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


        string novaRua="";
        string novoNumero="";
        string novoComplemento="";
        string novoBairro="";
        string novoCEP="";
        string novaCidade="";
        string novoEstado="";

        CadastroEndereco(ref novaRua, ref novoNumero, ref novoComplemento, ref novoBairro, ref novoCEP, ref novaCidade, ref novoEstado);

       
        GerenciadorDeUsuario.CriarUsuario(new Usuario(novoNome, novoEmail, novoTelefone, novaSenha, 1, novaRua, novoNumero, novoComplemento, novoBairro, novoCEP, novaCidade, novoEstado));
        GerenciadorDeUsuario.ListarUsuarios();
        PressioneQualquerTecla();
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
            string novaRua = "";
            string novoNumero = "";
            string novoComplemento = "";
            string novoBairro = "";
            string novoCEP = "";
            string novaCidade = "";
            string novoEstado = "";
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
                        GerenciadorDeFornecedor.CadastrarFornecedor(new Fornecedor(nome, email, descricao, telefoneFornecedor, novaRua, novoNumero, novoComplemento, novoBairro, novoCEP, novaCidade, novoEstado));
                        GerenciadorDeFornecedor.ListarFornecedores();

                        Console.WriteLine("Inclusão realizada com sucesso!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 2:
                    {
                        if (GerenciadorDeFornecedor.VerificaExistenciaFornecedor())
                        {
                            Console.WriteLine("Escolha o fornecedor que deseja editar:");
                            GerenciadorDeFornecedor.ListarFornecedores();
                            int id = int.Parse(Console.ReadLine());
                            if (id == 0)
                            {
                                Console.WriteLine("Fornecedor padrão do sistema! Impossível alterar");
                            }
                            else
                            {                                
                                int i = GerenciadorDeFornecedor.ProcuraFornecedor(id);
                                if (i != -1)
                                {
                                    AlterarFornecedor(i);
                                }
                                else
                                {
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
                            GerenciadorDeFornecedor.ListarFornecedores();
                            Console.WriteLine("Insira o ID do fornecedor a ser removido: ");
                            idRemocao = int.Parse(Console.ReadLine());
                            if (idRemocao == 0)
                            {
                                Console.WriteLine("Fornecedor padrão do sistema! Impossível remover");
                            }
                            else
                            {   
                                GerenciadorDeProduto.RemocaoDeFornecedor(idRemocao, GerenciadorDeFornecedor.RetornaFornecedor(0));
                                int i = GerenciadorDeFornecedor.ProcuraFornecedor(idRemocao);
                                if (i != -1)
                                {
                                    GerenciadorDeFornecedor.RemoverFornecedor(idRemocao);
                                    GerenciadorDeFornecedor.ListarFornecedores();
                                    Console.WriteLine("Remoção realizada com sucesso!"); 
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
                            GerenciadorDeFornecedor.ListarFornecedores();
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

    private void AlterarFornecedor(int i)
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

            int opcaoAlteracao=int.Parse(Console.ReadLine());
            string novoNome;
            string novaDescricao;
            string novoTelefone;
            string novoEmail;

            string novaRua="";
            string novoNumero="";
            string novoComplemento="";
            string novoBairro="";
            string novoCEP="";
            string novaCidade="";
            string novoEstado="";

            switch (opcaoAlteracao)
            {
                case 1:
                    {
                        Console.WriteLine("Insira o novo nome:");
                        novoNome = Console.ReadLine();
                        GerenciadorDeFornecedor.AlterarNome(novoNome, i);
                        Console.WriteLine("Nome alterado!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Insira a nova descrição:");
                        novaDescricao = Console.ReadLine();
                        GerenciadorDeFornecedor.AlterarDescricao(novaDescricao, i);
                        Console.WriteLine("Descrição alterada!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Insira o novo telefone:");
                        novoTelefone = Console.ReadLine();
                        GerenciadorDeFornecedor.AlterarTelefone(novoTelefone, i);
                        Console.WriteLine("Telefone alterado!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Insira o novo email:");
                        novoEmail = Console.ReadLine();
                        GerenciadorDeFornecedor.AlterarEmail(novoEmail, i);
                        Console.WriteLine("Email alterado!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 5:
                    {
                        CadastroEndereco(ref novaRua, ref novoNumero, ref novoComplemento, ref novoBairro, ref novoCEP, ref novaCidade, ref novoEstado);

                        GerenciadorDeFornecedor.AlterarEndereco(novaRua, novoNumero, novoComplemento, novoBairro, novoCEP, novaCidade, novoEstado, i);

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
            int idfornecedor, indfornecedor;

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
                        GerenciadorDeFornecedor.ListarFornecedores();
                        idfornecedor = int.Parse(Console.ReadLine());

                        indfornecedor = GerenciadorDeFornecedor.ProcuraFornecedor(idfornecedor);
                        if (indfornecedor != -1)
                        {                            
                            GerenciadorDeProduto.CadastrarProduto(new Produto(nome, valor, quantidade, GerenciadorDeFornecedor.RetornaFornecedor(indfornecedor)));
                            GerenciadorDeProduto.ListarProdutos();
                            Console.WriteLine("Inclusão realizada com sucesso!");
                        }

                        PressioneQualquerTecla();
                        break;
                    }
                case 2:
                    {
                        if (GerenciadorDeProduto.VerificaExistenciaProduto())
                        {
                            Console.WriteLine("Escolha o produto que deseja editar:");
                            GerenciadorDeProduto.ListarProdutos();
                            int id = int.Parse(Console.ReadLine());
                            int i = GerenciadorDeProduto.ProcuraProduto(id);
                            if (i != -1)
                            {
                                AlterarProduto(i);
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
                            GerenciadorDeProduto.ListarProdutos();
                            Console.WriteLine("Insira o ID do produto a ser removido: ");
                            idRemocao = int.Parse(Console.ReadLine());
                            int i = GerenciadorDeProduto.ProcuraProduto(idRemocao);
                            if (i != -1)
                            {
                                GerenciadorDeProduto.RemoverProduto(idRemocao);
                                GerenciadorDeProduto.ListarProdutos();
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
                            GerenciadorDeProduto.ListarProdutos();
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

    private void AlterarProduto(int i)
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

            int opcaoAlteracao=int.Parse(Console.ReadLine());
            string novoNome;
            double novoValor;
            int novo, ind;
            switch (opcaoAlteracao)
            {
                case 1:
                    {
                        Console.WriteLine("Insira o novo nome:");
                        novoNome = Console.ReadLine();
                        GerenciadorDeProduto.TodosProdutos[i].Nome = novoNome;
                        Console.WriteLine("Nome alterado!");
                        PressioneQualquerTecla();
                        Console.Clear();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Insira o novo valor:");
                        novoValor = double.Parse(Console.ReadLine());
                        GerenciadorDeProduto.TodosProdutos[i].Valor = novoValor;
                        Console.WriteLine("Valor alterado!");
                        PressioneQualquerTecla();
                        Console.Clear();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Insira a nova quantidade em estoque:");
                        novo = int.Parse(Console.ReadLine());
                        GerenciadorDeProduto.TodosProdutos[i].QuantidadeEmEstoque = novo;
                        Console.WriteLine("Quantidade alterada!");
                        PressioneQualquerTecla();
                        Console.Clear();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Escolha o novo fornecedor:");
                        GerenciadorDeFornecedor.ListarFornecedores();
                        Console.WriteLine("Insira o ID do novo fornecedor:");
                        novo = int.Parse(Console.ReadLine());
                        ind = GerenciadorDeFornecedor.ProcuraFornecedor(novo);
                        if (ind != -1)
                        {
                            GerenciadorDeProduto.TodosProdutos[i].FornecedorDoProduto = GerenciadorDeFornecedor.RetornaFornecedor(ind);
                            Console.WriteLine("Fornecedor alterado!");  
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
                        GerenciadorDeTransportadora.ListarTransportadoras();

                        Console.WriteLine("Inclusão realizada com sucesso!");
                        PressioneQualquerTecla();
                        break;
                    }
                case 2:
                    {
                        if (GerenciadorDeTransportadora.VerificaExistenciaTransprtadora())
                        {
                            Console.WriteLine("Escolha a transportadora que deseja editar");
                            GerenciadorDeTransportadora.ListarTransportadoras();
                            int id = int.Parse(Console.ReadLine());
                            int i = GerenciadorDeTransportadora.ProcuraTransportadora(id);

                            if (i != -1)
                            {
                                AlteraTransportadora(i);
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
                        if (GerenciadorDeTransportadora.VerificaExistenciaTransprtadora())
                        {
                            Console.WriteLine("Escolha a transportadora que deseja remover: ");
                            GerenciadorDeTransportadora.ListarTransportadoras();
                            Console.WriteLine("Insira o ID da transportadora a ser removida: ");
                            idRemocao = int.Parse(Console.ReadLine());
                            int i = GerenciadorDeFornecedor.ProcuraFornecedor(idRemocao);
                            if (i != -1)
                            {
                                GerenciadorDeTransportadora.RemoverTransportadora(idRemocao);
                                GerenciadorDeTransportadora.ListarTransportadoras();
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
                        if (GerenciadorDeTransportadora.VerificaExistenciaTransprtadora())
                        {
                            Console.WriteLine("Escolha a transportadora a ser consultada:");
                            GerenciadorDeTransportadora.ListarTransportadoras();
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

    private void AlteraTransportadora(int i)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("OPÇÕES DE ALTERAÇÃO DE TRANSPORTADORA:\n");

            Console.WriteLine("[1] - ALTERAR NOME");
            Console.WriteLine("[2] - ALTERAR VALOR POR KM");
            Console.WriteLine("[0] - VOLTAR AO MENU");

            int opcaoAlteracao=int.Parse(Console.ReadLine());
            string novoNome;
            double novoValor;
            switch (opcaoAlteracao)
            {
                case 1:
                    {
                        Console.WriteLine("Insira o novo nome:");
                        novoNome = Console.ReadLine();
                        GerenciadorDeTransportadora.AlteraNome(novoNome, i);
                        Console.WriteLine("Nome alterado!");
                        PressioneQualquerTecla();
                        Console.Clear();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Insira o novo valor por km:");
                        novoValor = double.Parse(Console.ReadLine());
                        GerenciadorDeTransportadora.AlteraPrecoPorKm(novoValor, i);
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
