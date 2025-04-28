using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class ICollectable
    {
        
    }

    public class Items
    {
        //Creating a class for the items, which will be used to create different types of items.
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Items(string name, string description )
        { 
            name = Name;
            description = Description;
        }
    }

    public class Weapons : Items
    {
        private int Damage { get; set; }
        public Weapon(string name, string description, int damage) : base(name, description)
        {
            Damage = damage;
        }   
        public override string ToString()
        {
            return Name;
        }
    }

    public class Potions : Items
    {
        public int Health { get; private set; }
        public Potion(string name, string description, int health) : base(name, description)
        {
            Health = health;
        }
    }
}