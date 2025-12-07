namespace Entidades;

public class Monstro : Entidade
{
    public int BonusFuria { get; private set; } = 0;

    public Monstro(string nome, int nivel) : base(nome, 120, nivel)
    {
    }

    public override void Atacar(Entidade alvo)
    {
       if (!Vivo || !alvo.Vivo) return;

        int dano = 10 + (Nivel * 2) + BonusFuria;
        Console.WriteLine($"{Nome} ataca ferozmente! (Bônus de fúria: +{BonusFuria})");
        alvo.ReceberDano(dano);
        DanoTotal += dano;
        
        
        BonusFuria += 2;
    }
}