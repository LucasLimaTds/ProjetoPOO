using System;
using Bilbioteca.Base;
using ProjetoLoja;

namespace Biblioteca.Base.EstruturaDaLoja;

public class Pedido : IObjetoComId
{
    public int ID { get; set; }
    public int NumeroPedido { get; set; }
    public DateTime DataHoraPedido { get; set; }
    public DateTime DataHoraEntrega { get; set; }
    public string Situacao { get; set; } // Aberto, finalizado
    public double PrecoFrete { get; set; }
    public Transportadora TransportadoraPedido { get; set; }
    public IList<PedidoItem> ListaDeItens { get; set; }

    public Pedido()
    {
        ListaDeItens = new List<PedidoItem>(); // só consegui fazer uncionar assim. Não sei se é o melhor jeito
        Situacao = "Aberto";
    }

    public override string ToString()
    {
        return $"Número: {ID} | Situação: {Situacao} | Data e hora do pedido: {DataHoraEntrega} | Transportadora: {TransportadoraPedido} | Preço do frete: {PrecoFrete}";
    }
}
