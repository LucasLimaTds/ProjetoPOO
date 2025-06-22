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
    public string Situacao { get; set; }
    public double PrecoFrete { get; set; }
    public Transportadora TransportadoraPedido { get; set; }
    public IList<PedidoItem> ListaDeItens { get; set; }
}
