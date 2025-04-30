using System;

namespace DungeonExplorer
{
    // It holds the properties of the monster, which are Name, Health and Damage.
    // The class is connected to the abstract class "creature", this is to group damageable objects together.
    // This constructor is getting and privately setting three properties of the monster, Name, Health and Damage.
    public class Monster : Creature
    {
        public string Name { get; private set; }
        public int Damage { get; private set; }

        // Constructor for MonsterType class  
        public Monster(string name, int health, int damage) : base(health)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        // This method is used to get the name of the monster.
        public string GetName()
        {
            return Name;
        }

        // Handles all monster attack logic and console output. 
        public void MonsterAttack()
        {
            Console.WriteLine($"{Name} Dealt {Damage} Damage");
            Player.User.Takedamage(Damage);
        }
    }
}