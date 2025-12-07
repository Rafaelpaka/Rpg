namespace Entidades;

public class Arqueiro : Entidade
{
    public int ChanceDesvio { get; set; }
    private Random random = new Random();

    public Arqueiro(string nome, int nivel) : base(nome, 90, nivel)
    {
        ChanceDesvio = 10 + (nivel * 3); 
    }

    public override void Atacar(Entidade alvo)
    {
        if (!Vivo || !alvo.Vivo) return;

        int dano = 15 + Nivel;
        Console.WriteLine($"{Nome} dispara uma flecha!");
        alvo.ReceberDano(dano);
        DanoTotal += dano;
    }

    public new void ReceberDano(int dano)
    {
        if (TentarDesviar())
        {
            Console.WriteLine($"{Nome} DESVIOU do ataque!");
            return;
        }
        
        base.ReceberDano(dano);
    }

    private bool TentarDesviar()
    {
        return random.Next(100) < ChanceDesvio;
    }
}