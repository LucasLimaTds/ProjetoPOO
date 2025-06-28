using System;
using System.Text;
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
        for (int i = 0; i < Valores.Length; i++)
        {
            if (Valores[i].ClienteDoPedido == clienteAtual)
            {
                PedidosDoCliente.Add(Valores[i]);
            }
        }
        return PedidosDoCliente;
    }

    public IList<Pedido> FiltroDataRealizacao(DateTime dataConsultada)
    {
        IList<Pedido> PedidosDoCliente = new List<Pedido>();
        for (int i = 0; i < Valores.Length; i++)
        {
            if (Valores[i].DataHoraPedido == dataConsultada)
            {
                PedidosDoCliente.Add(Valores[i]);
            }
        }
        return PedidosDoCliente;
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
