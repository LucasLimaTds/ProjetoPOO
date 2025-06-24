using System;
using Biblioteca.Base.EstruturaDaLoja;

namespace Biblioteca.Repositorio.Lista.RepositorioPedidosL;

public class RepositorioPedidoL : RepositorioBaseL<Pedido>
{
    private int IdPedido;

    protected override int ObterId()
    {
        return IdPedido++;
    }
}
