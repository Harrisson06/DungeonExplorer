using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // It holds the properties of the monster, which are Name, Health and Damage.
    // The class is connected to the abstract class "creature", this is to group damageable objects together.
    // This constructor is getting and privately setting three properties of the monster, Name, Health and Damage.
    class Monster : Creature
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }

        // Constructor for MonsterType class  
        public Monster(string name, int health, int damage)
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
    }
}