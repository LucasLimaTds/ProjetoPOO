using System;
using ProjetoLoja;

namespace Biblioteca.Repositorios.Interfaces;

public interface IRepositorioCliente : IRepositorioBase<Cliente>
{
    public Cliente ProcuraCliente(Usuario usuario);
    void SalvaClientes();
    void CarregaClientes();
}
