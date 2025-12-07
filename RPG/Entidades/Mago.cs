namespace Entidades;

public class Mago : Entidade
{
    public int Inteligencia { get; set; }
    private Random random = new Random();

    public Mago(string nome, int nivel) : base(nome, 80, nivel)
    {
        Inteligencia = 15 + nivel;
    }

    public override void Atacar(Entidade alvo)
    {
        if (!Vivo || !alvo.Vivo) return;

        int dano = 12;
        
       
        int chanceCritico = 30 + (Inteligencia * 2);
        if (random.Next(100) < chanceCritico)
        {
            dano = dano * 2;
            Console.WriteLine($"{Nome} lança uma magia CRÍTICA!");
        }
        else
        {
            Console.WriteLine($"{Nome} lança uma magia!");
        }
        
        alvo.ReceberDano(dano);
        DanoTotal += dano;
    }
}