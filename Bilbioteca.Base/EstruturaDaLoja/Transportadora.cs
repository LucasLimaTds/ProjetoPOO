using System;
using Bilbioteca.Base;

namespace ProjetoLoja;

public class Transportadora : IObjetoComId
{
    public string Nome { get; set; }
    public int ID { get; set; }
    public double PrecoPorKM { get; set; }
    public Transportadora()
    {
        
    }

    public Transportadora(string nome, double precokm)
    {
        Nome = nome;
        PrecoPorKM = precokm;
    }
    
    public override string ToString()
    {
        return $"ID: {ID} | Nome: {Nome} | Preço por km: {PrecoPorKM}";
    }
   
}
