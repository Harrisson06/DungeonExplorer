using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    // This abstract class is used to create a base class for all creatures and players in the game.
    public abstract class Creature
    {
        private class IDamageable
        {
            private int Damage { get; set; }

            public IDamageable(int damage)
            {
                Damage = damage;
            }
        }
    }

    // This class is used to create a player in the game, and its connected to the abstract class "Creature".
    // Setting the player class to hold two properties, Name and Health.
    public class Player : Creature
    {
        public string Name { get; private set; }
        public int Health { get; set; }

        public Player(string name, int health)
        {
            Name = name;
            Health = 50;
        }

        // This class is used to create a Monster in the game, and its connected to the abstract class "Creature".
        public class Monstertype : Creature
        {
            public int Health { get; private set; }
            public int Damage { get; set; }
        }
    }
}