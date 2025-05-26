using System;

namespace ProjetoLoja;

public class Transportadora : Endereco
{
    public string Nome { get; set; }
    public int ID { get; set; }
    public double PrecoPorKM { get; set; }
    
    public Transportadora(string nome, double precokm, int id)
    {
        Nome = nome;
        PrecoPorKM = precokm;
        ID = id;
    }
   
}
