namespace Entidades;

public abstract class Entidade
{
    public string Nome { get; set; }
    public int Nivel { get; set; }
    
    public int VidaMaxima { get; protected set; }
    public int VidaAtual { get; protected set; }
    
    public bool Vivo => VidaAtual > 0;
    public int DanoTotal { get; set; } = 0;

    protected Entidade(string nome, int vidaMaxima, int nivel)
    {
        Nome = nome;
        VidaMaxima = vidaMaxima;
        VidaAtual = vidaMaxima;
        Nivel = nivel;
    }

    public abstract void Atacar(Entidade alvo);

    public void ReceberDano(int dano)
    {
        VidaAtual -= dano;
        if (VidaAtual < 0) VidaAtual = 0;
        Console.WriteLine($"{Nome} recebeu {dano} de dano. Vida: {VidaAtual}/{VidaMaxima}");
    }

    public void Curar(int valor)
    {
        VidaAtual += valor;
        if (VidaAtual > VidaMaxima) VidaAtual = VidaMaxima;
        Console.WriteLine($"{Nome} curou {valor} de vida. Vida: {VidaAtual}/{VidaMaxima}");
    }
}