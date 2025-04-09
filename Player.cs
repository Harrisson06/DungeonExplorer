using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        private class IDamageable
        {
            public int Damage { get; set; }

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

        private List<string> inventory = new List<string>();

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public class Items
        {
            public int HealthPotion { get; private set; }
            public int Sword { get; private set; }
        }

        public void PickUpItem(string itemName)
        {
            new List<string> { };
            inventory.Add(itemName);
        }

        public void RemoveItem(string itemName)
        {
            inventory.Remove(itemName);
        }

        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
    public class Monstertype : Creature
    {
        public int Health { get; private set; }
        public int Damage { get; set; }

        //
        public void Goblin(int health, int damage)
        {
            Health = 30;
            Random OrcDamage = new Random();
            Damage = OrcDamage.Next(2, 31);
            
        }

        public void Orc(int health, int damage)
        {
            Health = 60;
            Random GoblinDamage = new Random();
            Damage = GoblinDamage.Next(25, 50);
        }
        public void Dragon(int health, int damage)
        {
            Health = 120;
            Random DragonDamage = new Random();
            Damage = DragonDamage.Next(40, 80);
            if (Damage > 60)
            {
                //Randomly doing a heavy attack.
                Random HeavyAttack = new Random();
                Damage = HeavyAttack.Next(60, 120);
            }
        }
    }
}