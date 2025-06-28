using System;
using Biblioteca.Base.EstruturaDaLoja;
using ProjetoLoja;

namespace Biblioteca.Repositorios.Interfaces.InterfacesPedidos;

public interface IRepositorioPedido : IRepositorioBase<Pedido>
{
    IList<Pedido> FiltroCliente(Cliente clienteAtual);
    IList<Pedido> FiltroDataRealizacao(DateTime dataConsultada);
    void AlterarSituacao(int opcaoSituacao, Pedido pedidoConsultado);
}
