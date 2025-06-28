using System;
using Biblioteca.Base.EstruturaDaLoja;
using Biblioteca.Repositorios.Interfaces.InterfacesPedidos;
using ProjetoLoja;

namespace Biblioteca.Repositorio.Lista.RepositorioPedidosL;

public class RepositorioPedidoL : RepositorioBaseL<Pedido>, IRepositorioPedido
{
    private int IdPedido = 1;

    protected override int ObterId()
    {
        return IdPedido++;
    }

    public string ConsultarPedido(int Id)
    {
        Pedido pedido = Procura(Id);
        if (pedido != null)
        {
            return $"Número: {pedido.ID} | Situação: {pedido.Situacao} | Transportadora: {pedido.TransportadoraPedido} | Itens: ";
        }
        return "Pedido não encontrado";
    }

    public IList<Pedido> FiltroCliente(Cliente clienteAtual)
    {
        IList<Pedido> PedidosDoCliente = new List<Pedido>();
        for (int i = 0; i < Valores.Count; i++)
        {
            if (Valores[i].ClienteDoPedido == clienteAtual)
            {
                PedidosDoCliente.Add(Valores[i]);
            }
        }
        return PedidosDoCliente;
    }
}
