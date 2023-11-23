namespace PokemonTrainer;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Trainer> trainers = new();

        string command;
        while ((command = Console.ReadLine()) != "Tournament")
        {
            string[] cmndArrgs = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Trainer trainer = trainers.SingleOrDefault(t => t.Name == cmndArrgs[0]);

            if (trainer == null)
            {
                trainer = new(cmndArrgs[0]);
                trainer.Pokemons
                    .Add(new Pokemon(cmndArrgs[1],
                    cmndArrgs[2], int.Parse(cmndArrgs[3])));

                trainers.Add(trainer);
            }
            else
            {
                trainer.Pokemons.Add(new Pokemon(cmndArrgs[1],
                    cmndArrgs[2], int.Parse(cmndArrgs[3])));
            }
        }

        string cmndType;
        while ((cmndType = Console.ReadLine()) != "End")
        {
            string element = cmndType;

            foreach (var trainer in trainers)
            {
                trainer.CheckPokemon(element);
            }
        }

        foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
        }
    }
}