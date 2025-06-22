using System;
using Biblioteca.Base.EstruturaDaLoja;

namespace Biblioteca.Repositorio.Vetor.RepositorioPedidosV;

public class RepositorioPedidoItemV : RepositorioBaseV<PedidoItem>
{
    private int IdPedidoItem;

    protected override int ObterId()
    {
        return IdPedidoItem;
    }
}
