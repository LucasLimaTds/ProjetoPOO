using System;
using System.Text;
using System.Text.Json;
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
        return Valores.Where(p => p.ClienteDoPedido == clienteAtual).ToArray();
    }

    public IList<Pedido> FiltroDataRealizacao(DateTime dataConsultada)
    {
        return Valores.Where(p => p.DataHoraPedido.Date == dataConsultada.Date).ToArray();
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
    public void SalvaPedidos()
    {
        string SalvaJson = JsonSerializer.Serialize(Valores);
        File.WriteAllText("dados_pedidos.json", SalvaJson);
        SalvaJson = JsonSerializer.Serialize(IdPedido);
        File.WriteAllText("id_pedido.json", SalvaJson);
    }

    public void CarregaPedidos()
    {
        if (!File.Exists("dados_pedidos.json"))
        {
            File.WriteAllText("dados_pedidos.json", null);
        }
        else
        {
            string CarregaJson = File.ReadAllText("dados_pedidos.json");
            if (CarregaJson != null)
            {
                Valores = JsonSerializer.Deserialize<Pedido[]>(CarregaJson);
            }
        }

        if (!File.Exists("id_pedido.json"))
        {
            File.WriteAllText("id_pedido.json", null);
        }
        else
        {
            string CarregaId = File.ReadAllText("id_pedido.json");
            if (CarregaId != null)
            {
                IdPedido = JsonSerializer.Deserialize<int>(CarregaId);
            }
        }
    }
}
