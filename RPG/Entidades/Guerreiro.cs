namespace Entidades;

public class Guerreiro : Entidade
{
    public int Forca { get; set; }

    public Guerreiro(string nome, int nivel) : base(nome, 100, nivel)
    {
        Forca = 10 + (5 + nivel);
    }

    public override void Atacar(Entidade alvo)
    {
         if (!Vivo || !alvo.Vivo) return;

        int dano = 15 + Forca;
        Console.WriteLine($"{Nome} ataca com a espada!");
        alvo.ReceberDano(dano);
        DanoTotal += dano;
    
    }
}