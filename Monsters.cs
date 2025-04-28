using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Monsters
    {
        //Creating a class for the monsters, which will be used to create different types of monsters.
        //This class is also connected to the abstract class Creature, this gives the attribute of health and damage to the monsters.
        public class Monstertype : Creature
        {
            //Creating stat for health and damage for the monsters.
            private int Health { get; set; }
            private int Damage { get; set; }

            //The bat is a low level monster with low health and damage, found around rooms
            public void Goblin(int Health, int Damage)
            {
                Health = 30;
                Random GoblinDamage = new Random();
                Damage = GoblinDamage.Next(2, 31);

            }

            public void spirit(int Health, int Damage)
            {
                Health = 60;
                Random SpiritDamage = new Random();
                Damage = SpiritDamage.Next(25, 50);
            }
            public void babyDragon(int Health, int Damage)
            {
                Health = 120;
                Random BabyDragonDamage = new Random();
                Damage = BabyDragonDamage.Next(40, 80);
                if (Damage > 60)
                {
                    //Randomly doing a heavy attack.
                    Random HeavyAttack = new Random();
                    Damage = HeavyAttack.Next(60, 120);
                }
            }
        }
    }
}

