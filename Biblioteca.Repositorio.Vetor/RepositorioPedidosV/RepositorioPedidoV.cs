using System;
using Biblioteca.Base.EstruturaDaLoja;
using Biblioteca.Repositorios.Interfaces.InterfacesPedidos;
using ProjetoLoja;

namespace Biblioteca.Repositorio.Vetor.RepositorioPedidosV;

public class RepositorioPedidoV : RepositorioBaseV<Pedido>, IRepositorioPedido
{
    private int IdPedido = 1;

    protected override int ObterId()
    {
        return IdPedido++;
    }

    public IList<Pedido> FiltroCliente(Cliente clienteAtual)
    {
        IList<Pedido> PedidosDoCliente = new List<Pedido>();
        for (int i = 0; i < Valores.Length; i++)
        {
            if (Valores[i].ClienteDoPedido == clienteAtual)
            {
                PedidosDoCliente.Add(Valores[i]);
            }
        }
        return PedidosDoCliente;
    }
}
