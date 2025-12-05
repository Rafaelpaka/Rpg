namespace Entidades;

public class Endidade {

    public string Nome { get; set; }
    public int Nivel { get; set; }
    public int Ataque { get; protected set; }
    public int Vida {  get; protected set; }
    public bool Morte {  get; set; } = false;

    public Entidade(string nome, int vidaInicial, int nivel) {
    Nome = nome;
    Vida = vidaInicial;
    Nivel = nivel
    }

    public virtual void Atacar(Entidade Alvo) //Virtual para permitir o Override
    {
        Alvo.ReceberDano(Ataque);
    }
    public void ReceberDano(int dano) {
    
    Vida -= dano;
        Console.WriteLine($"{Nome} recebeu {dano} de dano. Vida {Vida}");
    }

}
