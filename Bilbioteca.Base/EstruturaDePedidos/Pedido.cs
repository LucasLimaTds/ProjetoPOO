using System;
using Bilbioteca.Base;
using ProjetoLoja;

namespace Biblioteca.Base.EstruturaDaLoja;

public class Pedido : IObjetoComId
{
    public int ID { get; set; } // Número do pedido
    public DateTime DataHoraPedido { get; set; }
    public DateTime DataHoraEntrega { get; set; }
    public string Situacao { get; set; } // Aberto, finalizado
    public double PrecoFrete { get; set; }
    public Transportadora TransportadoraPedido { get; set; }
    public IList<PedidoItem> Itens { get; set; }
    public Cliente ClienteDoPedido { get; set; }

    public Pedido()
    {
        Itens = new List<PedidoItem>();
        Situacao = "Aberto";
    }

    public override string ToString()
    {
        return $"Número: {ID} | Situação: {Situacao}";
    }
}
