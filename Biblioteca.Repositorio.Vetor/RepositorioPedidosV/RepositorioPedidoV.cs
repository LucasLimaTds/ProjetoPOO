using System;
using Biblioteca.Base.EstruturaDaLoja;

namespace Biblioteca.Repositorio.Vetor.RepositorioPedidosV;

public class RepositorioPedidoV : RepositorioBaseV<Pedido>
{
    private int IdPedido = 1;

    protected override int ObterId()
    {
        return IdPedido++;
    }
}
