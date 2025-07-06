using Biblioteca.Repositorio.Lista;
using Biblioteca.Repositorio.Lista.RepositorioPedidosL;
using Biblioteca.Repositorio.Vetor.RepositorioPedidosV;
using Biblioteca.Repositorios.Interfaces;
using ProjetoLoja;

Console.Clear();

GerenciadorDeMenus gerenciadorDeMenus = new GerenciadorDeMenus();

Console.WriteLine("Insira a opção de inicialização:");
Console.WriteLine("[1] - ARMAZENAMENTO EM VETOR");
Console.WriteLine("[2] - ARMAZENAMENTO EM LISTA");
int o = gerenciadorDeMenus.LerInteiro(1, 2);

if (o == 1)
{
    gerenciadorDeMenus = new GerenciadorDeMenus(new RepositorioUsuarioV(), new RepositorioFornecedorV(), new RepositorioProdutoV(), new RepositorioTransportadoraV(), new RepositorioClienteV(), new RepositorioPedidoV());
}
else
{
    gerenciadorDeMenus = new GerenciadorDeMenus(new RepositorioUsuarioL(), new RepositorioFornecedorL(), new RepositorioProdutoL(), new RepositorioTransportadoraL(), new RepositorioClienteL(), new RepositorioPedidoL());
}


