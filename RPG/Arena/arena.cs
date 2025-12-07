using Entidades;

namespace Arena;

public class IniciaArena
{
    private List<Entidade> entidades = new List<Entidade>();
    private Random random = new Random();

    public void Adicionar(Entidade entidade)
    {
        entidades.Add(entidade);
    }

    public void Turno()
    {
        List<Entidade> vivos = entidades.Where(e => e.Vivo).ToList();

        foreach (Entidade atacante in vivos)
        {
            List<Entidade> alvos = entidades.Where(e => e.Vivo && e != atacante).ToList();
            
            if (alvos.Count == 0) break;

            Entidade alvo = alvos[random.Next(alvos.Count)];
            atacante.Atacar(alvo);

			Console.WriteLine($"Aperte enter para continuar");
			Console.ReadLine();
        }
    }

    public void IniciarBatalha()
    {
        Console.WriteLine("BATALHA INICIADA");

        int turno = 1;
        while (entidades.Count(e => e.Vivo) > 1)
        {
            Console.WriteLine($"Turno {turno}");
            Turno();
            if (turno % 2 == 0)
            {
                AplicarCuraAleatoria();
            }
            turno++;

            if (turno > 20) break;
        }

        MostrarRelatorio();
    }

    private void AplicarCuraAleatoria()
    {
        List<Entidade> vivos = entidades.Where(e => e.Vivo).ToList();
        
        if (vivos.Count > 1)
        {
            Entidade sortudo = vivos[random.Next(vivos.Count + 1)];
            int cura = random.Next(10, 21);
            sortudo.Curar(cura);
        }
    }

    public void MostrarRelatorio()
    {
        Console.WriteLine("RELATÓRIO FINAL ");

        Entidade maisDano = entidades.OrderByDescending(e => e.DanoTotal).First();
        Console.WriteLine($"Maior dano: {maisDano.Nome} - {maisDano.DanoTotal} de dano total\n");

        IEnumerable<string> mortos = entidades
            .Where(e => !e.Vivo)
            .OrderBy(e => e.Nome)
            .Select(e => e.Nome);

        Console.WriteLine("Mortos (ordem alfabética):");
        foreach (string nome in mortos)
        {
            Console.WriteLine($"  - {nome}");
        }

        List<Entidade> vivos = entidades.Where(e => e.Vivo).ToList();
        Console.WriteLine("\nSobrevivente:");
        foreach (Entidade entidade in vivos)
        {
            Console.WriteLine($"  - {entidade.Nome} (Vida: {entidade.VidaAtual}/{entidade.VidaMaxima})");
        }
    }
}