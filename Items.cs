using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Creating a base abstract class to be used on all player items, connected to Weapons and Potions.
    public abstract class PlayerItems
    {
        //Creating a class for the items, which will be used to create different types of items.
        public string Name { get; private set; }
        public string Description { get; private set; }

        // This constructor is getting and privately setting two properties of the item, Name and Description.
        public PlayerItems(string name, string description)
        { 
            Name = name;
            Description = description;
        }
    }

    // This class is used to create weapons for the player, and its connected to the abstract class "PlayerItems".
    public class Weapons : PlayerItems
    {
        public int Damage { get; set; }
        // This constructor is getting and privately setting three properties of the weapon, Name, Description and Damage.
        public Weapons(string name, string description, int damage) : base(name, description)
        {
            Damage = damage;
        }

        // This method is used to display the Weapon name instead of DungeonExplorer.Weapons.
        public override string ToString()
        {
            return Name;
        }
    }

    // This class is used to create potions for the player, and its connected to the abstract class "PlayerItems".
    public class Potions : PlayerItems
    {
        public int Health { get; private set; }

        // This constructor is getting and privately setting three properties of the potion, Name, Description and Health.
        public Potions(string name, string description, int health) : base(name, description)
        {
            Health = health;
        }
        // This method is used to display the Potion name instead of DungeonExplorer.Potions.
        public override string ToString()
        {
            return Name;
        }
    }
}