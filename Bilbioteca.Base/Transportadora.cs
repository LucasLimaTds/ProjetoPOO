using System;

namespace ProjetoLoja;

public class Transportadora
{
    public string Nome { get; set; }
    public int ID { get; set; }
    public double PrecoPorKM { get; set; }
    
    public Transportadora(string nome, double precokm)
    {
        Nome = nome;
        PrecoPorKM = precokm;
    }
   
}
