using System;
using Biblioteca.Base.EstruturaDaLoja;

namespace Biblioteca.Repositorio.Lista.RepositorioPedidosL;

public class RepositorioPedidoItemL : RepositorioBaseL<PedidoItem>
{
    private int IdPedidoItem;

    protected override int ObterId()
    {
        return IdPedidoItem;
    }


}
