using System;
using System.Text.Json;
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

    public IList<Pedido> FiltroCliente(Cliente clienteAtual)
    {
        return Valores.Where(p => p.ClienteDoPedido == clienteAtual).ToArray();
    }

    public IList<Pedido> FiltroDataRealizacao(DateTime dataConsultada)
    {
        return Valores.Where(p => p.DataHoraPedido.Date == dataConsultada.Date).ToArray();
    }

    public IList<Pedido> FiltroIntervaloDatas(DateTime dataInicial, DateTime dataFinal, Cliente clienteAtual)
    {
        if (Valores.Count != 0)
        {
            return Valores.Where(p => p.DataHoraPedido.Date >= dataInicial.Date && p.DataHoraPedido.Date <= dataFinal && p.ClienteDoPedido.ID == clienteAtual.ID).ToArray();
        }
        return null;
    }

    public Pedido ProcuraComCliente(int Id, Cliente clienteAtual)
    {
        if (Valores.Count != 0)
        {
            for (int i = 0; i < Valores.Count; i++)
            {
                if (Valores[i].ID == Id && Valores[i].ClienteDoPedido.ID == clienteAtual.ID)
                {
                    return Valores[i];
                }
            }
        }
        return null;
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
        if (!(Valores.Count == 0))
        {
            string SalvaJson = JsonSerializer.Serialize(Valores);
            File.WriteAllText("dados_pedidos.json", SalvaJson);
            SalvaJson = JsonSerializer.Serialize(IdPedido);
            File.WriteAllText("id_pedido.json", SalvaJson);
        }
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
            Valores = JsonSerializer.Deserialize<List<Pedido>>(CarregaJson);
        }

        if (!File.Exists("id_pedido.json"))
        {
            File.WriteAllText("id_pedido.json", null);
        }
        else
        {
            string CarregaId = File.ReadAllText("id_pedido.json");
            IdPedido = JsonSerializer.Deserialize<int>(CarregaId);
        }
    }
    public bool VerificaExistenciaPedidos()
    {
        if (IdPedido > 1)
        {
            return true;
        }
        return false;
    }
}
