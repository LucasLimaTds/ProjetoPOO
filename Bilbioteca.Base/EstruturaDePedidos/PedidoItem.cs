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
    
    
}
