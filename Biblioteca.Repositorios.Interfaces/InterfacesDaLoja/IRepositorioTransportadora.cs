using System;
using ProjetoLoja;

namespace Biblioteca.Repositorios.Interfaces;

public interface IRepositorioTransportadora : IRepositorioBase<Transportadora>
{
    string ConsultarTransportadora(int id);
    bool VerificaExistenciaTransportadora();
    void AlteraNome(string novoNome, Transportadora TransportadoraEditar);
    void AlteraPrecoPorKm(double novoPreco, Transportadora TransportadoraEditar);
    void SalvaTransportadoras();
    void CarregaTransportadoras();
}
