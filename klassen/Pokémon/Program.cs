using System;

namespace Pokémon
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokemon bulbasaur = new Pokemon();
            bulbasaur.Name = "Bulbasaur";
            bulbasaur.Base_HP = 45;
            bulbasaur.Base_Attack = 49;
            bulbasaur.Base_Defense = 49;
            bulbasaur.Base_SpecialAttack = 65;
            bulbasaur.Base_SpecialDefense = 65;
            bulbasaur.Base_Speed = 45;

            Pokemon charmander = new Pokemon();
            bulbasaur.Name = "Charmander";
            bulbasaur.Base_HP = 39;
            bulbasaur.Base_Attack = 52;
            bulbasaur.Base_Defense = 43;
            bulbasaur.Base_SpecialAttack = 60;
            bulbasaur.Base_SpecialDefense = 50;
            bulbasaur.Base_Speed = 65;

            Pokemon squirtle = new Pokemon();
            bulbasaur.Name = "Squirtle";
            bulbasaur.Base_HP = 44;
            bulbasaur.Base_Attack = 48;
            bulbasaur.Base_Defense = 65;
            bulbasaur.Base_SpecialAttack = 50;
            bulbasaur.Base_SpecialDefense = 64;
            bulbasaur.Base_Speed = 43;

            bulbasaur.ShowInfo();
            charmander.ShowInfo();
            squirtle.ShowInfo();
            /*
            for (int i = 0; i < 99; i++)
            {
                charmander.IncreaseLevel();
                Console.WriteLine($"charmander : \nLevel {charmander.Level}\nHP {charmander.Full_HP} \nAttack {charmander.Full_Attack}\n");
            }
            */
        }
    }
}
