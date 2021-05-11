using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTester
{
    class PokemonDatabase:IPokemonDB
    {
        public IPocketMonster[] Dex { get; private set; }
        static IOutput output = new ConsoleLogger();
        static IInput input = new ConsoleInputLogger();
        public PokemonDatabase()
        {
            Dex = AllPokemonsInitialiser();
        }
        public IPocketMonster[] AllPokemonsInitialiser()
        {
            string[,] stats = CSV_reader.ReadCsvWeb();
            IPocketMonster[] arrayOfPokemons = new IPocketMonster[stats.GetLength(0) - 1];
            for (int i = 0; i < arrayOfPokemons.Length; i++)
            {
                Object[] statsOfThisMon = { stats[i + 1, 1], Convert.ToInt32(stats[i + 1, 5]), Convert.ToInt32(stats[i + 1, 6]), Convert.ToInt32(stats[i + 1, 7]), Convert.ToInt32(stats[i + 1, 8]), Convert.ToInt32(stats[i + 1, 9]), Convert.ToInt32(stats[i + 1, 10]) };
                arrayOfPokemons[i] = PocketMonsterFactory.Build("Pokemon",statsOfThisMon);
            }
            return arrayOfPokemons;
        }
        public IPocketMonster ChooseAPokemon()
        {
            //allows the user to choose a pokemon, checks if the input is the name of a pokemon.
            //repeats this loop until the userinput corresponds to a pokemon.
            //if the input does not correspond to a pokemon the programs asks if you want to see a list of all available pokemons.
            bool condition = true;
            int index = 0;
            do
            {
                output.Print("which pokemon would you like to use?");
                string choise = input.ReadInput();
                choise.ToLower();
                string pokemon = choise[0].ToString().ToUpper() + choise.Substring(1);
                for (int i = 0; i < Dex.Length; i++)
                {
                    if (Dex[i].Name == pokemon)
                    {
                        index = i;
                        condition = false;
                    }
                }
                if (condition)
                {
                    output.Print("This is not a valid pokemon, try again.\nWould you like a list of all available pokemon? (yes or no)");
                    ListAllPokemon();
                }
            } while (condition);
            return Dex[index];
        }
        public void ListAllPokemon()
        {
            string yesNo = input.ReadInput().ToLower();
            switch (yesNo)
            {
                case "yes":
                    WritePokemon();
                    break;
                default:
                    break;
            }
        }
        public void WritePokemon()
        {
            output.Print();
            for (int i = 0; i < Dex.Length; i++)
            {
                output.Print(Dex[i].Name);
            }
            output.Print();
        }
    }
}
