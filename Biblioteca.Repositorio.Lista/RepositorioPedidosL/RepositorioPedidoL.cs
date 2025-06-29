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
        return Valores.Where(p => p.ClienteDoPedido==clienteAtual).ToArray();
    }


    public IList<Pedido> FiltroDataRealizacao(DateTime dataConsultada)
    {
        return Valores.Where(p => p.DataHoraPedido.Date==dataConsultada.Date).ToArray();
    }

    public void AlterarSituacao(int opcaoStatus, Pedido pedidoConsultado)
    {
        if (opcaoStatus == 1)
        {
            pedidoConsultado.Situacao = "Em trânsito";
        }
        else if (opcaoStatus == 2)
        {
            pedidoConsultado.Situacao = "Entregue";
            pedidoConsultado.DataHoraEntrega = DateTime.Now;
        }
        else 
        {
            pedidoConsultado.Situacao = "Cancelado";
            pedidoConsultado.DataHoraCancelamento = DateTime.Now;
        }
    }
}
