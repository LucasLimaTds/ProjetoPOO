using System;

namespace ProjetoLoja;

public class Transportadora : Endereco
{
    public Transportadora(String nome, double precokm, int id)
    {
        Nome = nome;
        PrecoPorKM = precokm;
        ID = id;
    }
    public String Nome { get; set; }
    public int ID { get; set; }
    public double PrecoPorKM { get; set; }
   
}
