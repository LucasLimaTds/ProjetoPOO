using System;

namespace ProjetoLoja;

public class Endereco
{
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string CEP { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }

    public void ListarEndereço() //REMOVER DA VERSÃO FINAL!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        Console.WriteLine("Endereço:");
        Console.WriteLine($"Rua: {Rua} | Número: {Numero} | Complemento: {Complemento} | Bairro: {Bairro} | CEP: {CEP} | Cidade: {Cidade} | Estado: {Estado}\n");
    }

    // public override string ToString() // implementar
    // {
    //     return $"Endereço:\nRua: {Rua} | Número: {Numero} | Complemento: {Complemento} | Bairro: {Bairro} | CEP: {CEP} | Cidade: {Cidade} | Estado: {Estado}\n";
    // }
}
