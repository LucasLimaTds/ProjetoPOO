using System;
using Biblioteca.Base.EstruturaDaLoja;
using ProjetoLoja;

namespace Biblioteca.Repositorios.Interfaces.InterfacesPedidos;

public interface IRepositorioPedido : IRepositorioBase<Pedido>
{
    IList<Pedido> FiltroCliente(Cliente clienteAtual);
    IList<Pedido> FiltroDataRealizacao(DateTime dataConsultada);
    IList<Pedido> FiltroIntervaloDatas(DateTime dataInicial, DateTime dataFinal, Cliente clienteAtual);
    Pedido ProcuraComCliente(int Id, Cliente clienteAtual);
    void AlterarSituacao(int opcaoSituacao, Pedido pedidoConsultado);
    void SalvaPedidos();
    void CarregaPedidos();
    bool VerificaExistenciaPedidos();
}
