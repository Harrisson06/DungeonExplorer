using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    // This abstract class is used to create a base class for all creatures and players in the game.
    public interface IDamageable
    {
        void takedamage(int Damage);
        void Heal(int Health);
    }
    public abstract class Creature : IDamageable
    {
        public int Health { get; set; }
        public void takedamage(int Damage)
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

        public string Name { get; private set; }

        public Player(string name, int health) : base(health)
        {
            Name = name;
            Health = 100;
        }

        public void PlayerStats()
        {
            Console.WriteLine($"Player Name: ", Name);
            Console.WriteLine($"Player Health: ", Health);
        }
    }
}