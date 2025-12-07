using Entidades;
using Arena;

class Program
{
    static void Main(string[] args)
    {
        IniciaArena arena = new IniciaArena();

        
        arena.Adicionar(new Guerreiro("Guerreiro", 5));
        arena.Adicionar(new Mago("Mago", 5));
        arena.Adicionar(new Arqueiro("Arqueiro", 5));
        arena.Adicionar(new Monstro("Monstro", 5));

        
        arena.IniciarBatalha();

        Console.WriteLine("\nPressione ENTER para sair...");
        Console.ReadLine();
    }
}