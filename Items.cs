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

    public class PlayerItems
    {
        //Creating a class for the items, which will be used to create different types of items.
        public string Name { get; private set; }
        public string Description { get; private set; }

        public PlayerItems(string name, string description)
        { 
            name = Name;
            description = Description;
        }
    }

    public class Weapons : PlayerItems
    {
        private int Damage { get; set; }
        public Weapons(string name, string description, int damage) : base(name, description)
        {
            Damage = damage;
        }   
        public override string ToString()
        {
            return Name;
        }
    }

    public class Potions : PlayerItems
    {
        public int Health { get; private set; }
        public Potions(string name, string description, int health) : base(name, description)
        {
            Health = health;
        }
    }
}