using System;
using Bilbioteca.Base;
using ProjetoLoja;

namespace Biblioteca.Base.EstruturaDaLoja;

public class Pedido : IObjetoComId
{
    public int ID { get; set; }
    public DateTime DataHoraPedido { get; set; }
    public DateTime DataHoraEntrega { get; set; }
    public DateTime DataHoraCancelamento { get; set; }
    public string Situacao { get; set; }
    public double PrecoFrete { get; set; }
    public double PrecoTotal { get; set; }
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

    public string DetalhesPedido()
    {
        return $"| Pedido Número: {ID} \n| Preço Total: R${PrecoTotal} | Situação: {Situacao} | Transportadora: {TransportadoraPedido.Nome} | Preço Frete: R${PrecoFrete} ";
    }
}
