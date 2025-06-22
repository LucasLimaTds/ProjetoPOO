using System;
using Biblioteca.Base.EstruturaDaLoja;

namespace Biblioteca.Repositorio.Vetor.RepositorioPedidosV;

public class RepositorioPedidoV : RepositorioBaseV<Pedido>
{
    private int IdPedido;

    protected override int ObterId()
    {
        return IdPedido;
    }
}
