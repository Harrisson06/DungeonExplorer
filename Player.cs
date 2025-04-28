using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
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
    public class Player : Creature
    {
        public string Name { get; private set; }
        public int Health { get; set; }

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public class Monstertype : Creature
        {
            public int Health { get; private set; }
            public int Damage { get; set; }
        }
    }
}