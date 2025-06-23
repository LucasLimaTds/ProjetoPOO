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

    public override string ToString()
    {
        return $"Produto: {ProdutoPedido.Nome} | Quantidade: {Quantidade} | Valor uniário: {ProdutoPedido.Valor} | Valor total: {PrecoTotal}";
    }
}
