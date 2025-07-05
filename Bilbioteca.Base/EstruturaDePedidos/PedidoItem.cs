using System;
using Bilbioteca.Base;
using ProjetoLoja;

namespace Biblioteca.Base.EstruturaDaLoja;

public class PedidoItem : IObjetoComId
{
    public int ID { get; set; }
    public int Quantidade { get; set; }
    public double PrecoTotal { get; set; }
    public Produto ProdutoPedido { get; set; }

    public PedidoItem()
    {
        
    }
    public PedidoItem(int quant, double preco, Produto produtoPedido)
    {
        Quantidade = quant;
        PrecoTotal = preco;
        ProdutoPedido = produtoPedido;
    }

    public override string ToString()
    {
        return $"| Produto: {ProdutoPedido.Nome} | Quantidade: {Quantidade} | Valor unitário: R${ProdutoPedido.Valor} | Valor total: R${PrecoTotal}";
    }
}
