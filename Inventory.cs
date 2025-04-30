using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    // Inventory class to hold all inventory functions. 
    public class Inventory
    {
        // Declaring the invenory for the game.
        public List<object> inventory;

        // Initializes the inventory in the constructor.  
        public Inventory()
        {
            inventory = new List<object>();
        }

        // Add the item to the inventory.  
        public void PickUpItem(object item)
        {
            inventory.Add(item);
        }

        // Removes an item from the inventory.  
        public void RemoveItem(object item)
        {
            inventory.Remove(item);
        }

        // Returns the contents of the Inventory list with a comma separator.  
        public string InventoryContents()
        {
            return string.Join(", ", inventory.Select(i => i.ToString()));
        }

        // Returns all weapons in the Inventory. 
        public IEnumerable<Weapons> GetWeapons()
        {
            return inventory.OfType<Weapons>();
        }

        // Gets the strongest weapon in the inventory and returns it.
        public Weapons GetStrongestWeapon()
        {
            // Return the strongest weapon in the inventory.  
            return GetWeapons().OrderByDescending(w => w.Damage).FirstOrDefault();
        }

        // Returns all potions in the inventory.
        public IEnumerable<Potions> GetPotions()
        {
            return inventory.OfType<Potions>();
        }

        // Gets the strongest potion in the inventory and returns it.
        public Potions ListPotions()
        {
            // Return the strongest potion in the inventory.  
            return GetPotions().OrderByDescending(p => p.Health).FirstOrDefault();
    }
}
}

