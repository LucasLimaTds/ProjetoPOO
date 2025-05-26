using System;

namespace ProjetoLoja;

public abstract class Endereco
{
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string CEP { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }

    public void ListarEndereço()
    {
        Console.WriteLine("Endereço:");
        Console.WriteLine($"Rua: {Rua} | Número: {Numero} | Complemento: {Complemento} | Bairro: {Bairro} | CEP: {CEP} | Cidade: {Cidade} | Estado: {Estado}\n");
    }
}
