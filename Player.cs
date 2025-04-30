using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    // This abstract class is used to create a base class for all creatures and players in the game.
    public interface IDamageable
    {
        void Takedamage(int Damage);
        void Heal(int Health);
    }
    public abstract class Creature : IDamageable
    {
        public int Health { get; set; }
        public void Takedamage(int Damage)
        {
            Health -= Damage;
        }
        public void Heal(int Health)
        {
            this.Health += Health;
        }

        public Creature(int health)
        {
            Health = health;
        }
    }

    // This class is used to create a player in the game, and its connected to the abstract class "Creature".
    // Setting the player class to hold two properties, Name and Health.
    public class Player : Creature
    {
        internal static Player User;
        public Inventory inventory = new Inventory();

        public string Name { get; private set; }

        public Player(string name, int health, int Damage) : base(health)
        {
            Name = name;
            Health = 100;
            inventory.PickUpItem(new Weapons("Fists", "Your fists, not very effective.", Damage));
        }

        public void PlayerAttack(Creature Target)
        {
            Weapons weapons = inventory.GetStrongestWeapon();
            Console.WriteLine($"Do you want to use a potion? \n", "[ yes | no ]");
            string Use = Console.ReadLine();
            Use.ToLower();

            if (Use == "yes")
            {
                while (true)
                {
                    if (inventory.ListPotions() != null)
                    {
                        inventory.GetPotions();
                        var potion = inventory.ListPotions();
                        Console.WriteLine($"You have used the {potion.Name} and healed for {potion.Health} health.");
                        this.Heal(potion.Health);
                        inventory.RemoveItem(potion);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You have no potions to use.");
                        break;
                    }

                }
            }
            else if (Use == "no")
            {
                Console.WriteLine("You have chosen not to use a potion.");
            }
            else
            {
                Console.WriteLine("Invalid input, Please try again.\n");
            }

            Console.WriteLine($"You attack for: {weapons.Damage} Damage");
            Target.Takedamage(weapons.Damage);
        }

        public void PlayerStats()
        {
            Console.WriteLine($"Player Name: ", Name);
            Console.WriteLine($"Player Health: ", Health);
        }
    }
}